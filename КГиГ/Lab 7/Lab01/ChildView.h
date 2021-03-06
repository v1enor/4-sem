#pragma once
	
// ChildView.h: интерфейс класса CChildView
// Окно CChildView
class CChildView : public CWnd
{
// Создание - конструктор.
public:
	CChildView();

// Атрибуты
public:
	// Объект пирамиды.
	CPyramid PIR;
	// Область в окне, в котором происходит рисование пирамиды.
	CRect WinRect;
	// Точка наблюдения в сферической СК. Задается матрицей.
	CMatrix PView;
	int Index;

// Операции
public:

// Переопределение
protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

// Реализация
public:
	virtual ~CChildView();

// Созданные функции схемы сообщений
protected:
	afx_msg void OnPaint();
	DECLARE_MESSAGE_MAP()
public:
// Действия при выборе пункта меню
	afx_msg void OnPyramid();
	afx_msg void OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags);
	afx_msg void OnSize(UINT nType, int cx, int cy);
};
