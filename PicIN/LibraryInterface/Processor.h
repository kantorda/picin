#pragma once
#include "pch.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace msclr::interop;

namespace fs = std::experimental::filesystem;

namespace Core
{
	class Processor
	{
	public:
		Processor();
		const char* cvEngineStart(std::string directoryPath);
		static void process(std::string filePath, std::vector<std::string>* imageData);
		const char* processImage(std::string filePath);
		static List<List<String^>^>^ processImage2(std::string filePath);
	private:
		//Logger* logger;
		/*void process(std::string filePath);*/
		void threadWorker(std::vector<fs::directory_entry> files, std::vector<std::string>* imageData);
		bool isValidImage(fs::directory_entry file);
		const char* scanDirectory(const char* path);
		std::vector<std::string> imageData;
	};
}
