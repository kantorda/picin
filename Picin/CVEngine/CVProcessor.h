#pragma once

namespace Core
{
	class CVProcessor
	{
	public:
		CVProcessor();
		void cvEngineStart(const char* path);
		void process(const char* path);
		const char* scanDirectory(const char* path);
	};
}