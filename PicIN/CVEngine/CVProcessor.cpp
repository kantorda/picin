#include "CVProcessor.h"
#include "opencv2/opencv.hpp"
#include <string>
#include <filesystem>
#include <iostream>
#include <fstream>
#include "Tools.h"
#include "Image.h"

namespace Core
{
	CVProcessor::CVProcessor() = default;

	void CVProcessor::showImage(const char* path)
	{
		std::string filePath(path);
		cv::Mat img = cv::imread(filePath);
		cv::namedWindow("image", cv::WINDOW_NORMAL);
		cv::imshow("image", img);
		cv::waitKey(5000);
	}

	void CVProcessor::process(const char* path)
	{
		std::string filePath(path);
		cv::Mat mat = cv::imread(filePath);
		Image img(mat);
		img.process();

		size_t targetChar = filePath.find_last_of('\\');
		size_t periodLocation = filePath.find_last_of('.');
		std::string fileName = filePath.substr(targetChar, (periodLocation - targetChar));

		std::string logDir = std::experimental::filesystem::current_path().string() + "\\..\\..\\..\\..\\logs\\";
		std::string outFilePath = logDir + fileName + "_matrix";

		if (!std::experimental::filesystem::exists(std::experimental::filesystem::path(logDir)))
			std::experimental::filesystem::create_directory(std::experimental::filesystem::path(logDir));

		std::ofstream oFile(outFilePath);
		if (!oFile.is_open())
			oFile.open(outFilePath);
		oFile << "Analysis of file, " << filePath << "\n";
		oFile << "Elapsed time: " << img.getTime() << "\n";
		oFile << "Number processed pixels: " << img.pixels.count << "\n";
		oFile << "Number of unprocessed pixels: " << img.stats.numBadPixels << "\n";
		oFile << "Luminocity: ";
		if (img.stats.brightness == bright)
			oFile << "Bright\n";
		else if (img.stats.brightness == neutral)
			oFile << "Neutral\n";
		else
			oFile << "Dark\n";
		oFile << "Summary\n";
		oFile << "Complexity: " << img.stats.complexity << "\n";
		oFile << "Main Colors: ";
		for (Colors color : img.stats.mainColors)
			oFile << Core::ColorsString[color] << ", ";
		oFile << std::endl;
		oFile << "Secondary Colors: ";
		for (Colors color : img.stats.secondaryColors)
			oFile << Core::ColorsString[color] << ", ";
		oFile << std::endl;
		oFile << "Percentage of image by color:\n";
		oFile << "Red: " << img.stats.colorRatio[red] << "\n";
		oFile << "Yellow: " << img.stats.colorRatio[yellow] << "\n";
		oFile << "Green: " << img.stats.colorRatio[green] << "\n";
		oFile << "Cyan: " << img.stats.colorRatio[cyan] << "\n";
		oFile << "Blue: " << img.stats.colorRatio[blue] << "\n";
		oFile << "Purple: " << img.stats.colorRatio[purple] << "\n";
		oFile << "Black: " << img.stats.colorRatio[black] << "\n";
		oFile << "Gray: " << img.stats.colorRatio[gray] << "\n";
		oFile << "White: " << img.stats.colorRatio[white] << "\n";
		oFile.flush();
	}
}
