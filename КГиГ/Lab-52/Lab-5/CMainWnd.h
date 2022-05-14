#pragma once
#include "resource.h"
#include "CMatrix.h"
#include "LibGraph.h"
#include "LibPyramid.h"


class CMainWnd : public CFrameWnd
{
private:
	CPyramid PIR; 
	CRect WinRect;
	CMatrix PView;
	int Index;
	CMenu menu;
	DECLARE_MESSAGE_MAP()
	int OnCreate(LPCREATESTRUCT);

public:
	CMainWnd::CMainWnd() 
	{
		Create(NULL, L"Lab-5", WS_OVERLAPPEDWINDOW, CRect(10, 10, 700, 700), NULL, NULL);
		Index = 0;
		PView.RedimMatrix(3);
		PView(0) = 10; PView(1) = 300; PView(2) = 135;
	}

	void OnPaint();
	void OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags);
	void OnSize(UINT nType, int cx, int cy);
	void OnPuramid1();
	void OnPuramid2();
	void Exit();
};

BEGIN_MESSAGE_MAP(CMainWnd, CFrameWnd)
	ON_WM_CREATE()
	ON_WM_PAINT()
	ON_WM_KEYDOWN()
	ON_WM_SIZE()
	ON_COMMAND(ID_30002, OnPuramid1)
	ON_COMMAND(ID_30003, OnPuramid2)
	ON_COMMAND(ID_EXIT, Exit)
END_MESSAGE_MAP()
int CMainWnd::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;
	menu.LoadMenu(IDR_MENU1);
	SetMenu(&menu);
	return 0;
}


void CMainWnd::OnPaint()
{
	CPaintDC dc(this);
	if (Index == 1) 
		PIR.Draw(dc, PView, WinRect);
	if (Index == 2)
		PIR.Draw1(dc, PView, WinRect);
}

void CMainWnd::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)
{
	if ((Index == 1) || (Index == 2))
	{
		switch (nChar)
		{
		case VK_UP:
		{
			double d = PView(2) - 1;
			PView(2) = d;
			break;
		}
		case VK_DOWN:
		{
			double d = PView(2) + 1;
			PView(2) = d;
			break;
		}
		case VK_LEFT:
		{
			double d = PView(1) - 1;
			PView(1) = d;
			break;
		}
		case VK_RIGHT:
		{
			double d = PView(1) + 1;
			PView(1) = d;
		}
		}
		Invalidate();
	}
	CWnd::OnKeyDown(nChar, nRepCnt, nFlags);
}
void CMainWnd::OnSize(UINT nType, int cx, int cy)//При изменении окна пересчитывается масштаб
{
	CWnd::OnSize(nType, cx, cy);
	WinRect.SetRect(100, 100, cx - 100, cy - 100);
}
void CMainWnd::OnPuramid1()
{
	Index = 1;
	Invalidate();
}
void CMainWnd::OnPuramid2()
{
	Index = 2;
	Invalidate();
}
void CMainWnd::Exit()
{
	DestroyWindow();
}