#include "CVEngine.h"

namespace CVEngine
{
	CVEngine::CVEngine() {}

	void CVEngine::showImage(String^ filePath)
	{
		return m_Instance->showImage(string_to_char_array(filePath));
	}

	CVTools::CVTools() {}

	void CVTools::printMat(String^ filePath)
	{
		return m_Instance->printMat(string_to_char_array(filePath));
	}
}