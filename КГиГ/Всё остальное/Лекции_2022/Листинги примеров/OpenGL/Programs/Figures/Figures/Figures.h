#include <stdlib.h> 
#include <math.h> 
#include <string.h>


// Подключаем библиотеку GLUT 
//#include <gl/glut.h> 
#include <glut.h> 

//Функция управляет всем выводом на экран
void OnDraw(void); 
//Функция вызывается при изменении размеров окна
void OnSise(GLint w, GLint h); 
//Функция обрабатывает сообщения от клавиатуры
void Keyboard( unsigned char key, int x, int y ); 
//Функция обрабатывает сообщения от клавиш,не имеющих ASCII - кодов
void SpecialKey(int key, int x, int y ); 

void Cube();	// Куб
void Box (GLfloat x1, GLfloat x2, GLfloat y1, GLfloat y2, GLfloat z1, GLfloat z2);
void Pyramid( GLfloat x1, GLfloat x2, GLfloat y1, GLfloat y2, GLfloat z1,GLfloat z2);


