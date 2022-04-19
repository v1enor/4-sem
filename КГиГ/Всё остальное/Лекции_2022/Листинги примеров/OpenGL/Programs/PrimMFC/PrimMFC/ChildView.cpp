// ChildView.cpp : implementation of the CChildView class
//

#include "stdafx.h"
#include "PrimMFC.h"
#include "ChildView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CChildView

CChildView::CChildView()
{
	Index=0;
	angle=0;
}

CChildView::~CChildView()
{
}

///////////// Triangle ///////////////////////////
void CChildView::Triangle()
{       
	glBegin(GL_LINE_LOOP); 
	  glVertex2f(-5.0,-5.0); 
	  glVertex2f(0.0,5.0); 
	  glVertex2f(5.0,-5.0); 
	glEnd(); 	
}
///////////////////////////////////////////////////

BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
	ON_COMMAND(ID_32771, &CChildView::OnTriangle)
	ON_WM_CREATE()
	ON_WM_DESTROY()
	ON_WM_SIZE()
	//ON_WM_ERASEBKGND()
END_MESSAGE_MAP()

// CChildView message handlers

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;


//====== Добавляем биты стиля, нужные OpenGL ===============================

	cs.style |= WS_CLIPSIBLINGS | WS_CLIPCHILDREN;

//==========================================================================

	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
		::LoadCursor(NULL, IDC_ARROW), reinterpret_cast<HBRUSH>(COLOR_WINDOW+1), NULL);

	return TRUE;
}

void CChildView::OnPaint() 
{
	CPaintDC dc(this); // device context for painting
	
	if(Index==1)
	{
		glClearColor(0.0,0.0,0.0,0.0); //Цвет фона в окне
		glClear(GL_COLOR_BUFFER_BIT);  // Очистить буфер цвета - залить цветом фона		
		glColor3ub(255,255,0);	// Цвет линии 
		glLineWidth(3.0) ;	    // Толщина линии

		glMatrixMode(GL_MODELVIEW); // Видовая матрица
		glLoadIdentity(); 
		glRotatef(angle,0.0,0.0,1.0); //  
				
		glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
		glLoadIdentity(); 
		left=-10; right=10; bottom=-10; top=10;
		gluOrtho2D(left, right, bottom, top); // (left,bottom)- (right,top)
		Triangle();  // Треугольник
		
		SwapBuffers(m_hdc); //Переключение буферов

	}
}


void CChildView::OnTriangle()
{
	Index=1;
	Invalidate();
}

int CChildView::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	// TODO:  Add your specialized creation code here

PIXELFORMATDESCRIPTOR pfd =	// Описатель формата
	{
		sizeof(PIXELFORMATDESCRIPTOR),// Размер структуры
		1,							// Номер версии
		PFD_DRAW_TO_WINDOW |	// Поддержка GDI
		PFD_SUPPORT_OPENGL |	// Поддержка OpenGL
		PFD_DOUBLEBUFFER,		  // Двойная буферизация
		PFD_TYPE_RGBA,		  	// Формат RGBA, не палитра
		24, 					    	// Количество плоскостей
		 						      	// в каждом буфере цвета
		24,	0,						// Для компоненты Red
		24,	0,						// Для компоненты Green
		24,	0,						// Для компоненты Blue
		24,	0,						// Для компоненты Alpha
		0,						  	// Количество плоскостей
									    // буфера Accumulation
		0,			 				// То же для компоненты Red
		0,			 				// для компоненты Green
		0,							// для компоненты Blue
		0,							// для компоненты Alpha
		32, 						// Глубина Z-буфера
		0,							// Глубина буфера Stencil
		0,							// Глубина буфера Auxiliary
		0,				 			// Теперь игнорируется
		0,							// Количество плоскостей
		0,							// Теперь игнорируется
		0,							// Цвет прозрачной маски
		0							  // Теперь игнорируется
	};

	//====== Добываем дежурный контекст
	m_hdc = ::GetDC(GetSafeHwnd());

	//====== Просим выбрать ближайший совместимый формат
	int iD = ChoosePixelFormat(m_hdc, &pfd);
	if ( !iD )
	{
		MessageBox("ChoosePixelFormat::Error");
		return -1;
	}

	//====== Пытаемся установить этот формат
	if ( !SetPixelFormat (m_hdc, iD, &pfd) )
	{
		MessageBox("SetPixelFormat::Error");
		return -1;
	}

	//====== Пытаемся создать контекст передачи OpenGL
	if ( !(m_hRC = wglCreateContext (m_hdc)))
	{
		MessageBox("wglCreateContext::Error");
		return -1;
	}

	//====== Пытаемся выбрать его в качестве текущего
	if ( !wglMakeCurrent (m_hdc, m_hRC))
	{
		MessageBox("wglMakeCurrent::Error");
		return -1;
	}

	return 0;
}

void CChildView::OnDestroy()
{
	CWnd::OnDestroy();

	// TODO: Add your message handler code here
	//====== Отсоединяем кнтекст от потока
	wglMakeCurrent(0, 0);

	//====== Удаляем контекст
	if (m_hRC)
	{
		wglDeleteContext(m_hRC);
		m_hRC = 0;
	}
}

void CChildView::OnSize(UINT nType, int cx, int cy)
{
	CWnd::OnSize(nType, cx, cy);

	// TODO: Add your message handler code here

	//====== Установка прямоугольника просмотра
	glViewport(0, 0, cx, cy);
}
