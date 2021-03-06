#include "stdafx.h"
#include "Lab07.h"
#include "ChildView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// ChildView.cpp: реализация класса CChildView

// Реализация карты сообщений.
// Подробнее - http://www.codenet.ru/progr/visualc/mfc/mfc3.php.
BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
	// Меню выбора команд.
	ON_COMMAND(ID_Pyramid_Color, &CChildView::OnPyramid)
	ON_WM_KEYDOWN()
	// Изменение окна.
	ON_WM_SIZE()
END_MESSAGE_MAP()

// CChildView
CChildView::CChildView()
{		
	Index = 0;				// начальный индекс
	PView.RedimMatrix(3);	// матрица для точки камеры для наблюдении
}
CChildView::~CChildView() { }

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

// Данная функция вызывается при каждом изменении окна.
void CChildView::OnSize(UINT nType, int cx, int cy)
{
	CWnd::OnSize(nType, cx, cy);				// для динамического изменения окна
	WinRect.SetRect(50, 50, cx - 50, cy - 50);	// параметры окна рисования
}

void CChildView::OnPyramid()
{
	CFrameWnd* pWnd = GetParentFrame(); // Получаем родительское рамочное окно.

	// Задаем начальную точку наблюдения в сферической системе координат.
	// PView(0) - r.
	PView(0) = 10;
	// PView(1) - φ.
	PView(1) = 20;
	// PView(2) - θ.
	PView(2) = 110;

	Index = 4;
	Invalidate();
}

void CChildView::OnPaint()
{
	// Контекст устройства для рисования.
	CPaintDC dc(this);

	if (Index == 4)					// для варианта с падением света
		PIR.ColorDraw(				// параметры для падения цвета
			dc,						// контекст рисования
			PView,					// к-ты точки камеры для наблюдения
			WinRect,				// параметры окна рисования
			RGB(128, 236, 158));	// основной цвет пирамиды без учета теней
}

void CChildView::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)
{
		if (Index == 4)
	{
		switch (nChar)
		{
		case VK_UP:
		{
			double d = PView(2) - 1;
			if (d >= 0)PView(2) = d;
			break;
		}
		case VK_DOWN:
		{
			double d = PView(2) + 1;
			if (d <= 180)PView(2) = d;
			break;
		}
		case VK_LEFT:
		{
			double d = PView(1) - 1;
			if (d >= -180)PView(1) = d;
			else PView(1) = d + 360;
			break;
		}
		case VK_RIGHT:
		{
			double d = PView(1) + 1;
			if (d <= 180)PView(1) = d;
			else PView(1) = d - 360;
			break;
		}
		}
		Invalidate();
	}
	CWnd::OnKeyDown(nChar, nRepCnt, nFlags);
}