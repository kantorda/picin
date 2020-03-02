#include "pch.h"

namespace fs = std::filesystem;

void Tools::printStatistics(Core::Image img, std::string filePath)
{
	const size_t targetChar = filePath.find_last_of('\\');
	const size_t periodLocation = filePath.find_last_of('.');
	const std::string fileName = filePath.substr(targetChar, (periodLocation - targetChar));

	const std::string logDir = fs::current_path().string() + R"(\..\..\..\..\logs\)";
	const std::string outFilePath = logDir + fileName + "_matrix.txt";

	if (!fs::exists(fs::path(logDir)))
		fs::create_directory(fs::path(logDir));

	std::ofstream oFile(outFilePath);
	if (!oFile.is_open())
		oFile.open(outFilePath);
	oFile << "Analysis of file, " << filePath << "\n";
	oFile << "Elapsed time: " << img.getTime() << "\n";
	oFile << "Number processed pixels: " << img.pixels.count << "\n";
	oFile << "Number of unprocessed pixels: " << img.stats.numBadPixels << "\n";
	oFile << "Luminocity: ";
	if (img.stats.brightness == Core::bright)
		oFile << "Bright\n";
	else if (img.stats.brightness == Core::neutral)
		oFile << "Neutral\n";
	else
		oFile << "Dark\n";
	oFile << "Summary\n";
	oFile << "Complexity: " << img.stats.complexity << "\n";
	oFile << "Main Colors: ";
	for (Core::Colors color : img.stats.mainColors)
		oFile << Core::ColorsString[color] << ", ";
	oFile << std::endl;
	oFile << "Secondary Colors: ";
	for (Core::Colors color : img.stats.secondaryColors)
		oFile << Core::ColorsString[color] << ", ";
	oFile << std::endl;
	oFile << "Percentage of image by color:\n";
	oFile << "Red: " << img.stats.colorRatio[Core::red] << "\n";
	oFile << "Yellow: " << img.stats.colorRatio[Core::yellow] << "\n";
	oFile << "Green: " << img.stats.colorRatio[Core::green] << "\n";
	oFile << "Cyan: " << img.stats.colorRatio[Core::cyan] << "\n";
	oFile << "Blue: " << img.stats.colorRatio[Core::blue] << "\n";
	oFile << "Purple: " << img.stats.colorRatio[Core::purple] << "\n";
	oFile << "Black: " << img.stats.colorRatio[Core::black] << "\n";
	oFile << "Gray: " << img.stats.colorRatio[Core::gray] << "\n";
	oFile << "White: " << img.stats.colorRatio[Core::white] << "\n";
	oFile.flush();
}
