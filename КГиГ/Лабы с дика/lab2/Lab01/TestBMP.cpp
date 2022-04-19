#pragma once
#include "stdafx.h"
#include "TestBMP.h"
#include <fstream>

int ShowBitMap(HWND hWnd, HANDLE hBit, int x, int y) 
{
	// Функция отображает рисунок в заданной позиции окна
	// hWnd - дескриптор окна, куда выводится изображение
	// hBit - дескриптор рисунка
	// (x,y) - координаты левого верхнего угла изображения в окне вывода

	BITMAP BitMap;									// BITMAP - структура, которая определяет параметры растрового изображения
	GetObjectW(hBit, sizeof(BITMAP), &BitMap);		// получаем параметры изображения в структуру BitMap
	int Height = BitMap.bmHeight;					// получаем высоту изображения
	int Width = BitMap.bmWidth;						// получаем ширину изображения
	HDC hdc = GetDC(hWnd);							// извлечение контекста изображения
	HDC hdcMem = CreateCompatibleDC(hdc);			// создание контекста памяти
	HBITMAP OldBitmap = (HBITMAP)SelectObject(hdcMem, hBit);	// в созданный контекст памяти заносим дескриптор битовой карты
	BitBlt(hdc, x, y, Width, Height, hdcMem, 0, 0, SRCCOPY);	// в окно, с которым связан контекст изображения, картинка переносится копированием
	SelectObject(hdcMem, OldBitmap);							// после копирования уничтожаются контексты памяти и изображения 
	ReleaseDC(hWnd, hdc);										
	return 0;
}
	
int ClientToBmp(HWND hWnd, RECT& r, char* name)
{
	// Сохранение рабочей области окна в файле name
	// hWnd - дескриптор окна, рабочая область которого сохраняется
	// r – область в  окне, которая сохраняется в файле
	// name - имя файла для сохранения

	// создаем файл
	HANDLE fh = CreateFile((LPCWSTR)name, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL | FILE_FLAG_SEQUENTIAL_SCAN, NULL);
	if (fh == INVALID_HANDLE_VALUE)				// если не создался
		return 2;

	BITMAPINFOHEADER bi;						// структура содержит описание изображения
	ZeroMemory(&bi, sizeof(BITMAPINFOHEADER));	// заполняет заголовок нулями
	bi.biSize = sizeof(BITMAPINFOHEADER);
	bi.biWidth = abs(r.right - r.left);
	bi.biHeight = abs(r.bottom - r.top);
	bi.biPlanes = 1;							// число плоскостей
	bi.biBitCount = 32;							// 32 глубина цветов (число битов на пиксель)
	// для вычисления размера изображения в байтах мы увеличиваем значение на строку до значения, кратного четырем.
	bi.biSizeImage = (bi.biWidth * bi.biBitCount + 31) / 32 * 4 * bi.biHeight;

	BITMAPFILEHEADER bmfHdr;					// заголовок, описывает тип файла, размер, смещение области битов
	ZeroMemory(&bmfHdr, sizeof(BITMAPFILEHEADER));
	bmfHdr.bfType = 0x4D42;						// BM  ('M'<<8)|'B';	заполняем дисковый заголовок
	bmfHdr.bfSize = bi.biSizeImage + sizeof(BITMAPFILEHEADER) + bi.biSize;	// размер файла
	bmfHdr.bfReserved1 = bmfHdr.bfReserved2 = 0;
	bmfHdr.bfOffBits = (DWORD)sizeof(BITMAPFILEHEADER) + (DWORD)bi.biSize;	// смещение до начала пиксельных данных

	HDC hDC = GetDC(hWnd);						// контекст изображения
	HDC hDCMem = CreateCompatibleDC(hDC);		// получаем дескриптор памяти
	HBITMAP hBitmap = CreateCompatibleBitmap(hDC, bi.biWidth, bi.biHeight);		// создаем битовую карту по размеру выделенного изображения
	HBITMAP oldBitmap = (HBITMAP)SelectObject(hDCMem, hBitmap);					// в созданный контекст памяти вносит дескриптор битовой карты
	BitBlt(hDCMem, 0, 0, bi.biWidth, bi.biHeight, hDC, r.left, r.top, SRCCOPY); // копирует в память картинку
	hBitmap = (HBITMAP)SelectObject(hDCMem, oldBitmap);							// восстанавливаем контекст памяти 

	// выделяем место в памяти для того,чтобы функция GetDIBits() перенесла туда коды цвета в DIB-формате.
	HANDLE hDIB = GlobalAlloc(GHND, bi.biSizeImage);
	char* lp = (char*)GlobalLock(hDIB);
	// из карты BitMap строки с нулевой по bi.biHeight функция пересылает в массив lp по формату bi
	GetDIBits(hDC, hBitmap, 0, bi.biHeight, lp, (LPBITMAPINFO)&bi, DIB_RGB_COLORS);	

	DWORD dwWritten = sizeof(BITMAPFILEHEADER);										
	WriteFile(fh, (LPSTR)&bmfHdr, sizeof(BITMAPFILEHEADER), &dwWritten, NULL);		// запись заголовка файла
	dwWritten = sizeof(BITMAPINFOHEADER);
	WriteFile(fh, (LPSTR)&bi, sizeof(BITMAPINFOHEADER), &dwWritten, NULL);			// запись в файл загружаемого заголовка
	dwWritten = bi.biSizeImage;
	WriteFile(fh, lp, bi.biSizeImage, &dwWritten, NULL);							// запись изображения на диск

	// освобождение памяти и закрытие файла
	GlobalUnlock(hDIB);
	GlobalFree(hDIB);

	DeleteObject(hBitmap);
	lp = NULL;
	CloseHandle(fh);

	ReleaseDC(hWnd, hDCMem);
	ReleaseDC(hWnd, hDC);

	DeleteDC(hDCMem);
	DeleteDC(hDC);
	if (dwWritten == 2) return 2;

	return 0;
}