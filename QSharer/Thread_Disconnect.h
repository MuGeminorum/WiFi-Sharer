#ifdef QT_DEBUG
#pragma comment (lib,"qtmaind.lib")
#pragma comment (lib,"Qt5Cored.lib")
#pragma comment (lib,"Qt5Guid.lib")
#pragma comment (lib,"Qt5Widgetsd.lib")
#endif

#pragma once
#include <QtWidgets>
#include "HostNetlib.h"
#include "Sharing.h"

class Thread_Disconnect : public QThread
{
	Q_OBJECT

protected:
	void run(void);

public:
	Thread_Disconnect(QString);
	~Thread_Disconnect();

signals:

	void FailedList_Dis(int);
	void dSuccess(void);

private:
	const char *QStrToChar(QString str);

	void stopHost(QString);
	void unshareHost(void);

	HostNetlib *hf;
	Sharing *sf;

	QString KEY;
};
