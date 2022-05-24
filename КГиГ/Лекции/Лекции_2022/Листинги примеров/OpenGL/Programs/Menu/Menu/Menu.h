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
void Triangle();	// Треугольник
void Rectangle();	// Прямоугольник
