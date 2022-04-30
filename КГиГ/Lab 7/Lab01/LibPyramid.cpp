#include "stdafx.h"
#include <iostream>

CPyramid::CPyramid()
{
	// 
	Vertices.RedimMatrix(4, 6);
	// Координаты вершин - столбцы
	Vertices(0, 2) = 3;
	Vertices(0, 5) = 1;
	Vertices(1, 0) = 3;	
	Vertices(1, 3) = 1;	
	Vertices(2, 3) = 3;
	Vertices(2, 4) = 3;
	Vertices(2, 5) = 3;
	for (int i = 0; i < 6; i++)
		Vertices(3, i) = 1;
}

void CPyramid::ColorDraw(CDC& dc, CMatrix& PView, CRect& RW, COLORREF Color)
{
	BYTE red = GetRValue(Color);
	BYTE green = GetGValue(Color);
	BYTE blue = GetBValue(Color);

	// Матрица пересчета из МСК в ВСК.
	CMatrix MV = CreateViewCoord(PView(0), PView(1), PView(2));
	// Получаем матрицу к-т пирамиды в ВСК
	CMatrix ViewVert = MV * Vertices;

	CRectD RectView;
	// Получаем прямоугольник, охватывающий пирамиду.
	GetRect(ViewVert, RectView);
	// М-ца пересчета из ВСК в ОСК.
	CMatrix MW = SpaceToWindow(RectView, RW);

	CPoint MasVert[6];
	CMatrix V(3);
	V(2) = 1;
	// Пересчитываем к-ты в ОСК и записываем в массивы MasVert.
	for (int i = 0; i < 6; i++)
	{
		V(0) = ViewVert(0, i); // x
		V(1) = ViewVert(1, i); // y
		V = MW * V;
		MasVert[i].x = (int)V(0);
		MasVert[i].y = (int)V(1);
	}

	// Преобразуем сферические к-ты в декартовы.
	CMatrix ViewCart = SphereToCart(PView);

	CMatrix R1(3), R2(3), VN(3);
	// Коэффициент преломления.
	double sm;
	for (int i = 0; i < 3; i++)
	{
		// Получаем к-ты точки верхнего основания
		CMatrix VE = Vertices.GetCol(i + 3, 0, 2);
		VE.getInArray();

		int k = (i == 2) ? 0 : i + 1;
		// текущая точка основания
		R1 = Vertices.GetCol(i, 0, 2);
		R1.getInArray();
		// следующая точка основания
		R2 = Vertices.GetCol(k, 0, 2);
		R2.getInArray();

		CMatrix V1 = R2 - R1;				// вектор основания			    
		V1.getInArray();
		CMatrix V2 = VE - R1;				// вектор между основанием и вершиной		  
		V2.getInArray();
		VN = VectorMult(V2, V1);			// векторное произведение - вектор внешней нормали к грани
		VN.getInArray();
		sm = CosV1V2(VN, ViewCart);			// косинус между вектором нормали к грани и вектором точки наблюдения	

		if (sm >= 0)						// грань видима (острый угол) - рисуем боковую грань
		{
			CPen Pen(PS_SOLID, 2,			// задаем перо
				RGB(sm*red, sm*green, sm*blue));	// берем байты цветов и уменьшаем их цвет квадратом косинуса 
			CPen* pOldPen = dc.SelectObject(&Pen);	// передаем перо в контекст рисования

			CBrush Brus(RGB(sm*red, sm*green, sm*blue));	// задаем изменение цвета при смене угла
			CBrush* pOldBrush = dc.SelectObject(&Brus);				// передаем цвет в контекст памяти
			CPoint MasVertR[4] = { MasVert[i],MasVert[k],MasVert[k+3],MasVert[i+3] };// Стороны треугольника
			dc.Polygon(MasVertR, 4);		// боковая грань
			
			dc.SelectObject(pOldBrush);		// освобождаем контексты памяти
			dc.SelectObject(pOldPen);
		}
	}

	VN = VectorMult(R1, R2);
	sm = CosV1V2(VN, ViewCart);
	if (sm >= 0)
	{
		CBrush Brus(RGB(sm*0.3, sm*0.3, sm*0.3));
		CBrush* pOldBrush = dc.SelectObject(&Brus);
		dc.Polygon(MasVert, 3);	// Основание
		dc.SelectObject(pOldBrush);
	}
	else 
	{
		CBrush Brus(RGB(sm*0.7, sm*0.7, sm*0.7));
		CBrush* pOldBrush = dc.SelectObject(&Brus);
		dc.Polygon(MasVert+3, 3);	// верхнее основание
		dc.SelectObject(pOldBrush);
	}
}

void CPyramid::GetRect(CMatrix& Vert, CRectD& RectView)
// Вычисляет координаты прямоугольника,охватывающего проекцию 
// пирамиды на плоскость XY в ВИДОВОЙ системе координат
// Ver - координаты вершин (в столбцах)
// RectView - проекция - охватывающий прямоугольник
{
	CMatrix V = Vert.GetRow(0);		// x - координаты
	double xMin = V.MinElement();
	double xMax = V.MaxElement();

	V = Vert.GetRow(1);				// y - координаты
	double yMin = V.MinElement();
	double yMax = V.MaxElement();
	RectView.SetRectD(xMin, yMax, xMax, yMin);
}
