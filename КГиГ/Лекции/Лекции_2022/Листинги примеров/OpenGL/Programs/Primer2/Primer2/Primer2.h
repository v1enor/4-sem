#include <stdlib.h> 
#include <math.h> 
#include <string.h>


// Подключаем библиотеку GLUT 
//#include <gl/glut.h> 
#include <glut.h> 

typedef float (*pFunc)(float);


//Функция управляет всем выводом на экран
void OnDraw(void); 
//Функция вызывается при изменении размеров окна
void OnSise(GLint w, GLint h); 
//Функция обрабатывает сообщения от клавиатуры
void Keyboard( unsigned char key, int x, int y ); 
//Функция обрабатывает сообщения от клавиш,не имеющих ASCII - кодов
void SpecialKey(int key, int x, int y ); 
void Triangle();	// Треугольник
void Rectangle();	// Прямоугольник
void MyFunction();	// График функции
// Функция, выполяющая начальные настройки
void CreateMasFunc(pFunc,float x_bedin,float dx,int N,float **Mas);
float MyF1(float x);	// Функция для графика
