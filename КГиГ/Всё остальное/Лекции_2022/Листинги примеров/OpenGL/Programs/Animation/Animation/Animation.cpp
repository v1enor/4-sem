#include "Animation.h"
//---- Глобальные переменные---------------------------------
GLint x_win=100;     // x - координата левого верхнего угла окна OpenGL на экране
GLint y_win=50;     // y - координата левого верхнего угла окна OpenGL на экране
GLint Width = 800;	  // Начальная ширина окна 
GLint Height = 600;   // Начальная высота окна 
GLint left,right,top,bottom; // Для определения области видимости графических
                             //данных после проектирования в СКН
GLint Index=1;  // Для выбора 
float angle=0;    // Угол для поворота фигуры, град
float d_angle=2;    // Шаг изменеия угла, град.

//------ Эта функция управляет всем выводом на экран----------- 
void OnDraw(void) 
{   
	switch(Index)
	{
		case 1:
		{
			glClearColor(1.0,1.0,1.0,0.0); //Цвет фона в окне
			glClear(GL_COLOR_BUFFER_BIT);  // Очистить буфер цвета - залить цветом фона		
			glColor3ub(255,0,0);	// Цвет линии или заливки 
			//glLineWidth(3.0) ;	    // Толщина линии 

			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 
			glRotatef(angle,0.0,0.0,1.0); //  
			
			
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10;
			gluOrtho2D(left, right, bottom, top); // (left,bottom)- (right,top)
			Rectangle(-5.0,-5.0,5.0,5.0);
			break;
		}

		case 2:
		{
			glClearColor(0.0,1.0,0.0,0.0); //Цвет фона в окне
			glClear(GL_COLOR_BUFFER_BIT);  // Очистить буфер цвета - залить цветом фона	
			glColor3ub(0,0,255);	       // Цвет линии 


			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-8; right=8; bottom=-8; top=8;
			gluOrtho2D(left, right, bottom, top); // (left,bottom)- (right,top)

			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 
			glRotatef(angle,0.0,0.0,1.0); //								
			Triangle(-2.5,-2.5,0.0,0.0,2.5,-2.5);

			glLoadIdentity();
			glRotatef(angle+180,0.0,0.0,1.0); //
			glColor3ub(255,0,0);	       // Цвет линии 
			Triangle(-2.5,-2.5,0.0,0.0,2.5,-2.5);
			break;
		}
		
	}
	glutSwapBuffers(); // Переключение буферов (Обязательно 
	                   // при использовании двойной буферизации GLUT_DOUBLE
    glFinish(); 
} 
 
// ------- Функция вызывается при изменении размеров окна------------ 
void OnSize(GLint w, GLint h) 
// w - новая ширина окна
// h - новая высота окна
{   
	// Устанавливаем новые размеры области отображения 
    glViewport(0,0, w, h); 
} 

 

//-- Функция обрабатывает сообщения от клавиш, НЕ имеющих ASCII - кода  -------

void SpecialKey(int key, int x, int y )
{
	switch(key)
	{
		case GLUT_KEY_F1:	// 
		{
			Index=1;
			break;
		}
		case GLUT_KEY_F2:	// 
		{
			Index=2;
			break;
		}
	}
glutPostRedisplay();
}

//---------------------- IdleFunction ----------------------------
void IdleFunction()
{
	angle+=d_angle;
	glutPostRedisplay();	
}

//----------------------------------------------------------------

void MouseFunction(int button,int state,int x,int y)
{
	if(button==GLUT_LEFT_BUTTON && state==GLUT_DOWN)
		glutIdleFunc(IdleFunction);
	if(button==GLUT_RIGHT_BUTTON && state==GLUT_DOWN)
		{
			glutIdleFunc(NULL);
			angle=0;
		}
}



//--------- Треугольник --------------------------------------------
void Triangle(GLfloat x1,GLfloat y1,GLfloat x2,GLfloat y2,GLfloat x3,GLfloat y3)
//  Треугольник ABC:  A(x1,y1),B(x2,y2),C(x3,y3)- по часовой стрелке
{        
    glBegin(GL_POLYGON); // Обход против часовой стрелки
      glVertex2f(x1,y1); //A
      glVertex2f(x3,y3); //C
      glVertex2f(x2,y2); //B
    glEnd(); 	
}

//--------- Прямоугольник --------------------------------------------
void Rectangle(GLfloat x1,GLfloat y1,GLfloat x2,GLfloat y2)
//Четырехугольник ABCD: 
//A(x1,y1) - левый нижний угол
//C(x3,y3) - правый верхний угол
{  
    glBegin(GL_POLYGON); // Обход против часовой стрелки
	  glVertex2f(x1,y1); //A
	  glVertex2f(x2,y1); //D
	  glVertex2f(x2,y2); //C
	  glVertex2f(x1,y2); //B
    glEnd(); 	
}

 
//================ main ==================================================
int main(int argc, char *argv[]) 
{ 
//----- Функции библиотеки GLUT ------------------------------------------
    glutInit(&argc, argv); // Инициализация библиотеки GLUT
    glutInitDisplayMode(GLUT_RGB|GLUT_DOUBLE); //Используется режим RGB для 
//выбора цвета и ДВОЙНОЙ видеобуфер (требует использования комманды glutSwapBuffers())
	glutInitWindowPosition  (x_win,y_win);     // Координаты левого верхнего угла 
	                                           //окна OpenGL на экране монитора
    glutInitWindowSize(Width, Height);         //Ширина и высота окна OpenGL 
	glutCreateWindow("Пример_4. Анимация  "); //Создание окна с заголовком
    glutDisplayFunc(OnDraw); // Регистрация функции обратного вызова OnDraw - вызывается
	                         // системой при необходимости перерисовать окно (аналог OnPaint в MFC) 
    glutReshapeFunc(OnSize); // Регистрация функции обратного вызова OnSize - вызывается
	                         // системой при изменении размеров окна (аналог OnSize в MFC) 
   
	glutSpecialFunc(SpecialKey);// Регистрация функции обратного вызова SpesialKey -вызывается
                                // системой при при нажати клавиши, НЕ имеющей ASCII-кода
	glutIdleFunc(IdleFunction); //Регистрация функции обратного вызова dleFunction - вызывается
								// системой когда нет других событий 
    glutMouseFunc(MouseFunction);//Регистрация функции обратного вызова MouseFunction- вызывается
								 // системой при нажатии клавиш мыши 
	glutIdleFunc(NULL); // Блокируем IdleFunction
    glutMainLoop(); //Запуск бесконечного цикла обработки сообщений Windows
//-------------------------------------------------------------------------------

	return 0;
} 
 
 