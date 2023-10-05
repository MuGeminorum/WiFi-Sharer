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

class Thread_Create : public QThread
{
	Q_OBJECT

public:
	Thread_Create(QString, QString, QString);
	~Thread_Create();

signals:
	void FailedList_Create(int);
	void cSuccess(int);

protected:
	void run(void);

private:
	const char *QStrToChar(QString);
	void initHost(void);
	void stopPrevHost(void);
	void setHost(QString, QString);
	void startHost(void);
	void unsharePrevHost(void);
	void shareHost(void);

	HostNetlib *hf;
	Sharing *sf;

	QString SSID;
	QString KEY;
	QString SrcDevice;
};
