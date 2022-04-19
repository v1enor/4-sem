// ChildView.h : interface of the CChildView class
//


#pragma once


// CChildView window

class CChildView : public CWnd
{
// Construction
public:
	CChildView();
	int Index;
	HBITMAP Bit;

// Attributes
public:

// Operations
public:

// Overrides
	protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

// Implementation
public:
	virtual ~CChildView();

	// Generated message map functions
protected:
	afx_msg void OnPaint();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnFileLoadfile();
	afx_msg void OnFileSavefile();
	afx_msg void OnFileClear();
	afx_msg void OnFileLoadpict();
};

//////////////////// ‘”Õ ÷»»  ///////////////////////////////////////////////////////


int ShowBitMap(HWND hWnd,HBITMAP Bit,int x,int y);

int ClientToBmp(HWND hWnd,char *Name);



