#pragma once
#include <filesystem>
#include "Logger.h"
namespace fs = std::experimental::filesystem;

namespace Core
{
	class CVProcessor
	{
	public:
		CVProcessor();
		void cvEngineStart(const char* path);
	private:
		//Logger* logger;
		void process(const char* path);
		const char* scanDirectory(const char* path);
	};
}
