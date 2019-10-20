#pragma once
#include "pch.h"

namespace Core
{
	const int RED_MIN = 165;
	const int RED_MAX = 15;
	const int YELLOW_MIN = 16;
	const int YELLOW_MAX = 44;
	const int GREEN_MIN = 45;
	const int GREEN_MAX = 75;
	const int CYAN_MIN = 76;
	const int CYAN_MAX = 104;
	const int BLUE_MIN = 105;
	const int BLUE_MAX = 135;
	const int MAGENTA_MIN = 136;
	const int MAGENTA_MAX = 164;
	const float MAIN_COLOR_THRESHOLD = 0.1;
	const float SECONDARY_COLOR_THRESHOLD = 0.02;

	enum Colors
	{
		red = 0,
		blue = 1,
		green = 2,
		cyan = 3,
		purple = 4,
		yellow = 5,
		black = 6,
		white = 7,
		gray = 8
	};
	static std::map<Colors, std::string> ColorsString
	{
		{red,"red"},
		{blue,"blue"},
		{green,"green"},
		{cyan,"cyan"},
		{purple,"purple"},
		{yellow,"yellow"},
		{black,"black"},
		{white,"white"},
		{gray,"gray"}
	};
	enum Luminocity
	{
		bright = 0,
		neutral = 1,
		dark = 2
	};
	struct Pixel
	{
		int hue, saturation, value;
	};
	struct Pixels
	{
		int count = 0;
		std::vector<int> colors{ 0,0,0,0,0,0,0,0,0 };
		std::vector<int> brightnessCount{ 0,0,0 };
	};
	struct Statistics
	{
		int numBadPixels = 0;
		float complexity = 0;
		Luminocity brightness;
		std::vector<float> colorRatio{ 0,0,0,0,0,0,0,0,0 };
		std::vector<Colors> mainColors;
		std::vector<Colors> secondaryColors;
	};

	using namespace System;
	using namespace System::Collections::Generic;
	using namespace msclr::interop;

	class Image
	{
	private:
		double tickCount = 0;
		double elapsedTime = 0;
		std::string path;
		const std::string DATA_SEPARATOR = "*";
		const std::string IMAGE_SEPARATOR = "*?*";
		cv::Mat mat;

		void timerRun();

	public:
		Pixels pixels;
		Statistics stats;

		Image();
		Image(cv::Mat mat, std::string path);
		~Image();

		void process();
		void processPixels();
		void calculateColor(int hue);
		void analyzeData();
		double getTime();
		std::string serialize();
		List<List<String^>^>^ serializeToList();
	};
}
