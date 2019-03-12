// Library.cpp : Defines the exported functions for the DLL application.
//
#include "stdafx.h"
#include "Processor.h"

EXTERN_C __declspec(dllexport) void processImagePrintStatistics(char* path)
{
	Core::Processor::process(std::string(path));
}

