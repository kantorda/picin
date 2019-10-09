#include "pch.h"

#include "LibraryInterface.h"
#include <string.h>

namespace LibraryInterface {
	Void Interface2::Test(String^ input, [Runtime::InteropServices::Out] String^% output)
	{
		output = gcnew String("your input was " + input);
		//return output + input;
	}
}