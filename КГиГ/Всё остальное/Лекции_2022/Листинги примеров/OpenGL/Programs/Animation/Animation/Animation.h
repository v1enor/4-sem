#include <stdlib.h> 
#include <math.h> 
#include <string.h>


// Подключаем библиотеку GLUT 
#include <glut.h> 

//Функция управляет всем выводом на экран
void OnDraw(void); 
//Функция вызывается при изменении размеров окна
void OnSise(GLint w, GLint h); 
//Функция обрабатывает сообщения от клавиш,не имеющих ASCII - кодов
void SpecialKey(int key, int x, int y );
void MouseFunction(int button,int state,int x,int y);
void IdleFunction();
void Triangle(GLfloat x1,GLfloat y1,GLfloat x2,GLfloat y2,GLfloat x3,GLfloat y3);	// Треугольник
void Rectangle(GLfloat x1,GLfloat y1,GLfloat x2,GLfloat y2);	// Прямоугольник

