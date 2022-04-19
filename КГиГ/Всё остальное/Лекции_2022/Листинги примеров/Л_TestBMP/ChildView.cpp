// ChildView.cpp : implementation of the CChildView class
//

#include "stdafx.h"
#include "TestBMP.h"
#include "ChildView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CChildView

CChildView::CChildView()
{
	Index=0;
}

CChildView::~CChildView()
{
}


BEGIN_MESSAGE_MAP(CChildView, CWnd)
	ON_WM_PAINT()
	ON_COMMAND(ID_FILE_LOADFILE, &CChildView::OnFileLoadfile)
	ON_COMMAND(ID_FILE_SAVEFILE, &CChildView::OnFileSavefile)
	ON_COMMAND(ID_FILE_CLEAR, &CChildView::OnFileClear)
	ON_COMMAND(ID_FILE_LOADPICT, &CChildView::OnFileLoadpict)
END_MESSAGE_MAP()



// CChildView message handlers

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;
	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
		::LoadCursor(NULL, IDC_ARROW), reinterpret_cast<HBRUSH>(COLOR_WINDOW+1), NULL);

	return TRUE;
}

void CChildView::OnPaint() 
{
	CPaintDC dc(this); // device context for painting
	
	if(Index==1)	// Отображение файла "FileBmp.bmp"
	{

		int k= ShowBitMap(this->m_hWnd,Bit,10,10);
		//Index=0;

	}

	if(Index==2)	// Отображение файла "FileBmp.bmp"
	{

		int k= ShowBitMap(this->m_hWnd,Bit,10,10);
		//Index=0;

	}


	
	// TODO: Add your message handler code here
	
	// Do not call CWnd::OnPaint() for painting messages
}


void CChildView::OnFileLoadfile()	// ЗАГРУЗКА ФАЙЛА
{
	 Bit=(HBITMAP)LoadImage(NULL,"FileBmp.bmp",
				IMAGE_BITMAP,0,0,LR_LOADFROMFILE | LR_CREATEDIBSECTION);
    if(!Bit)MessageBox("FileBmp.bmp","НЕТ КАРТИНКИ",0);
	Index=1;
	this->Invalidate();	
}


void CChildView::OnFileLoadpict()
{
	 Bit=(HBITMAP)LoadImage(NULL,"Elephant.bmp",
				IMAGE_BITMAP,0,0,LR_LOADFROMFILE | LR_CREATEDIBSECTION);
    if(!Bit)MessageBox("FileBmp.bmp","НЕТ КАРТИНКИ",0);
	Index=2;
	this->Invalidate();	
	
}


void CChildView::OnFileSavefile()	// Запись изображения в файл
{
	int k= ClientToBmp(this->m_hWnd,"Pict.bmp");

}

void CChildView::OnFileClear()
{
	Index=0;
	Invalidate();
}




///////////////////  ФУНКЦИИ  /////////////////////////////////////////////

int ShowBitMap(HWND hWnd,HBITMAP hBit,int x,int y)
//Функция отображает рисунок в заданной позиции окна
//hWnd - дискриптор окна, куда выводится изображение
//hBit - дискриптор рисунка
//(x,y) - координаты левого верхнего угла изображения в окне вывода
{
 BITMAP BitMap;
//В структуру BitMap считываются параметры картинки
 GetObject(hBit,sizeof(BITMAP),&BitMap);
// Из ее полей bmHeight и bmWidth получаем размеры для копирования
 int Height=BitMap.bmHeight;
 int Width=BitMap.bmWidth;
//Получаем контекст изображения
 HDC hdc = GetDC(hWnd);
//Создаем контекст памяти
 HDC hdcMem=CreateCompatibleDC(hdc);
//В созданный контекст памяти заносим дискриптор битовой карты
 HBITMAP OldBitmap=(HBITMAP)SelectObject(hdcMem,hBit);
///////////////////////////////////////////////////////////////////
//Если в исходном тексте программы есть строка 
//#include <windowsx.h>,то дескриптор hBit можно включить в контекст
// при помощи инструкции:
//HBITMAP OldBitmap=SelectBitmap(hdcMem,hBit);
///////////////////////////////////////////////////////////////////
//Контекст hdcMem можно использовать для рисования средствами GDI -
//создаваемое изображение с учетом заданной растровой операции наносится 
//на включенную в контекст картинку.
//В окно, с которым связан контекст изображения hdc, картинка переносится
//при помощи функции копирования:
 BitBlt(hdc,x,y,Width,Height,hdcMem,0,0,SRCCOPY);	//PATCOPY
//После копирования уничтожаются контексты памяти и изображения
 SelectObject(hdcMem,OldBitmap);
 //SelectBitmap(hdcMem,OldBitmap);
 ReleaseDC(hWnd,hdc);
 DeleteDC(hdcMem);
 return 0;
}

//======================================================================================


int ClientToBmp(HWND hWnd,char *Name)
//Сохранение рабочей области окна в файле Name.bmp
//hWnd - дискриптор окна, рабочая область которого сохраняется
//Name - имя файла для сохранения
{
 BITMAPFILEHEADER    bmfHdr;
 BITMAPINFOHEADER bi;
 RECT r;
 int BitToPixel=16;			//Устанавливаем цветовую глубину 16 бит 
 GetClientRect(hWnd,&r);	//Узнали размер рабочей области
 HDC hdc = GetDC(hWnd);
 HDC hdcMem=CreateCompatibleDC(hdc); 
//Создалем битовую карту BitMap по размеру рабочей области окна
//Битовая карта создается на основе контекста устройства hdc, поэтому 
//она хранит изображение DDB-формата (а не DIB). Именно поэтому нельзя 
//использовать функцию WriteDIBC() 

 HBITMAP BitMap = CreateCompatibleBitmap(hdc, r.right,r.bottom);
 HBITMAP OldBitmap = (HBITMAP)SelectObject(hdcMem, BitMap);
 BitBlt(hdcMem, 0, 0, r.right, r.bottom, hdc, 0, 0, SRCCOPY);
 BitMap = (HBITMAP)SelectObject(hdcMem,OldBitmap);
 ZeroMemory(&bi,sizeof(BITMAPINFOHEADER));	//Это аналог функции memset(), 
											//который заполняет заголовок нулями. 

    bi.biSize = sizeof(BITMAPINFOHEADER);
    bi.biWidth = r.right;
    bi.biHeight = r.bottom;
    bi.biPlanes = 1;
    bi.biBitCount = BitToPixel; //в примерах  режим 16 бит тоже сохраняется, как 24- это DIB 
//Но 8 бит на пиксел работать не будут - не записаны после заголовка элементы палитры

//Для вычисления размера изображения в байтах мы увеличиваем значение 
//г.right * BitToPixel/8 байт на строку до значения, кратного четырем. Это 
//вычисление может выполнить и функция GetDIBits() (см. MSDN). 
	bi.biSizeImage = (r.right * BitToPixel+31)/32*4 * r.bottom;

	DWORD dwWritten; //Количество записанных файлов
//Открываем файл
	HANDLE fh = CreateFile(Name, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS,
            FILE_ATTRIBUTE_NORMAL | FILE_FLAG_SEQUENTIAL_SCAN, NULL);
    if (fh == INVALID_HANDLE_VALUE)     return 2;

    bmfHdr.bfType = ('M'<<8)|'B';  //Заполняем дисковый заголовок
    bmfHdr.bfSize = bi.biSizeImage + sizeof(bmfHdr)+bi.biSize; //Размер файла
    bmfHdr.bfReserved1 = bmfHdr.bfReserved2 = 0;
    bmfHdr.bfOffBits = sizeof(bmfHdr) + bi.biSize; // Смещение до начала данных
//Запись заголовка в файл
    WriteFile(fh, (LPSTR)&bmfHdr, sizeof(bmfHdr), &dwWritten, NULL);
// Запись в файл загружаемого заголовка  
	WriteFile(fh, (LPSTR)&bi, sizeof(BITMAPINFOHEADER), &dwWritten, NULL);
//Выделяем место в памяти для того,чтобы функция GetDIBits()перенесла 
//туда коды цвета в DIB-формате.
    char *lp=(char *) GlobalAlloc(GMEM_FIXED, bi.biSizeImage);
// Из карты BitMap строки с нулевой по bi.biHeight функция пересылает в массив lp 
//	по формату bi ( беспалитровый формат) 
	int err=GetDIBits(hdc, BitMap,0,(UINT)r.bottom, lp,(LPBITMAPINFO)&bi, DIB_RGB_COLORS); 
//Запись изображения на диск				          
    WriteFile(fh, lp, bi.biSizeImage, &dwWritten, NULL);
//Освобождение памяти и закрытие файла
    GlobalFree(GlobalHandle(lp));
	CloseHandle(fh);
	 ReleaseDC(hWnd,hdc);
     DeleteDC(hdcMem);		
    if (dwWritten == 0)        return 2; 
    return 0;
		}







