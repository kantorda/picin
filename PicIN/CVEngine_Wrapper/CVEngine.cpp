#include "CVEngine.h"

namespace CVEngine
{
	CVEngine::CVEngine() {}

	void CVEngine::showImage(String^ filePath)
	{
		return m_Instance->showImage(string_to_char_array(filePath));
	}

	const char* CVEngine::infrastructureTest(String^ data)
	{
		return m_Instance->infrastructureTest(string_to_char_array(data));
	}
}