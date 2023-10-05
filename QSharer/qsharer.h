#ifndef QSHARER_H
#define QSHARER_H
#pragma once
#include <QtWidgets>
#include "Sharing.h"
#include "HostNetlib.h"
#include "oui.h"

class QSharer : public QMainWindow
{
	Q_OBJECT

public:
	QSharer(QWidget *parent = 0);
	~QSharer();

private:
	QWidget *centralWidget;
	QTabWidget *tabWidget;
	QWidget *HotspotTab;
	QLineEdit *WifiNameEdit;
	QLabel *ClientLabel;
	QLabel *PassLabel;
	QPushButton *CreateButton;
	QLabel *ClientNumLabel;
	QLabel *WifiNameLabel;
	QLineEdit *PassEdit;
	QPushButton *DisconnectButton;
	QCheckBox *HideCheck;
	QLabel *comboLabel;
	QComboBox *comboBox;
	QWidget *DeviceTab;
	QTableView *listView;
	QTimer *Monitor;

	Sharing *sf;
	HostNetlib *hf;
	oui *ouf;

	void setupUi(QMainWindow *);
	void retranslateUi(QMainWindow *);
	void customizeUi(QMainWindow *);

public slots:
	void LoadSrcDevices(int);
	void createStart(void);
	void createFailed(int);
	void createFinished(int);
	void discStart(void);
	void discFailed(int);
	void discFinished(void);
	void HidePass(bool);
	void UpdClients(QStringList);
	void PassMinLength(QString);
};

#endif // QSHARER_H
