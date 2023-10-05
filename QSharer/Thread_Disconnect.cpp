#include "Thread_Disconnect.h"

Thread_Disconnect::Thread_Disconnect(QString key) : QThread()
{
	KEY = key;
	hf = new HostNetlib();
	sf = new Sharing();
}

Thread_Disconnect::~Thread_Disconnect()
{
	hf->ExitHostedNetWork();
}

void Thread_Disconnect::run(void)
{
	stopHost(KEY);
	unshareHost();

	emit dSuccess();
}

const char *Thread_Disconnect::QStrToChar(QString str)
{
	QByteArray ba = str.toLatin1();
	char *chStr = (char *)malloc(ba.length() + 1);

	memset(chStr, 0, ba.length());
	memcpy(chStr, ba.data(), ba.length());
	chStr[ba.length()] = '\0';

	return chStr;
}

void Thread_Disconnect::stopHost(QString key)
{

	bool isIDLE = false;
	bool stopFailed = false;
	bool timeOut = false;
	int TryTimes = 0;
	int MaxTryTimes = 3;

	do
	{
		if (hf->StopHostedNetWork() != 0)
		{
			stopFailed = true;
			break;
		}
		TryTimes++;
		timeOut = (TryTimes > MaxTryTimes);
		isIDLE = (hf->HostedNetworkOn() == -3);

	} while (!isIDLE && !timeOut);

	if (timeOut || stopFailed)
	{
		emit FailedList_Dis(0); // throw QString("Failed to stop hosted network!");
		terminate();
	}

	const char *password = QStrToChar(key);

	if (hf->SetKEY(password) != 0)
	{
		emit FailedList_Dis(1); // throw QString("Failed to reset key!");
		terminate();
	}
}

void Thread_Disconnect::unshareHost()
{

	if (sf->StopSharing() != 0)
	{
		emit FailedList_Dis(2); // throw QString("Failed to unshare hosted network!");
		terminate();
	}
}
