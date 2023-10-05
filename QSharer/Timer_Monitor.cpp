#include "Timer_Monitor.h"


Timer_Monitor::Timer_Monitor(int ms) : QTimer()
{
	setInterval(ms);
	hf.InitHostedNetWork();
}


Timer_Monitor::~Timer_Monitor()
{
	hf.ExitHostedNetWork();
}

void Timer_Monitor::timerEvent(QTimerEvent *e)
{ 

	lPeerNum = cPeerNum;
	cPeerNum = hf.GetPeerNumber(); 

	if (cPeerNum >= 0 && lPeerNum != cPeerNum) emit UpdMacList(getMacList(cPeerNum));

}

QStringList Timer_Monitor::getMacList(int PeerNum)
{ 

	QStringList num;

	if (PeerNum > 0)
	{ 

		for (int i = 0; i < PeerNum; i++)
		{
			QString newItem = hf.GetMacAt(i);
			num = num << newItem;
		}

	}

	return num;
}