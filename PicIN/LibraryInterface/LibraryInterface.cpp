#include "pch.h"

#include "LibraryInterface.h"
#include <string.h>

namespace LibraryInterface {
	String^ Interface2::Test(String^ input)
	{
		String^ output = gcnew String("your input was ");
		return output + input;
	}
}