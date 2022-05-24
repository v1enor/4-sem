#include "Primer1.h"
 
//---- Глобадьные переменные---------------------------------
GLint Width = 512;  // Начальная ширина окна 
GLint Height = 512;       // Начальная высота окна 
const int SquareSize = 200; // Размер квадрата 
 
//------ Эта функция управляет всем выводом на экран----------- 
void Display(void) 
{ 
    int left, right, top, bottom; 
	//GLUquadricObj* m_qObj;
	//m_qObj = gluNewQuadric();
 
    left  = (Width - SquareSize) / 2; 
    right = left +SquareSize; 
    bottom = (Height - SquareSize) / 2; 
    top = bottom + SquareSize; 
 
    glClearColor(0, 0, 0, 1); 
    glClear(GL_COLOR_BUFFER_BIT); 
     
    glColor3ub(255,0,0); 
    glBegin(GL_QUADS); 
      glVertex2f(left,bottom); 
      glVertex2f(left,top); 
      glVertex2f(right,top); 
      glVertex2f(right,bottom); 
    glEnd(); 

	//gluSphere(m_qObj, 100.0f, 10, 10);
 
    glFinish(); 
} 
 
// ------- Функция вызывается при изменении размеров окна------------ 
void Reshape(GLint w, GLint h) 
{ 
    Width = w; 
    Height = h; 
    
	// Устанавливаем размеры области отображения 
    glViewport(0, 0, w, h); 
 
    // Ортографическая проекция 
    glMatrixMode(GL_PROJECTION); 
    glLoadIdentity(); 
    glOrtho(0, w, 0, h, -1.0, 1.0); 
 
    glMatrixMode(GL_MODELVIEW); 
    glLoadIdentity(); 
} 

 
//------ Функция обрабатывает сообщения от клавиатуры ---------------

void Keyboard( unsigned char key, int x, int y )
{ 
#define ESCAPE '\033' 
 
    if( key == ESCAPE ) 
        exit(0); 
} 
 
//--------Главный цикл приложения------------------------------------
int main(int argc, char *argv[]) 
{ 
    glutInit(&argc, argv); 
    glutInitDisplayMode(GLUT_RGB); 
    glutInitWindowSize(Width, Height); 
	glutCreateWindow("Пример_1.    Организация окна OpenGL");
 
    glutDisplayFunc(Display); 
    glutReshapeFunc(Reshape); 
    glutKeyboardFunc(Keyboard); 
 
    glutMainLoop(); 
	return 0;
} 
 
 