#include "QCommonDelegate.h"


QCommonDelegate::QCommonDelegate(QObject *parent)
{
}


QCommonDelegate::~QCommonDelegate()
{
}

void QCommonDelegate::paint(QPainter *painter,
	const QStyleOptionViewItem &option, const QModelIndex &index) const
{
	QStyleOptionViewItem viewOption(option);
	initStyleOption(&viewOption, index);
	if (option.state.testFlag(QStyle::State_HasFocus))
	{
		viewOption.state = viewOption.state ^ QStyle::State_HasFocus;
	}
	QStyledItemDelegate::paint(painter, viewOption, index);
}