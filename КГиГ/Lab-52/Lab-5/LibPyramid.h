#pragma once
class CPyramid
{
private:
	CMatrix Vertices; 
	void GetRect(CMatrix& Vert, CRectD&  RectView);

public:
	CPyramid();
	void Draw(CDC& dc, CMatrix& P, CRect& RW);
	void Draw1(CDC& dc, CMatrix& P, CRect& RW);
};

CPyramid::CPyramid()
{
	Vertices.RedimMatrix(4, 6);	
								
	/*       A                   B                    C                   A'                  B'                  C'      */
	Vertices(0, 0) = 0;	Vertices(0, 1) = 0;  Vertices(0, 2) = 3; Vertices(0, 3) = 0; Vertices(0, 4) = 0; Vertices(0, 5) = 1; 
	Vertices(1, 0) = 3; Vertices(1, 1) = 0;  Vertices(1, 2) = 0; Vertices(1, 3) = 1; Vertices(1, 4) = 0; Vertices(1, 5) = 0;  
	Vertices(2, 0) = 0; Vertices(2, 1) = 0;  Vertices(2, 2) = 0; Vertices(2, 3) = 3; Vertices(2, 4) = 3; Vertices(2, 5) = 3;  
	Vertices(3, 0) = 1; Vertices(3, 1) = 1;  Vertices(3, 2) = 1; Vertices(3, 3) = 1; Vertices(3, 4) = 1; Vertices(3, 5) = 1;  
}
void CPyramid::GetRect(CMatrix& Vert, CRectD& RectView)
{
	CMatrix V = Vert.GetRow(0);
	double xMin = V.MinElement();
	double xMax = V.MaxElement();
	V = Vert.GetRow(1);
	double yMin = V.MinElement();
	double yMax = V.MaxElement();
	RectView.SetRectD(xMin, yMax, xMax, yMin);
}

void CPyramid::Draw(CDC& dc, CMatrix& PView, CRect& RW)
{
	CMatrix MV = CreateViewCoord(PView(0), PView(1), PView(2));
	CMatrix ViewVert = MV*Vertices;//ÂÑÊ
	CRectD RectView;
	GetRect(ViewVert, RectView); 
	CMatrix MW = SpaceToWindow(RectView, RW);//ÂÑÊ-ÎÑÊ

	CPoint MasVert[6]; 
	CMatrix V(3);
	V(2) = 1;

	for (int i = 0; i < 6; i++)
	{
		V(0) = ViewVert(0, i); 
		V(1) = ViewVert(1, i); 
		V = MW * V;            
		MasVert[i].x = (int)V(0);
		MasVert[i].y = (int)V(1);
	}

	CPen Pen(PS_SOLID, 2, RGB(0, 0, 255));
	CPen* pOldPen = dc.SelectObject(&Pen);
	dc.MoveTo(MasVert[3]);
	// Ðåáðà ÍÈÆÍÅÉ ãðàíè
	for (int i = 0; i < 3; i++)
	{
		dc.LineTo(MasVert[i]);
	}
	dc.LineTo(MasVert[0]);
	dc.MoveTo(MasVert[5]);
	// Ðåáðà ÂÅÐÕÍÅÉ ãðàíè
	for (int i = 3; i < 6; i++)
	{
		dc.LineTo(MasVert[i]);
	}
	// Ðåáðà ÁÎÊÎÂÛÕ ãðàíåé
	for (int i = 0; i < 3; i++)
	{
		dc.MoveTo(MasVert[i]);
		dc.LineTo(MasVert[i + 3]);
	}
	dc.SelectObject(pOldPen);
}
void CPyramid::Draw1(CDC& dc, CMatrix& PView, CRect& RW)
{
	CMatrix ViewCart = SphereToCart(PView); 
	CMatrix MV = CreateViewCoord(PView(0), PView(1), PView(2)); 
	CMatrix ViewVert = MV*Vertices;
	CRectD RectView;
	GetRect(ViewVert, RectView);
	CMatrix MW = SpaceToWindow(RectView, RW);

	CPoint MasVert[6];
	CMatrix V(3);
	V(2) = 1;
	for (int i = 0; i < 6; i++)
	{
		V(0) = ViewVert(0, i); 
		V(1) = ViewVert(1, i); 
		V = MW * V;            
		MasVert[i].x = (int)V(0);
		MasVert[i].y = (int)V(1);
	}

	// Ðèñóåì
	CPen Pen(PS_SOLID, 2, RGB(0, 0, 255));
	CPen* pOldPen = dc.SelectObject(&Pen);
	CBrush Brush(RGB(255, 0, 0));
	CBrush* pOldBrush = dc.SelectObject(&Brush);
	CMatrix R1(3), R2(3), VN(3);
	double sm;
	for (int i = 0; i < 3; i++)
	{
		CMatrix VE = Vertices.GetCol(i + 3, 0, 2); // Âåðøèíà E
		int k;
		if (i == 2)
			k = 0;
		else
			k = i + 1;
		R1 = Vertices.GetCol(i, 0, 2);
		R2 = Vertices.GetCol(k, 0, 2);
		CMatrix V1 = R2 - R1;         
		CMatrix V2 = VE - R1;         
		VN = VectorMult(V2, V1);      
		sm = ScalarMult(VN, ViewCart);

		if (sm >= 0) 
		{
			dc.MoveTo(MasVert[i]);
			dc.LineTo(MasVert[k]);
			dc.LineTo(MasVert[k + 3]);
			dc.LineTo(MasVert[i + 3]);
			dc.LineTo(MasVert[i]);
		}
	}

	VN = VectorMult(R1, R2);
	sm = ScalarMult(VN, ViewCart);
	if (sm >= 0) 
	{
		CBrush *botBrush = new CBrush(RGB(245, 245, 255));
		dc.SelectObject(botBrush);
		dc.Polygon(MasVert, 3);
	}
	else
	{
		CBrush *topBrush = new CBrush(RGB(0, 245, 255));
		dc.SelectObject(topBrush);
		dc.Polygon(MasVert + 3, 3);
	}

	dc.SelectObject(pOldPen);
	dc.SelectObject(pOldBrush);
}