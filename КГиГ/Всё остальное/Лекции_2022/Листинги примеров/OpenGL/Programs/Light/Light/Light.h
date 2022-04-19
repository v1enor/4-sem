#include <stdlib.h> 
#include <math.h> 
#include <string.h>

// Подключаем библиотеку GLUT 
//#include <gl/glut.h> 
#include <glut.h> 
struct Point
{
	double x;
	double y;
	double z;
	Point(double xx,double yy,double zz){x=xx; y=yy; z=zz;};
};

// Инициализация параметров материалов и источника света 
void Init (); 
//Функция управляет всем выводом на экран
void OnDraw(void); 
//Функция вызывается при изменении размеров окна
void OnSise(GLint w, GLint h); 
//Функция обрабатывает сообщения от клавиатуры
void Keyboard( unsigned char key, int x, int y ); 
//Функция обрабатывает сообщения от клавиш,не имеющих ASCII - кодов
void SpecialKey(int key, int x, int y ); 
//-------- Функции пользователя ------------------------------------------------------
void Box (GLfloat x1, GLfloat x2, GLfloat y1, GLfloat y2, GLfloat z1, GLfloat z2);
void Pyramid( GLfloat x1, GLfloat x2, GLfloat y1, GLfloat y2, GLfloat z1,GLfloat z2);
void GetNormal(Point &P1,Point &P2,Point &P3,GLfloat *VN);



