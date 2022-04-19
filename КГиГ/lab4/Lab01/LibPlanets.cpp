#include "stdafx.h"

CRectD::CRectD(double l, double t, double r, double b)
{
	left = l;
	top = t;
	right = r;
	bottom = b;
}
//------------------------------------------------------------------------------
void CRectD::SetRectD(double l, double t, double r, double b)
{
	left = l;
	top = t;
	right = r;
	bottom = b;
}

//------------------------------------------------------------------------------
CSizeD CRectD::SizeD()
{
	CSizeD cz;
	cz.cx = fabs(right - left);	// Ширина прямоугольной области
	cz.cy = fabs(top - bottom);	// Высота прямоугольной области
	return cz;
}

//----------------------------------------------------------------------------

CMatrix CreateTranslate2D(double dx, double dy)
// Формирует матрицу для преобразования координат объекта при его смещении 
// на dx по оси X и на dy по оси Y в фиксированной системе координат
// --- ИЛИ ---
// Формирует матрицу для преобразования координат объекта при смещении начала
// системы координат на -dx оси X и на -dy по оси Y при фиксированном положении объекта 
{
	CMatrix TM(3, 3);
	TM(0, 0) = 1; TM(0, 2) = dx;
	TM(1, 1) = 1;  TM(1, 2) = dy;
	TM(2, 2) = 1;
	return TM;
}

//------------------------------------------------------------------------------------
CMatrix CreateRotate2D(double fi)
// Формирует матрицу для преобразования координат объекта при его повороте
// на угол fi (при fi>0 против часовой стрелки)в фиксированной системе координат
// --- ИЛИ ---
// Формирует матрицу для преобразования координат объекта при повороте начала
// системы координат на угол -fi при фиксированном положении объекта 
// fi - угол в градусах
{
	double fg = fmod(fi, 360.0);
	double ff = (fg / 180.0)*pi; // Перевод в радианы
	CMatrix RM(3, 3);
	RM(0, 0) = cos(ff); RM(0, 1) = -sin(ff);
	RM(1, 0) = sin(ff);  RM(1, 1) = cos(ff);
	RM(2, 2) = 1;
	return RM;
}


//------------------------------------------------------------------------------

CMatrix SpaceToWindow(CRectD& RS, CRect& RW)
// Возвращает матрицу пересчета координат из мировых в оконные
// RS - область в мировых координатах - double
// RW - область в оконных координатах - int
{
	CMatrix M(3, 3);
	CSize sz = RW.Size();	 // Размер области в ОКНЕ
	int dwx = sz.cx;	     // Ширина
	int dwy = sz.cy;	     // Высота
	CSizeD szd = RS.SizeD(); // Размер области в МИРОВЫХ координатах

	double dsx = szd.cx;    // Ширина в мировых координатах
	double dsy = szd.cy;    // Высота в мировых координатах

	double kx = (double)dwx / dsx;   // Масштаб по x
	double ky = (double)dwy / dsy;   // Масштаб по y

	M(0, 0) = kx;  M(0, 1) = 0;    M(0, 2) = (double)RW.left - kx * RS.left;				
	M(1, 0) = 0;   M(1, 1) = -ky;  M(1, 2) = (double)RW.bottom + ky * RS.bottom;		
	M(2, 0) = 0;   M(2, 1) = 0;    M(2, 2) = 1;
	return M;
}

//------------------------------------------------------------------------------

void SetMyMode(CDC& dc, CRectD& RS, CRect& RW) 
// Устанавливает режим отображения MM_ANISOTROPIC и его параметры
// dc - ссылка на класс CDC MFC
// RS -  область в мировых координатах - int
// RW -	 Область в оконных координатах - int  
{
	double dsx = RS.right - RS.left;
	double dsy = RS.top - RS.bottom;
	double xsL = RS.left;
	double ysL = RS.bottom;

	int dwx = RW.right - RW.left;
	int dwy = RW.bottom - RW.top;
	int xwL = RW.left;
	int ywH = RW.bottom;

	dc.SetMapMode(MM_ANISOTROPIC);
	dc.SetWindowExt((int)dsx, (int)dsy);
	dc.SetViewportExt(dwx, -dwy);
	dc.SetWindowOrg((int)xsL, (int)ysL);
	dc.SetViewportOrg(xwL, ywH);
}

/////////////////////// CLASS CSunSystem //////////////////////////////////

CSunSystem::CSunSystem()            //  Конструктор по умолчанию
{
	double rS = 30, rE = 20, rM = 10, rV = 15;       // Радиус Солнца, Земли, Луны
	double RoE = 10 * rS, RoM = 5 * rE, RoV = 6*rS;	 // Радиус орбиты Земли и Луны
	double d = RoE + RoM + rM + RoV;		    // Половина диаметра системы
	RS.SetRectD(-d, d, d, -d);					// Область системы в мировых координатах
	RW.SetRect(0, 0, 600, 600);					// Область в окне
	Sun.SetRect(-rS, rS, rS, -rS);				// Прямоугольник солнца - для рисования круга
	Earth.SetRect(-rE, rE, rE, -rE);			// Прямоугольник Земли - для рисования круга
	Moon.SetRect(-rM, rM, rM, -rM);				// Прямоугольник Луны - для рисования круга
	Mars.SetRect(-rV, rV, rV, -rV);
	EarthOrbit.SetRect(-RoE, RoE, RoE, -RoE);	// Прямоугольник орбиты Земли - для рисования круга
	MoonOrbit.SetRect(-RoM, RoM, RoM, -RoM);	// Прямоугольник орбиты Луны - для рисования круга
	MarsOrbit.SetRect(-RoV, RoV, RoV, -RoV);
	fiE = 0;			// Угловое положение Земли в системе кординат Солнца, град
	fiM = 0;			// Угловое положение Луны в системе кординат Земли, град
	fiV = 1;
	wEarth = 5;			// Угловая скорость Земли в системе кординат Солнца, град/сек.
	wMoon = 50;			// Угловая скорость Луны в системе кординат Земли, град/сек.
	wMars = -8;
	dt = 0.1;
	MCoords.RedimMatrix(3);
	ECoords.RedimMatrix(3);
	VCoords.RedimMatrix(3);	
}

void CSunSystem::SetNewCoords()
//Вычисляет новые координаты планет в СК Солнца через интервал времени dt
{
	double RoM = (MoonOrbit.right - MoonOrbit.left) / 2;// Радиус орбиты Луны    
	double ff = (fiM / 180.0)*pi;						// Радианы - угловое положение Луны в СК Земли
	double x = RoM * cos(ff);							// x - начальная координата Луны в СК Земли
	double y = RoM * sin(ff);							// y - начальная координата Луны в СК Земли	
	MCoords(0) = x;	MCoords(1) = y;   MCoords(2) = 1;
	fiM += wMoon * dt;
	CMatrix P = CreateRotate2D(fiM);					// Матрица поворота против часовой стрелки Луны
	MCoords = P * MCoords;

	double RoE = (EarthOrbit.right - EarthOrbit.left) / 2;// Радиус орбиты Земли
	ff = (fiE / 180.0)*pi;								// Радианы - угловое положение Земли в СК Солнца
	x = RoE * cos(ff);									// x - начальная координата Земли в СК Солнца
	y = RoE * sin(ff);									// y - начальная координата Земли в СК Солнца
	ECoords(0) = x;	ECoords(1) = y;   ECoords(2) = 1;
	P = CreateTranslate2D(x,y);
	MCoords = P * MCoords;

	fiE += wEarth * dt;
	P = CreateRotate2D(fiE);							// Матрица поворота против часовой стрелки Луны и Земли
	MCoords = P * MCoords;
	ECoords = P * ECoords;

	double RoV = (MarsOrbit.right - MarsOrbit.left) / 2;
	ff = (fiV / 180.0)*pi;
	x = RoV * cos(ff);
	y = RoV * sin(ff);
	VCoords(0) = x;
	VCoords(1) = y;
	VCoords(2) = 1;

	fiV += wMars * dt;
	P = CreateRotate2D(fiV);
	VCoords = P * VCoords;
}


void CSunSystem::Draw(CDC& dc)
{
	CBrush SBrush, EBrush, MBrush, VBrush, *pOldBrush;
	CRect R;

	SBrush.CreateSolidBrush(RGB(255, 0, 0));
	EBrush.CreateSolidBrush(RGB(0, 0, 255));
	MBrush.CreateSolidBrush(RGB(0, 255, 0));
	VBrush.CreateSolidBrush(RGB(128,64,64));

	// Рисуем орбиты
	dc.SelectStockObject(NULL_BRUSH);		// Белая кисть - не надо соэдавать
	dc.Ellipse(EarthOrbit);					// Орбита Земли
	dc.Ellipse(MarsOrbit);

	int d = MoonOrbit.right;				// Радиус орбиты Луны
	R.SetRect(ECoords(0) - d, ECoords(1) + d, ECoords(0) + d, ECoords(1) - d);
	dc.Ellipse(R);							// Орбита Луны

// Рисуем Солнце
	pOldBrush = dc.SelectObject(&SBrush);	// Цвет Солнца
	dc.Ellipse(Sun);  // Солнце

// Рисуем Землю
	d = Earth.right;						// Радиус Земли
	R.SetRect(ECoords(0) - d, ECoords(1) + d, ECoords(0) + d, ECoords(1) - d);
	dc.SelectObject(&EBrush);				// Цвет Земли
	dc.Ellipse(R);	// Земля

// Рисуем Луну
	d = Moon.right;							// Радиус Луны
	R.SetRect(MCoords(0) - d, MCoords(1) + d, MCoords(0) + d, MCoords(1) - d);
	dc.SelectObject(&MBrush);				// Цвет Луны
	dc.Ellipse(R);	// Луна

	d = Mars.right;
	R.SetRect(VCoords(0) - d, VCoords(1) + d, VCoords(0) + d, VCoords(1) - d);
	dc.SelectObject(&VBrush);
	dc.Ellipse(R);

	dc.SelectObject(pOldBrush);				//Восстанавливаем контекст по pOldBrush 
}


void CSunSystem::GetRS(CRectD& RSX)
// RS - структура, куда записываются параметры области графика
{
	RSX.left = RS.left;
	RSX.top = RS.top;
	RSX.right = RS.right;
	RSX.bottom = RS.bottom;
}







