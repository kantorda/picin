#pragma once
#include <string>
#include <filesystem>
#include  <fstream>
#include <queue>
#include <ctime>
#include <mutex>

namespace fs = std::experimental::filesystem;

class Logger
{
public:
	enum Level
	{
		Info,
		Error
	};

	Logger();
	~Logger();
	static void write(Level level, std::string msg);
	static std::mutex logMtx;

private:
	struct Message
	{
		time_t timeNow;
		Level level;
		std::string msg;
	};

	const std::string logDir = fs::current_path().string() + "\\..\\..\\..\\..\\logs\\";
	const std::string logFile = logDir + "log.txt";
	static std::fstream log;
	static std::queue<Message>* msgQueue;
	static bool live;
	void worker();
	static void writeMsg();
};
