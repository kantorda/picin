#pragma once

using namespace System;

namespace LibraryInterface {
	public ref class Interface2
	{
	public:
		static Void Test(String^ input, [Runtime::InteropServices::Out] String^% output);
		static Void ProcessImage(String^ path, [Runtime::InteropServices::Out] String^% luminocity,
			[Runtime::InteropServices::Out] String^% complexity, [Runtime::InteropServices::Out] array<String^>^ mainColor,
			[Runtime::InteropServices::Out] array<String^>^ secondaryColor, [Runtime::InteropServices::Out] String^% red,
			[Runtime::InteropServices::Out] String^% yellow, [Runtime::InteropServices::Out] String^% green,
			[Runtime::InteropServices::Out] String^% cyan, [Runtime::InteropServices::Out] String^% blue,
			[Runtime::InteropServices::Out] String^% purple, [Runtime::InteropServices::Out] String^% black,
			[Runtime::InteropServices::Out] String^% gray, [Runtime::InteropServices::Out] String^% white);
	};
}
