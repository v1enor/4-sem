#include <stdlib.h> 
// Подключаем библиотеку GLUT 
//#include <gl/glut.h> 
#include <glut.h> 

//Эта функция управляет всем выводом на экран
void Display(void); 
//Функция вызывается при изменении размеров окна
void Reshape(GLint w, GLint h); 
//Функция обрабатывает сообщения от клавиатуры
void Keyboard( unsigned char key, int x, int y ); // 