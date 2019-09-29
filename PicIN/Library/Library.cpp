// Library.cpp : Defines the exported functions for the DLL application.
//
#include "stdafx.h"
#include "Processor.h"

#ifndef EXPORT
#define EXPORT __declspec(dllexport)
#endif


EXTERN_C EXPORT const char* processDirectory(char* path)
{
	return Core::Processor().cvEngineStart(std::string(path));
}

EXTERN_C EXPORT const char* processImage(char* path)
{
	return Core::Processor().processImage(std::string(path));
}