#pragma once
#include <filesystem>
//#include "Logger.h"
namespace fs = std::experimental::filesystem;

namespace Core
{
	class Processor
	{
	public:
		Processor();
		void cvEngineStart(std::string filePath);
		static void process(std::string filePath);
	private:
		//Logger* logger;
		/*void process(std::string filePath);*/
		const char* scanDirectory(const char* path);
	};
}
