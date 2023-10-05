#include "qsharer.h"
#include <QtWidgets/QApplication>

#ifdef QT_NO_DEBUG
Q_IMPORT_PLUGIN(QWindowsIntegrationPlugin);
#endif

int main(int argc, char *argv[])
{
	QApplication a(argc, argv);
	QSharer w;
	w.show();
	return a.exec();
}
