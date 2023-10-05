#include "Thread_Create.h"
#include "Thread_Disconnect.h"
#include "Timer_Monitor.h"
#include "QCommonDelegate.h"
#include "qsharer.h"

QSharer::QSharer(QWidget *parent) : QMainWindow(parent)
{
	hf = new HostNetlib();
	sf = new Sharing();
	ouf = new oui();

	QDesktopWidget *desktop = QApplication::desktop();
	int cX = (desktop->width() - this->width()) / 2;
	int cY = (desktop->height() - this->height()) / 2;
	this->move(cX, cY);
	setupUi(this);
}

QSharer::~QSharer()
{
}

void QSharer::setupUi(QMainWindow *QSharerClass)
{
	if (QSharerClass->objectName().isEmpty())
		QSharerClass->setObjectName(QStringLiteral("QSharerClass"));
	QSharerClass->resize(533, 372);
	QFont font;
	font.setFamily(QStringLiteral("Microsoft YaHei UI"));
	QSharerClass->setFont(font);
	QSharerClass->setLocale(QLocale(QLocale::English, QLocale::UnitedStates));
	centralWidget = new QWidget(QSharerClass);
	centralWidget->setObjectName(QStringLiteral("centralWidget"));
	tabWidget = new QTabWidget(centralWidget);
	tabWidget->setObjectName(QStringLiteral("tabWidget"));
	tabWidget->setGeometry(QRect(20, 20, 501, 341));
	HotspotTab = new QWidget();
	HotspotTab->setObjectName(QStringLiteral("HotspotTab"));
	WifiNameEdit = new QLineEdit(HotspotTab);
	WifiNameEdit->setObjectName(QStringLiteral("WifiNameEdit"));
	WifiNameEdit->setGeometry(QRect(240, 100, 161, 21));
	WifiNameEdit->setMaxLength(13);
	ClientLabel = new QLabel(HotspotTab);
	ClientLabel->setObjectName(QStringLiteral("ClientLabel"));
	ClientLabel->setGeometry(QRect(50, 40, 72, 15));
	ClientLabel->setLocale(QLocale(QLocale::English, QLocale::UnitedStates));
	PassLabel = new QLabel(HotspotTab);
	PassLabel->setObjectName(QStringLiteral("PassLabel"));
	PassLabel->setGeometry(QRect(50, 180, 90, 16));
	CreateButton = new QPushButton(HotspotTab);
	CreateButton->setObjectName(QStringLiteral("CreateButton"));
	CreateButton->setGeometry(QRect(50, 250, 100, 30));
	ClientNumLabel = new QLabel(HotspotTab);
	ClientNumLabel->setObjectName(QStringLiteral("ClientNumLabel"));
	ClientNumLabel->setGeometry(QRect(280, 40, 72, 15));
	ClientNumLabel->setAlignment(Qt::AlignCenter);
	WifiNameLabel = new QLabel(HotspotTab);
	WifiNameLabel->setObjectName(QStringLiteral("WifiNameLabel"));
	WifiNameLabel->setGeometry(QRect(50, 110, 110, 16));
	PassEdit = new QLineEdit(HotspotTab);
	PassEdit->setObjectName(QStringLiteral("PassEdit"));
	PassEdit->setGeometry(QRect(240, 170, 161, 21));
	PassEdit->setMaxLength(13);
	DisconnectButton = new QPushButton(HotspotTab);
	DisconnectButton->setObjectName(QStringLiteral("DisconnectButton"));
	DisconnectButton->setGeometry(QRect(290, 250, 100, 30));
	HideCheck = new QCheckBox(HotspotTab);
	HideCheck->setObjectName(QStringLiteral("HideCheck"));
	HideCheck->setGeometry(QRect(410, 170, 70, 20));
	tabWidget->addTab(HotspotTab, QString());
	DeviceTab = new QWidget();
	DeviceTab->setObjectName(QStringLiteral("DeviceTab"));
	listView = new QTableView(DeviceTab);
	listView->setObjectName(QStringLiteral("listView"));
	listView->setGeometry(QRect(20, 20, 441, 220)); // 20, 20, 441, 271

	comboLabel = new QLabel(DeviceTab);
	comboLabel->setGeometry(QRect(20, 250, 150, 22));
	comboBox = new QComboBox(DeviceTab);
	comboBox->setObjectName(QStringLiteral("comboBox"));
	comboBox->setGeometry(QRect(20, 280, 300, 22));
	LoadSrcDevices(1);

	tabWidget->addTab(DeviceTab, QString());
	QSharerClass->setCentralWidget(centralWidget);
	retranslateUi(QSharerClass);
	tabWidget->setCurrentIndex(0);
	QMetaObject::connectSlotsByName(QSharerClass);
} // setupUi

void QSharer::retranslateUi(QMainWindow *QSharerClass)
{
	QSharerClass->setWindowTitle(QApplication::translate("QSharerClass", "QSharer", 0));
	ClientLabel->setText(QApplication::translate("QSharerClass", "Clients:", 0));
	PassLabel->setText(QApplication::translate("QSharerClass", "Password:", 0));
	CreateButton->setText(QApplication::translate("QSharerClass", "Create", 0));
	ClientNumLabel->setText(QApplication::translate("QSharerClass", "--", 0));
	WifiNameLabel->setText(QApplication::translate("QSharerClass", "Wi-Fi Name:", 0));
	comboLabel->setText(QApplication::translate("QSharerClass", "Source Sharing Device:", 0));
	DisconnectButton->setText(QApplication::translate("QSharerClass", "Disconnect", 0));
	HideCheck->setText(QApplication::translate("QSharerClass", "Hide", 0));
	tabWidget->setTabText(tabWidget->indexOf(HotspotTab), QApplication::translate("QSharerClass", "Hotspot", 0));
	tabWidget->setTabText(tabWidget->indexOf(DeviceTab), QApplication::translate("QSharerClass", "Devices", 0));
	listView->setItemDelegate(new QCommonDelegate(this));
	listView->verticalHeader()->setVisible(false);
	listView->horizontalHeader()->setVisible(true);
	listView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
	listView->setShowGrid(false);

	QStandardItemModel *model = new QStandardItemModel(listView);
	model->setColumnCount(2);
	model->setHeaderData(0, Qt::Horizontal, "Partner");
	model->setHeaderData(1, Qt::Horizontal, "Mac Address");

	listView->setModel(model);
	customizeUi(QSharerClass);

} // retranslateUi

void QSharer::customizeUi(QMainWindow *QSharerClass)
{
	QSharerClass->setFixedSize(QSharerClass->width(), QSharerClass->height());
	Monitor = new Timer_Monitor(1000);
	QRegExp regx("[a-zA-Z0-9]+$");
	QValidator *validator = new QRegExpValidator(regx);
	WifiNameEdit->setValidator(validator);
	PassEdit->setValidator(validator);
	DisconnectButton->setEnabled(false);

	if (hf->InitHostedNetWork() == 0)
	{
		WifiNameEdit->setText(hf->GetSSID());
		PassEdit->setText(hf->GetKEY());
		hf->ExitHostedNetWork();
	}
	else
	{
		WifiNameEdit->setText(QObject::tr("WifiHotSpot"));
		PassEdit->setText(QString::number(12345678));
	}

	QObject::connect(CreateButton, SIGNAL(clicked()), this, SLOT(createStart()));
	QObject::connect(DisconnectButton, SIGNAL(clicked()), this, SLOT(discStart()));
	QObject::connect(HideCheck, SIGNAL(toggled(bool)), this, SLOT(HidePass(bool)));
	QObject::connect(PassEdit, SIGNAL(textEdited(QString)), this, SLOT(PassMinLength(QString)));

	QObject::connect(tabWidget, SIGNAL(currentChanged(int)), this, SLOT(LoadSrcDevices(int)));
}

void QSharer::createStart()
{
	tabWidget->setEnabled(false);

	QString wifiname = WifiNameEdit->text();
	QString pass = PassEdit->text();
	QString srcDev = comboBox->currentText();
	QThread *createWifi = new Thread_Create(wifiname, pass, srcDev);

	QObject::connect(createWifi, SIGNAL(FailedList_Create(int)), this, SLOT(createFailed(int)));
	QObject::connect(createWifi, SIGNAL(cSuccess(int)), this, SLOT(createFinished(int)));

	createWifi->start();
}

void QSharer::discStart()
{
	tabWidget->setEnabled(false);

	QString pass = PassEdit->text();
	QThread *discWifi = new Thread_Disconnect(pass);

	QObject::connect(discWifi, SIGNAL(FailedList_Disc(int)), this, SLOT(discFailed(int)));
	QObject::connect(discWifi, SIGNAL(dSuccess()), this, SLOT(discFinished()));

	discWifi->start();
}

void QSharer::createFailed(int e)
{
	tabWidget->setEnabled(true);

	switch (e)
	{
	case 0:
		QMessageBox::about(this, "Failed", "Failed to initiate hosted network!");
		break;
	case 1:
		QMessageBox::about(this, "Failed", "Wlan hosted network unavailable!");
		break;
	case 2:
		QMessageBox::about(this, "Failed", "Failed to stop previous hosted network!");
		break;
	case 3:
		QMessageBox::about(this, "Failed", "Failed to allow hosted network!");
		break;
	case 4:
		QMessageBox::about(this, "Failed", "Failed to set ssid!");
		break;
	case 5:
		QMessageBox::about(this, "Failed", "Failed to set key!");
		break;
	case 6:
		QMessageBox::about(this, "Failed", "Failed to start hosted network!");
		break;
	// case 7:  QMessageBox::about(this, "Failed", "Failed to unshare prev hosted network!");  break;
	case 7:
		QMessageBox::about(this, "Failed", "Failed to share hosted network!");
		break;
	default:
		QMessageBox::about(this, "Failed", "Unknown error!");
		break;
	}
}

void QSharer::discFailed(int e)
{
	tabWidget->setEnabled(true);

	switch (e)
	{
	case 0:
		QMessageBox::about(this, "Failed", "Failed to stop hosted network!");
		break;
	case 1:
		QMessageBox::about(this, "Failed", "Failed to reset key!");
		break;
	case 2:
		QMessageBox::about(this, "Failed", "Failed to unshare hosted network!");
		break;
	default:
		QMessageBox::about(this, "Failed", "Unknown error!");
		break;
	}
}

void QSharer::discFinished(void)
{
	QObject::disconnect(Monitor, SIGNAL(UpdMacList(QStringList)), this, SLOT(UpdClients(QStringList)));
	Monitor->stop();
	tabWidget->setEnabled(true);
	DisconnectButton->setEnabled(false);
	ClientNumLabel->setText("--");
}

void QSharer::createFinished(int s)
{
	tabWidget->setEnabled(true);
	DisconnectButton->setEnabled(true);

	ClientNumLabel->setNum(s);
	QObject::connect(Monitor, SIGNAL(UpdMacList(QStringList)), this, SLOT(UpdClients(QStringList)));
	Monitor->start();
}

void QSharer::HidePass(bool h)
{
	if (h)
	{
		PassEdit->setEchoMode(QLineEdit::Password);
	}
	else
	{
		PassEdit->setEchoMode(QLineEdit::Normal);
	}
}

void QSharer::UpdClients(QStringList mList)
{

	int PeerNum = mList.length();

	QStandardItemModel *model = new QStandardItemModel(listView);
	model->setColumnCount(2);
	model->setHeaderData(0, Qt::Horizontal, "Partner");
	model->setHeaderData(1, Qt::Horizontal, "Mac Address");

	for (int i = 0; i < PeerNum; i++)
	{
		QString Mac = mList.at(i);

		QStandardItem *CompanyId = new QStandardItem(ouf->getCompanyId(Mac));
		CompanyId->setTextAlignment(Qt::AlignCenter);
		model->setItem(i, 0, CompanyId);

		QStandardItem *mAddress = new QStandardItem(Mac);
		mAddress->setEditable(false);
		mAddress->setTextAlignment(Qt::AlignCenter);
		model->setItem(i, 1, mAddress);
	}

	ClientNumLabel->setNum(PeerNum);
	listView->setModel(model);
}

void QSharer::PassMinLength(QString pass)
{
	int pl = pass.length();
	CreateButton->setEnabled((pl >= 8 && pl <= 13));
}

void QSharer::LoadSrcDevices(int tabid)
{
	if (tabid == 1)
	{
		comboBox->clear();
		comboBox->insertItems(0, sf->LoadSrc());
	}
}