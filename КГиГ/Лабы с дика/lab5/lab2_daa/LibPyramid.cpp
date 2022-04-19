#include "stdafx.h"
#include "LibPyramid.h"
#include "CMatrix.h"
#include "LibGraph.h"
CPyramid::CPyramid()
{
	Vertices.RedimMatrix(4,8);	
	// Координаты вершин - столбцы							
	Vertices(0,0)=6;		// A: x=6,y=0,z=0
	Vertices(0,3)=2;		// D: x=2,y=0,z=6
	Vertices(2,3)=6;		

	Vertices(1,1)=-6;		// B: x=0,y=-6,z=0
	Vertices(1,4)=-2;		// E: x=0,y=-2,z=6
	Vertices(2,4)=6;		

	Vertices(0,2)=-6;		// C: x=-6,y=0,z=0
	Vertices(0,5)=-2;		// F: x=-2,y=0,z=6
	Vertices(2,5)=6;		
}

// Рисует пирамиду БЕЗ удаления невидимых ребер
void CPyramid::Draw(CDC& dc,CMatrix& PView,CRect& RW)
{
	CMatrix ViewCart=SphereToCart(PView);					// В декартовы координаты точки наблюдения
	CMatrix MV=CreateViewCoord(PView(0),PView(1),PView(2));	// Матрица пересчета из МСК в видовую СК 								
	CMatrix ViewVert=MV*Vertices;			// Координаты вершин пирамиды в видовой СК
	CRectD RectView;
	GetRect(ViewVert,RectView);				// Получаем охватывающий прямоугольник
	CMatrix MW=SpaceToWindow(RectView,RW);	// Матрица пересчета в ОСК
	// Готовим массив оконных координат для рисования                                          
	CPoint MasVert[6];						// Массив оконных координат вершин
	CMatrix V(3);
	V(2)=1;
	// Цикл по количеству вершин - вычисляем оконные координаты вершин
	for(int i=0;i<6;i++)		
	{
		V(0)=ViewVert(0,i);		// x
		V(1)=ViewVert(1,i);		// y		
		V=MW*V;					// Оконные координаты точки
		MasVert[i].x=(int)V(0);
		MasVert[i].y=(int)V(1);			
	}
	// Рисуем
	CPen Pen(PS_SOLID, 2, RGB(0, 0, 255));
	CPen* pOldPen =dc.SelectObject(&Pen);  
	dc.MoveTo(MasVert[2]);
	for(int i = 0; i < 3; i++) //нижнее основание
	{
		dc.LineTo(MasVert[i]);
	}
	dc.MoveTo(MasVert[5]);
	for(int i = 3; i < 6; i++) //верхнее основание
	{
		dc.LineTo(MasVert[i]);
	}	
	for(int i=0;i<3;i++)	//ребра
	{
		dc.MoveTo(MasVert[i]);	
		dc.LineTo(MasVert[i+3]);
	}

	// Координаты центра O 	пересечения диагоналей основания
	int A1x = (MasVert[1].x + MasVert[2].x) / 2;
	int A1y = (MasVert[1].y + MasVert[2].y) / 2;
	int B1x = (MasVert[0].x + MasVert[2].x) / 2;
	int B1y = (MasVert[0].y + MasVert[2].y) / 2;
	int C1x = (MasVert[1].x + MasVert[0].x) / 2;
	int C1y = (MasVert[1].y + MasVert[0].y) / 2;
	CPen Pen1(PS_DASH, 1, RGB(120, 60, 0));
	dc.SelectObject(&Pen1);
	dc.MoveTo(MasVert[0]);	// Перо на вершину A
	dc.LineTo(A1x, A1y);	// Диагональ
	dc.MoveTo(MasVert[1]);	// Перо на вершину B
	dc.LineTo(B1x, B1y);	// Диагональ
	dc.MoveTo(MasVert[2]);	// Перо на вершину C
	dc.LineTo(C1x, C1y);
	A1x = (MasVert[4].x + MasVert[5].x) / 2;
	A1y = (MasVert[4].y + MasVert[5].y) / 2;
	B1x = (MasVert[3].x + MasVert[5].x) / 2;
	B1y = (MasVert[3].y + MasVert[5].y) / 2;
	C1x = (MasVert[4].x + MasVert[3].x) / 2;
	C1y = (MasVert[4].y + MasVert[3].y) / 2;
	dc.MoveTo(MasVert[3]);	// Перо на вершину A
	dc.LineTo(A1x, A1y);	// Диагональ
	dc.MoveTo(MasVert[4]);	// Перо на вершину B
	dc.LineTo(B1x, B1y);	// Диагональ
	dc.MoveTo(MasVert[5]);	// Перо на вершину C
	dc.LineTo(C1x, C1y);
	dc.SelectObject(pOldPen);
}

void CPyramid::Draw1(CDC& dc,CMatrix& PView,CRect& RW)
{
	CMatrix ViewCart=SphereToCart(PView);
	CMatrix MV=CreateViewCoord(PView(0),PView(1),PView(2));	
	CMatrix ViewVert=MV*Vertices; 
	CRectD RectView;
	GetRect(ViewVert,RectView);		
	CMatrix MW=SpaceToWindow(RectView,RW);
                                          
	CPoint MasVert[6];
	CMatrix V(3);
	V(2)=1;	
	for(int i=0;i<6;i++)		
	{
		V(0)=ViewVert(0,i); // x
		V(1)=ViewVert(1,i); // y

		V=MW*V;	
		MasVert[i].x=(int)V(0);
		MasVert[i].y=(int)V(1);			
	}

	CPen Pen(PS_SOLID, 2, RGB(0, 0, 255));
	CPen* pOldPen = dc.SelectObject(&Pen);

	CBrush Brus(RGB(120, 60, 0));			// Для нижнего основания
	CBrush* pOldBrush =dc.SelectObject(&Brus);	

	CMatrix R1(3),R2(3),VN(3);
	double sm;
	for(int i=0;i<3;i++)					// рисуем ребра без невидимых
	{
		CMatrix VE=Vertices.GetCol(i + 3,0,2);
		int k;
		if(i==2) k=0;
		else k=i+1;
		R1=Vertices.GetCol(i,0,2);
		R2=Vertices.GetCol(k,0,2);
		CMatrix V1=R2-R1;			 
		CMatrix V2=VE-R1;			 
		VN=VectorMult(V2,V1);		 
		sm=ScalarMult(VN,ViewCart);  
		if (sm >= 0)
		{
			dc.MoveTo(MasVert[i]);			
			dc.LineTo(MasVert[k]);
			dc.LineTo(MasVert[k + 3]);
			dc.LineTo(MasVert[i + 3]);
			dc.LineTo(MasVert[i]);
		}
	}
	
	if(ViewCart(2)<0)
		dc.Polygon(MasVert, 3);	// нижнее основание
	else
	{
		CBrush *topBrush = new CBrush((COLORREF)0x1fffff);
		dc.SelectObject(topBrush);
		dc.Polygon(MasVert + 3, 3);	// верхнее основание
	}

	dc.SelectObject(pOldPen);
	dc.SelectObject(pOldBrush);
}

// Вычисляет координаты прямоугольника,охватывающего проекцию 
// пирамиды на плоскость XY в ВИДОВОЙ системе координат
void CPyramid::GetRect(CMatrix& Vert,CRectD& RectView)
{
	CMatrix V=Vert.GetRow(0);		// x - координаты
	double xMin=V.MinElement();
	double xMax=V.MaxElement();
	V=Vert.GetRow(1);				// y - координаты
	double yMin=V.MinElement();
	double yMax=V.MaxElement();
	RectView.SetRectD(xMin,yMax,xMax,yMin);
}
