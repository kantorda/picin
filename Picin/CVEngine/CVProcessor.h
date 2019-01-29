#pragma once

namespace Core
{
	class CVProcessor
	{
	public:
		CVProcessor();
		void showImage(const char* path);
<<<<<<< HEAD:Picin/CVEngine/CVProcessor.h
=======
		void process(const char* path);
		const char* scanDirectory(const char* path);
>>>>>>> Dev:Picin/CVEngine/CVProcessor.h
	};
}