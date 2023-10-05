#ifdef QT_DEBUG
#pragma comment (lib,"qtmaind.lib")
#pragma comment (lib,"Qt5Cored.lib")
#pragma comment (lib,"Qt5Guid.lib")
#pragma comment (lib,"Qt5Widgetsd.lib")
#endif

#pragma once
#include <QStyledItemDelegate>

class QCommonDelegate : public QStyledItemDelegate
{

	Q_OBJECT

public:
	QCommonDelegate(QObject *parent);
	~QCommonDelegate();

private:

	void paint(QPainter *painter,
		const QStyleOptionViewItem &option, const QModelIndex &index) const;

};

