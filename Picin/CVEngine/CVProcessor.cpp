#include "CVProcessor.h"
#include <string>
#include "opencv2/opencv.hpp"
#include "Tools.h"

#include <filesystem>
#include <iostream>
#include <fstream>

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
}
