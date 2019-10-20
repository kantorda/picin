// pch.h: This is a precompiled header file.
// Files listed below are compiled only once, improving build performance for future builds.
// This also affects IntelliSense performance, including code completion and many code browsing features.
// However, files listed here are ALL re-compiled if any one of them is updated between builds.
// Do not add files here that you will be updating frequently as this negates the performance advantage.

#ifndef PCH_H
#define PCH_H

// add headers that you want to pre-compile here

#pragma region C++ 
#include <vector>
#include <map>
#include <string>
#include <filesystem>
#include <vector>
#include <thread>
#include <filesystem>
#include <fstream>
#pragma endregion

#pragma region C++/CLI
#include <msclr\marshal_cppstd.h>
#pragma endregion

#pragma region OpenCV
#include <opencv2/core/mat.hpp>
#include <opencv2/shape/hist_cost.hpp>
#include "opencv2/opencv.hpp"
#include <opencv2/highgui.hpp>
#pragma endregion

#pragma region Internal
#include "Image.h"
#include "Processor.h"
#include "Tools.h"
#include "LibraryInterface.h"
#include "Tools.h"
#pragma endregion

#endif //PCH_H
