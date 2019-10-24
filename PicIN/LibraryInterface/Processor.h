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
		static List<List<String^>^>^ processImage(std::string filePath);
	};
}
