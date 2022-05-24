#include <stdlib.h> 
#include <math.h> 
#include <string.h>

// Подключаем библиотеку GLUT 
 
#include <glut.h> // Для Windows 7

//Функция управляет всем выводом на экран
void OnDraw(void); 
//Функция вызывается при изменении размеров окна
void OnSise(GLint w, GLint h); 
void Figure(GLint TypeFigure);
void DrawPoints(GLfloat Points[][3],GLint NumPoints);
//void DrawPoints3D(GLfloat Points[][4][3],GLint NumPoints,GLint NumSheets);
void DrawPoints3D(float ***Points,int NumPoints,int NumSheets,int k);
void Bezier2D_1(GLfloat Points[][3],GLint NumPoints);	
void Bezier2D_2(GLfloat Points[][3],GLint NumPoints);
void InitLight();
void CopyPoints();

