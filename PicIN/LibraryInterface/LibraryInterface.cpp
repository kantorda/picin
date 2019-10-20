#include "pch.h"

namespace LibraryInterface {
	Void Interface2::Test(String^ input, [Runtime::InteropServices::Out] String^% output)
	{
		output = gcnew String("your input was " + input);
		//return output + input;
	}

	Void Interface2::ProcessImage(String^ path, [Runtime::InteropServices::Out] String^% luminocity,
		[Runtime::InteropServices::Out] String^% complexity, [Runtime::InteropServices::Out] array<String^>^ mainColor,
		[Runtime::InteropServices::Out] array<String^>^ secondaryColor, [Runtime::InteropServices::Out] String^% red,
		[Runtime::InteropServices::Out] String^% yellow, [Runtime::InteropServices::Out] String^% green,
		[Runtime::InteropServices::Out] String^% cyan, [Runtime::InteropServices::Out] String^% blue,
		[Runtime::InteropServices::Out] String^% purple, [Runtime::InteropServices::Out] String^% black,
		[Runtime::InteropServices::Out] String^% gray, [Runtime::InteropServices::Out] String^% white)
	{
		List<List<String^>^>^ data = Core::Processor::processImage2(marshal_as<std::string>(path));

		luminocity = data[1][0];
		complexity = data[2][0];

		//mainColor = gcnew array<String^>(data[3]->Count);
		for (int i = 0; i < data[3]->Count; ++i)
			mainColor[i] = data[3][i];
		
		//secondaryColor = gcnew array<String^>(data[4]->Count);
		for (int i = 0; i < data[4]->Count; ++i)
			secondaryColor[i] = data[4][i];
		
		red = data[5][0];
		yellow = data[6][0];
		green = data[7][0];
		cyan = data[8][0];
		blue = data[9][0];
		purple = data[10][0];
		black = data[11][0];
		gray = data[12][0];
		white = data[13][0];
	}
}