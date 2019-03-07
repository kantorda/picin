#include "Logger.h"
#include <thread>
#include <chrono>
#include <cassert>

Logger::Logger()
{
	if (!fs::exists(logDir))
		fs::create_directory(logDir);
	if (!log)
		log = std::fstream(logFile);
	else if (!log.is_open())
		log.open(logFile);
	if (msgQueue == nullptr)
		msgQueue = new std::queue<Message>;
	live = true;

	std::thread(worker());
}

Logger::~Logger()
{
	while (!msgQueue->empty())
		writeMsg();
	delete msgQueue;

	if (log.is_open())
	{
		log.flush();
		log.close();
	}
}

void Logger::write(Level level, std::string msg)
{
	time_t timeNow = time(0);
	msgQueue->push(Message{timeNow, level, msg});
}

void Logger::worker()
{
	while (true)
	{
		while (!logMtx.try_lock())
			std::this_thread::sleep_for(std::chrono::microseconds(10));
		if (!live)
		{
			logMtx.unlock();
			break;
		}
		if (cyclesDown >= 300)
		{
			writeMsg("ERROR!!!");
			writeMsg("Logger has been idle for 5 minutes.  Ending thread.");
			live = false;
			logMtx.unlock();
			break;
		}
		logMtx.unlock();

		if (msgQueue->empty())
		{
			++cyclesDown;
			std::this_thread::sleep_for(std::chrono::seconds(1));
		}
		else
		{
			writeMsg();
			cyclesDown = 0;
		}
	}
}

void Logger::writeMsg()
{
	assert(!msgQueue->empty());
	Message msg = msgQueue->front();
	
	if (msg.level == Level::Info)
		log << "(I)  ";
	else
		log << "(E)  ";

	tm buf;
	char timeS[26];

	log << asctime_s(timeS, sizeof timeS, (&msg.timeNow, &buf)) << "  ";
	log << msg.msg << '\n';

	msgQueue->pop();
}

void Logger::writeMsg(std::string msg)
{
	tm buf;
	char timeS[26];

	log << asctime_s(timeS, sizeof timeS, (time(0), &buf)) << "  ";
	log << msg << '\n';
}



