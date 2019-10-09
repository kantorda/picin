#pragma once

using namespace System;

namespace LibraryInterface {
	public ref class Interface2
	{
	public:
		static Void Test(String^ input, [Runtime::InteropServices::Out] String^% output);
	};
}
