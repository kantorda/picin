#include "CVProcessor.h"
#include <string>

#include "opencv2/opencv.hpp"

namespace Core
{
	CVProcessor::CVProcessor() = default;

	void CVProcessor::showImage(const char* path)
	{
		std::string filePath(path);
		cv::Mat img = cv::imread(filePath);
		cv::namedWindow("image", cv::WINDOW_NORMAL);
		cv::imshow("image", img);
		cv::waitKey(0);
	}

	const char* CVProcessor::infrastructureTest(const char* data)
	{
		return data;
	}
}