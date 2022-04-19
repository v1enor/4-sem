#include "Menu.h"

//x - координата левого верхнего угла окна OpenGL на экране
GLint x_win=100;
//y - координата левого верхнего угла окна OpenGL на экране
GLint y_win=50;   
// Начальная ширина окна OpenGL на экране
GLint Width = 800;	 
 //Начальная высота окна OpenGL на экране
GLint Height = 600;  
// Переменные для определения области видимости графических
//данных после проектирования в системе коордтнат наблюдателя (СКН)
GLint left,right,top,bottom;                              
GLint Index=0;  // Для выбора рисунка
float angle=0;    // Угол для поворота треугольника, град

//------ Эта функция управляет всем выводом на экран----------- 
void OnDraw(void) 
{   
	switch(Index)
	{
		case 0:
		{
			glClearColor(1.0,1.0,1.0,0.0);
			glClear(GL_COLOR_BUFFER_BIT); 
			break;
		}

		case 1:
		{
			//Цвет фона в окне 
			glClearColor(1.0,1.0,1.0,0.0); // - белый
            // Очистить буфер цвета - залить цветом фона	
			glClear(GL_COLOR_BUFFER_BIT);  	
			glColor3ub(0,0,0);	// Цвет линии 
			glLineWidth(3.0) ;	    // Толщина линии
			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 
			//glRotatef(angle,0.0,0.0,1.0); //  		
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10;
			gluOrtho2D(left, right, bottom, top); 
			Triangle(); //Рисуем треугольник
			break;
		}

		case 2:
		{
           //Цвет фона в окне
			glClearColor(0.8,0.8,0.8,0.0); // - серый
            // Очистить буфер цвета - залить цветом фона	
			glClear(GL_COLOR_BUFFER_BIT);  
			glColor3ub(0,0,0);	       // Цвет фигуры 
			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 				
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10;
			gluOrtho2D(left, right, bottom, top); 
			Rectangle();
			break;
		}
		
	}
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

//--------------- Figure ------------------------------------------------
void Figure(GLint TypeFigure)
{
	Index= TypeFigure;
	glutPostRedisplay();
}

//--------- Треугольник --------------------------------------------
void Triangle()
{        
    glBegin(GL_LINE_LOOP); 
      glVertex2f(-5.0,-5.0); 
      glVertex2f(0.0,5.0); 
      glVertex2f(5.0,-5.0); 
    glEnd(); 	
}

//--------- Прямоугольник --------------------------------------------
void Rectangle()
{  
	GLfloat VectCoords[4][2]={-7.0,-5.0,-7.0,5.0,7.0,5.0,7.0,-5.0};
    glBegin(GL_POLYGON); 
    for(int i=0;i<4;i++) glVertex2fv(VectCoords[i]); 
    glEnd(); 	
}

//================ main ==================================================
int main(int argc, char *argv[]) 
{ 
//----- Функции библиотеки GLUT ------------------------------------------
 glutInit(&argc, argv); // Инициализация библиотеки GLUT
 glutInitDisplayMode(GLUT_RGB|GLUT_SINGLE); //Используется режим RGB для 
	                                           //выбора цвета и одинарный видеобуфер
	glutInitWindowPosition  (x_win,y_win);     // Координаты левого верхнего угла 
	                                           //окна OpenGL на экране монитора
  glutInitWindowSize(Width, Height);         //Ширина и высота окна OpenGL 
	glutCreateWindow("Создание меню"); //Создание окна с заголовком
  glutDisplayFunc(OnDraw); // Регистрация функции обратного вызова OnDraw - вызывается
	                         // системой при необходимости перерисовать окно (аналог OnPaint в MFC) 
  glutReshapeFunc(OnSize); // Регистрация функции обратного вызова OnSize - вызывается
	                         // системой при изменении размеров окна (аналог OnSize в MFC) 
  //-------Создаем меню -------------------------
	glutCreateMenu(Figure);
		glutAddMenuEntry("Треугольник",1);
		glutAddMenuEntry("Прямоугольник",2);
		glutAddMenuEntry("Очистить",0);
	glutAttachMenu(GLUT_RIGHT_BUTTON);
//-------------------------------------------------
  glutMainLoop(); //Запуск бесконечного цикла обработки сообщений Windows
	return 0;
} 
 