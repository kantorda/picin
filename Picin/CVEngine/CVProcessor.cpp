#include "CVProcessor.h"
#include "opencv2/opencv.hpp"
#include <string>
#include <filesystem>
#include "Image.h"
#include "Tools.h"
namespace fs = std::experimental::filesystem;

namespace Core
{
	CVProcessor::CVProcessor() = default;

	void CVProcessor::cvEngineStart(const char* path)
	{
		
	}

	void CVProcessor::process(const char* path)
	{
		std::string filePath(path);
		cv::Mat mat = cv::imread(filePath);
		Image img(mat);
		img.process();

		Tools::printStatistics(img, filePath);
	}

	const char* CVProcessor::scanDirectory(const char* path)
	{
		if (!fs::exists(fs::path(path)))
			return "path does not exist";
		if (fs::is_directory(fs::path(path)))
			return "path does not point to a directory";


	}
}
