#include "Tools.h"
#include <iostream>
#include <ctime>
#include <filesystem>
#include <opencv2/core/mat.hpp>
#include <opencv2/core/core_c.h>
#include <opencv2/core/types_c.h>
#include <fstream>
#include <opencv2/imgcodecs.hpp>

using namespace std;

void Core::CVTools::printMat(const char* path)
{
	string imgPath(path);
	size_t targetChar = imgPath.find_last_of('\\');
	size_t periodLocation = imgPath.find_last_of('.');
	string fileName = imgPath.substr(targetChar, (periodLocation - targetChar));

	string logDir = experimental::filesystem::current_path().string() + "\\..\\..\\..\\..\\logs\\";
	string outFilePath = logDir + fileName + "_matrix";

	cv::Mat img = cv::imread(imgPath);

	if (!experimental::filesystem::exists(experimental::filesystem::path(logDir)))
		experimental::filesystem::create_directory(experimental::filesystem::path(logDir));

	ofstream oFile(outFilePath);
	if (oFile.is_open())
	{
		oFile << img;
		oFile.flush();
		oFile.close();
	}

	else
	{
		oFile.open(outFilePath);
		oFile << img;
		oFile.flush();
		oFile.close();
	}
}
