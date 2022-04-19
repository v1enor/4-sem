// ChildView.h : interface of the CChildView class
//


#pragma once


// CChildView window

class CChildView : public CWnd
{
// Construction
public:
	CChildView();

// Attributes ///////////////////////////////////////////////////
public:
	HGLRC		m_hRC;				// Контекст OpenGL
	HDC			m_hdc; 		   	// Контекст Windows
	int Index;
	GLint left,right,top,bottom; // Для определения области видимости графических
                                 //данных после проектирования в СКН
	float angle;    // Угол для поворота треугольника, град

// Operations ////////////////////////////////////////////////////
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
	afx_msg void OnTriangle();

	void Triangle();	////////////////////////////////////////////////

	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnDestroy();
	afx_msg void OnSize(UINT nType, int cx, int cy);
	//afx_msg BOOL OnEraseBkgnd(CDC* pDC);
};

