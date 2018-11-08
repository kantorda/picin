#include "Image.h"
#include <opencv2/shape/hist_cost.hpp>

Core::Image::Image() : stats() {}

Core::Image::Image(cv::Mat mat) : mat(mat) {}

Core::Image::~Image() {}

void Core::Image::timerRun()
{
	// If tickCount == 0, timer has not been initialized
	// Start timer
	if (tickCount == 0)
		tickCount = (double)cv::getTickCount();

	// Else, stop timer and calculate elapsed time
	else
	{
		elapsedTime = (cv::getTickCount() - tickCount) / cv::getTickFrequency();
		tickCount = 0;
	}
}

void Core::Image::process()
{
	timerRun();

	// Convert from BGR to HSV
	cv::cvtColor(mat, mat, cv::COLOR_BGR2HSV);

	processPixels();

	analyzeData();

	timerRun();
}

void Core::Image::processPixels()
{
	int nRows = mat.rows;
	int nCols = mat.cols * mat.channels();

	if (mat.isContinuous())
	{
		nCols *= nRows;
		nRows = 1;
	}

	uchar* linePtr;
	for (int i = 0; i < nRows; ++i)
	{
		Pixel pxl;
		linePtr = mat.ptr<uchar>(i);
		for (int j = 0; j < nCols; )
		{
			try
			{
				// Extract tri-channel data
				pxl.hue = linePtr[j++];
				pxl.saturation = linePtr[j++];
				pxl.value = linePtr[j++];

				// extract color data
				if (pxl.value <= 85)							// black
				{
					++pixels.colors[black];
					++pixels.brightnessCount[dark];
				}
				else if (pxl.value <= 170)
				{
					if (pxl.saturation <= 85)					// gray
						++pixels.colors[gray];
					else										// neutral value hue
						calculateColor(pxl.hue);
					++pixels.brightnessCount[neutral];
				}
				else
				{
					if (pxl.saturation <= 85)					// white
						++pixels.colors[white];
					else										// bright hue
						calculateColor(pxl.hue);
					++pixels.brightnessCount[bright];
				}

				++pixels.count;
			}
			catch (_exception e) { ++stats.numBadPixels; }
		}
	}
}

void Core::Image::calculateColor(int hue)
{
	if (RED_MIN <= hue && hue <= RED_MAX)
		++pixels.colors[red];
	else if (hue <= YELLOW_MAX)
		++pixels.colors[yellow];
	else if (hue <= GREEN_MAX)
		++pixels.colors[green];
	else if (hue <= CYAN_MAX)
		++pixels.colors[cyan];
	else if (hue <= BLUE_MAX)
		++pixels.colors[blue];
	else if (hue <= MAGENTA_MAX)
		++pixels.colors[purple];
	else
		++stats.numBadPixels;
}

void Core::Image::analyzeData()
{
	// brightness
	if (pixels.brightnessCount[neutral] < pixels.brightnessCount[dark] &&
		pixels.brightnessCount[bright] < pixels.brightnessCount[dark])
		stats.brightness = dark;
	else if (pixels.brightnessCount[bright] < pixels.brightnessCount[neutral])
		stats.brightness = neutral;
	else
		stats.brightness = bright;

	for (int i = 0; i < pixels.colors.size(); ++i)
	{
		// % of image taken by each color
		stats.colorRatio[i] = (float)pixels.colors[i] / (float)pixels.count;
		// summary
		if (stats.colorRatio[i] >= 0.15)
		{
			stats.mainColors.push_back(Colors(i));
			stats.complexity += 1;					// main colors increase complexity by 1
		}
		else if (stats.colorRatio[i] >= 0.5)
		{
			stats.secondaryColors.push_back((Colors(i)));
			stats.complexity += 0.5;				// secondary colors increase complexity by 0.5
		}
	}
}

double Core::Image::getTime()
{
	return elapsedTime;
}
