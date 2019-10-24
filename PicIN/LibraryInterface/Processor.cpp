#include "pch.h"

namespace fs = std::experimental::filesystem;

namespace Core
{
	Processor::Processor() = default;

	List<List<String^>^>^ Processor::processImage(std::string filePath)
	{
		cv::Mat mat = cv::imread(filePath);
		Image img(mat, filePath);
		img.process();
		
		return img.serializeToList();
	}
}
