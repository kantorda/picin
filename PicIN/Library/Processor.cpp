#include "stdafx.h"
#include "Processor.h"
#include "opencv2/opencv.hpp"
#include <string>
#include <filesystem>
#include <thread>
#include "Image.h"
#include "Tools.h"
namespace fs = std::experimental::filesystem;

namespace Core
{
	Processor::Processor() = default;

	const char* Processor::cvEngineStart(std::string directoryPath)
	{
		const fs::path dirPath(directoryPath);
		fs::directory_entry dir(dirPath);

		if (!fs::is_directory(dir))
			return "";

		std::vector<fs::directory_entry> files;

		fs::directory_iterator dirIT(dir);
		for (const auto& entry : dirIT)
		{
			if (isValidImage(entry))
			{
				files.push_back(entry);
			}
		}

		int numThreads = ((files.size() / 10) < 1) ? 1 : (files.size() / 10);
		int threeQuartersThreadCount = std::thread::hardware_concurrency();
		if (threeQuartersThreadCount > 0)
		{
			threeQuartersThreadCount = ((threeQuartersThreadCount * 3) / 4);
			if (threeQuartersThreadCount < numThreads)
			{
				numThreads = threeQuartersThreadCount;
			}
		}

		const int filesPerWorker = int(files.size() / numThreads);

		std::vector<std::vector<fs::directory_entry>>fileVectors;
		unsigned int startIndx = 0, endIndx = 0;
		bool pushLast = false;
		for (int i = 0; i < numThreads; ++i)
		{
			if (startIndx >= files.size())
				break;

			endIndx = startIndx + filesPerWorker;
			if ((endIndx >= files.size()) || (i == (numThreads - 1)))
			{
				fileVectors.emplace_back(&files[startIndx], &files.back());
				pushLast = true;
			}
			else
			{
				fileVectors.emplace_back(&files[startIndx], &files[endIndx]);
				if (endIndx == (files.size() - 1))
					pushLast = true;
			}
			startIndx = endIndx;
		}

		if (pushLast)
			fileVectors.back().push_back(files.back());

		std::vector<std::thread*> threadPool;
		for (std::vector<fs::directory_entry> vec : fileVectors)
			threadPool.push_back(new std::thread(&Processor::threadWorker, this, vec, &imageData));

		for (std::thread* thread : threadPool)
			thread->join();

		std::string data;
		for (std::string str : imageData)
			data += str;
		return data.c_str();
	}

	void Processor::threadWorker(std::vector<fs::directory_entry> files, std::vector<std::string>* imageData)
	{
		for (const fs::directory_entry& file : files)
			process(file.path().string(), imageData);
	}

	void Processor::process(std::string filePath, std::vector<std::string>* imageData)
	{
		//std::string filePath(path);
		cv::Mat mat = cv::imread(filePath);
		Image img(mat, filePath);
		img.process();

		//Tools::printStatistics(img, filePath);
		imageData->push_back(img.serialize());
	}

	const char* Processor::processImage(std::string filePath)
	{
		cv::Mat mat = cv::imread(filePath);
		Image img(mat, filePath);
		img.process();

		return img.serialize().c_str();
	}

	bool Processor::isValidImage(fs::directory_entry file)
	{
		if (!exists(file))
			return false;
		if (!fs::is_regular_file(file))
			return false;
		const std::string& extension = file.path().extension().string();
		return (extension == ".jpg" || extension == ".png");
	}

	const char* Processor::scanDirectory(const char* path)
	{
		if (!fs::exists(fs::path(path)))
			return "path does not exist";
		if (fs::is_directory(fs::path(path)))
			return "path does not point to a directory";

		return NULL;
	}
}
