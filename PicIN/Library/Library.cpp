// Library.cpp : Defines the exported functions for the DLL application.
//
#include "stdafx.h"
#include "Processor.h"

#ifndef EXPORT
#define EXPORT __declspec(dllexport)
#endif


EXTERN_C EXPORT void processImagePrintStatistics(char* path)
{
	Core::Processor::process(std::string(path));
}