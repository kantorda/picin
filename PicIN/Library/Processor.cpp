#include "stdafx.h"
#include "Processor.h"
#include "opencv2/opencv.hpp"
#include <string>
#include <filesystem>
#include "Image.h"
#include "Tools.h"
namespace fs = std::experimental::filesystem;

namespace Core
{
	Processor::Processor() = default;

	void Processor::cvEngineStart(std::string filePath)
	{
		//logger = new Logger();
		//Logger::write(Logger::Level::Info, "Starting CVEngine");

		//delete logger;
	}

	void Processor::process(std::string filePath)
	{
		//std::string filePath(path);
		cv::Mat mat = cv::imread(filePath);
		Image img(mat);
		img.process();

		Tools::printStatistics(img, filePath);
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
