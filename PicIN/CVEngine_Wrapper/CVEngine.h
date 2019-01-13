#pragma once
#include "CVEngine_Wrapper.h"
#include "../CVEngine/CVEngine.h"

using namespace System;

namespace CVEngine
{
	public ref class CVEngine : public ManagedWrapper<Core::CVProcessor>
	{
	public:
		CVEngine();
		void showImage(String^ filePath);
	};

	public ref class CVTools : public ManagedWrapper<Core::CVTools>
	{
	public:
		CVTools();
		void printMat(String^ filePath);	
	};
}