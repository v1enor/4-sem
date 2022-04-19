
// ChildView.cpp: реализация класса CChildView
//

#include "stdafx.h"
#include "Lab03.h"
#include "ChildView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CChildView

CChildView::CChildView()
{		
}

CChildView::~CChildView()
{
}

// Реализация карты сообщений
BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
	// сообщения меню выбора
	ON_COMMAND(ID_TESTS_F1, &CChildView::OnTestsF1)					
	ON_COMMAND(ID_TESTS_F2, &CChildView::OnTestsF2)		
	ON_COMMAND(ID_TESTS_F3, &CChildView::OnTestsF3)					
	ON_COMMAND(ID_TESTS_F4, &CChildView::OnTestsF4)
	ON_COMMAND(ID_TESTS_F1234, &CChildView::OnTestsF1234)

END_MESSAGE_MAP()



// Обработчики сообщений CChildView

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;
	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
		::LoadCursor(nullptr, IDC_ARROW), reinterpret_cast<HBRUSH>(COLOR_WINDOW+1), nullptr);

	return TRUE;
}

void CChildView::OnPaint() 
{
	CPaintDC dc(this); // контекст устройства для рисования

	if (Index == 1)		// режим отображения MM_TEXT
	{
		Graph.Draw(dc, 1, 1);
	}

	if (Index == 2)
	{
		Graph.GetRS(RS);
		SetMyMode(dc, RS, RW);				// Устанавливает режим отображения MM_ANISOTROPIC (можно выбирать Х и У и логич единицу)
		Graph.Draw1(dc, 1, 1);
		dc.SetMapMode(MM_TEXT);				// Устанавливает режим отображения MM_TEXT (напр Х вправо, напр У вниз, логич единица 1 пиксель)
	}
}

double CChildView::MyF1(double x)
{
	double y = sin(x) / x;
	return y;
}

double CChildView::MyF2(double x)
{
	double y = pow(x, 3);
	return y;
}

double CChildView::MyF3(double x)
{
	double y = sqrt(x) * sin(x);
	return y;
}

double CChildView::MyF4(double x)
{
	double y = x * x;
	return y;
}

void CChildView::OnTestsF1()	// MM_TEXT
{
	double Xl = -3 * pi;		// Координата Х левого угла области
	double Xh = -Xl;			// Координата Х правого угла области
	double dX = pi / 36;		// Шаг графика функции
	int N = (Xh - Xl) / dX;		// Количество точек графика
	X.RedimMatrix(N + 1);		// Создаем вектор с N+1 строками для хранения координат точек по Х
	Y.RedimMatrix(N + 1);		// Создаем вектор с N+1 строками для хранения координат точек по Y
	for (int i = 0; i <= N; i++)
	{
		X(i) = Xl + i * dX;		// Заполняем массивы/векторы значениями
		Y(i) = MyF1(X(i));
	}
	PenLine.Set(PS_SOLID, 1, RGB(255, 0, 0));	// Устанавливаем параметры пера для линий (сплошная линия, толщина 1, цвет красный)
	PenAxis.Set(PS_SOLID, 2, RGB(0, 0, 255));	// Устанавливаем параметры пера для осей (сплошная линия, толщина 2, цвет синий)
	RW.SetRect(100, 100, 500, 500);				// Установка параметров прямоугольной области для отображения графика в окне
	Graph.SetParams(X, Y, RW);					// Передаем векторы с координатами точек и область в окне
	Graph.SetPenLine(PenLine);					// Установка параметров пера для линии графика
	Graph.SetPenAxis(PenAxis);					// Установка параметров пера для линий осей 
	Index = 1;									// Помечаем для режима отображения MM_TEXT
	this->Invalidate();
}

void CChildView::OnTestsF2()
{
	double Xl = -5;
	double Xh = -Xl;
	double dX = 0.25;
	int N = (Xh - Xl) / dX;
	X.RedimMatrix(N + 1);
	Y.RedimMatrix(N + 1);
	for (int i = 0; i <= N; i++)
	{
		X(i) = Xl + i * dX;
		Y(i) = MyF2(X(i));
	}
	PenLine.Set(PS_SOLID, 1, RGB(0, 255, 0));
	PenAxis.Set(PS_SOLID, 2, RGB(0, 0, 255));
	RW.SetRect(100, 100, 500, 500);
	Graph.SetParams(X, Y, RW);
	Graph.SetPenLine(PenLine);
	Graph.SetPenAxis(PenAxis);
	Index = 1;									// Помечаем для режима отображения MM_ANISOTROPIC
	this->Invalidate();
}


void CChildView::OnTestsF3()
{
	double Xl = 0;
	double Xh = 6 * pi;
	double dX = pi / 36;
	int N = (Xh - Xl) / dX;
	X.RedimMatrix(N + 1);	
	Y.RedimMatrix(N + 1);
	for (int i = 0; i <= N; i++)
	{
		X(i) = Xl + i * dX;
		Y(i) = MyF3(X(i));
	}
	PenLine.Set(PS_DASHDOT, 1, RGB(255, 0, 0));		//
	PenAxis.Set(PS_SOLID, 2, RGB(0, 0, 0));
	RW.SetRect(100, 100, 500, 500);
	Graph.SetParams(X, Y, RW);
	Graph.SetPenLine(PenLine);
	Graph.SetPenAxis(PenAxis);
	Index = 1;
	this->Invalidate();
}


void CChildView::OnTestsF4()
{
	double Xl = -10;
	double Xh = -Xl;
	double dX = 0.25;
	int N = (Xh - Xl) / dX;
	X.RedimMatrix(N + 1);
	Y.RedimMatrix(N + 1);
	for (int i = 0; i <= N; i++)
	{
		X(i) = Xl + i * dX;
		Y(i) = MyF4(X(i));
	}
	PenLine.Set(PS_SOLID, 2, RGB(255, 0, 0));
	PenAxis.Set(PS_SOLID, 2, RGB(0, 0, 255));
	RW.SetRect(100, 100, 500, 500);
	Graph.SetParams(X, Y, RW);
	Graph.SetPenLine(PenLine);
	Graph.SetPenAxis(PenAxis);
	Index = 2;
	this->Invalidate();
}


void CChildView::OnTestsF1234()
{
	Invalidate();
	CPaintDC dc(this);
	double Xl = -3 * pi;
	double Xh = -Xl;
	double dX = pi / 36;
	int N = (Xh - Xl) / dX;
	X.RedimMatrix(N + 1);
	Y.RedimMatrix(N + 1);
	for (int i = 0; i <= N; i++)
	{
		X(i) = Xl + i * dX;
		Y(i) = MyF1(X(i));
	}
	PenLine.Set(PS_SOLID, 1, RGB(255, 0, 0));
	PenAxis.Set(PS_SOLID, 2, RGB(0, 0, 255));
	RW.SetRect(20, 10, 270, 260);
	Graph.SetParams(X, Y, RW);
	Graph.SetPenLine(PenLine);
	Graph.SetPenAxis(PenAxis);
	Graph.Draw(dc, 1, 1);

	Xl = -5;
	Xh = -Xl;
	dX = 0.25;
	N = (Xh - Xl) / dX;
	X.RedimMatrix(N + 1);
	Y.RedimMatrix(N + 1);
	for (int i = 0; i <= N; i++)
	{
		X(i) = Xl + i * dX;
		Y(i) = MyF2(X(i));
	}
	PenLine.Set(PS_SOLID, 1, RGB(0, 255, 0));
	PenAxis.Set(PS_SOLID, 2, RGB(0, 0, 255));
	RW.SetRect(290, 10, 540, 260);
	Graph.SetParams(X, Y, RW);
	Graph.SetPenLine(PenLine);
	Graph.SetPenAxis(PenAxis);
	Graph.Draw(dc, 1, 1);

	Xl = 0;
	Xh = 6 * pi;
	dX = pi / 36;
	N = (Xh - Xl) / dX;
	X.RedimMatrix(N + 1);	
	Y.RedimMatrix(N + 1);
	for (int i = 0; i <= N; i++)
	{
		X(i) = Xl + i * dX;
		Y(i) = MyF3(X(i));
	}
	PenLine.Set(PS_DASHDOT, 1, RGB(255, 0, 0));
	PenAxis.Set(PS_SOLID, 2, RGB(0, 0, 0));
	RW.SetRect(20, 280, 270, 530);
	Graph.SetParams(X, Y, RW);
	Graph.SetPenLine(PenLine);
	Graph.SetPenAxis(PenAxis);
	Graph.Draw(dc, 1, 1);

	Xl = -10;
	Xh = -Xl;
	dX = 0.25;
	N = (Xh - Xl) / dX;
	X.RedimMatrix(N + 1);
	Y.RedimMatrix(N + 1);
	for (int i = 0; i <= N; i++)
	{
		X(i) = Xl + i * dX;
		Y(i) = MyF4(X(i));
	}
	PenLine.Set(PS_SOLID, 2, RGB(255, 0, 0));
	PenAxis.Set(PS_SOLID, 2, RGB(0, 0, 255));
	RW.SetRect(290, 280, 540, 530);
	Graph.SetParams(X, Y, RW);
	Graph.SetPenLine(PenLine);
	Graph.SetPenAxis(PenAxis);
	Graph.Draw(dc, 1, 1);
}