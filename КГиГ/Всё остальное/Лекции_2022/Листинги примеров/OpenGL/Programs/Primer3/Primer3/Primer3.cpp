#include "Primer3.h"
const float pi=3.14159;

//---- Глобальные переменные---------------------------------

// x - координата левого верхнего угла окна OpenGL на экране
GLint x_win=100;   
// y - координата левого верхнего угла окна OpenGL на экране
GLint y_win=50;  
// Начальная ширина окна 
GLint Width = 800;	
// Начальная высота окна
GLint Height = 600;   
// Для определения области видимости графических
//данных после проектирования в СКН
GLint left,right,top,bottom,znear,zfar; 
 // Для выбора рисунка                           
GLint Index=0; 
// Угол для поворота вокруг оси X, град
float angleX=0;  
// Угол для поворота вокруг оси X, град
float angleY=0;
// Шаг изменеия угла, град
float d_angle=10;    

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
			glClearColor(1.0,1.0,1.0,0.0); //Белый
			//Очистить буфер цвета - залить цветом фона
			glClear(GL_COLOR_BUFFER_BIT| GL_DEPTH_BUFFER_BIT );  		
			glColor3ub(255,0,0);	// Цвет линии - красный
			glLineWidth(2.0) ;	    // Толщина линии

			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 	        // Видовая матрица  M=I	
			//Поворот вокруг оси Y, M=Ry(angleY)
			glRotatef(angleY,0.0,1.0,0.0);  
			//Поворот вокруг оси X, M=Ry(angleY)*Rx(angleX) 
			glRotatef(angleX,1.0,0.0,0.0); 
			//Результат V2=Ry*Rx*V1
					
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10; znear=-10; zfar=10;
			//Устанавливаем область видимости
			glOrtho(left, right, bottom, top,znear,zfar); 				
			glPolygonMode (GL_FRONT_AND_BACK ,GL_LINE); 
			GLfloat x1=-5, x2=5,y1=-5,y2=5,z1=0.0,z2=10;
			glDisable (GL_CULL_FACE);    //Запрещаем удалять не лицевые грани
			Pyramid(x1,x2,y1,y2,z1,z2);  //Рисуем пирамиду
			break;
			
		}

		case 2:
		{
			//Цвет фона в окне
			glClearColor(1.0,1.0,1.0,0.0); //Белый
			//Очистить буфер цвета - залить цветом фона	
			glClear(GL_COLOR_BUFFER_BIT| GL_DEPTH_BUFFER_BIT );  		
			glColor3ub(0,0,255);	// Цвет линии - синий 
			glLineWidth(2.0) ;	    // Толщина линии

			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 	// Видовая матрица  M=I	
			//Поворот вокруг оси Y, M=Ry(angleY)
			glRotatef(angleY,0.0,1.0,0.0); 
			//Поворот вокруг оси X, M=Ry(angleY)*Rx(angleX) 
			glRotatef(angleX,1.0,0.0,0.0); 
			//Результат V2=Ry*Rx*V1
					
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10; znear=-10; zfar=10;
			//Устанавливаем область видимости
			glOrtho(left, right, bottom, top,znear,zfar); 

			glEnable (GL_CULL_FACE);//Разрешаем удалять не лицевые грани
			glCullFace (GL_BACK );
					
			glPolygonMode (GL_FRONT_AND_BACK ,GL_LINE); 
			GLfloat x1=-5, x2=5,y1=-5,y2=5,z1=0.0,z2=10;
			Pyramid(x1,x2,y1,y2,z1,z2); //Рисуем пирамиду
			break;
			
		}
		case 3:
		{
			//Цвет фона в окне
			glClearColor(1.0,1.0,1.0,0.0); //Белый
			//Очистить буфер цвета - залить цветом фона
			glClear(GL_COLOR_BUFFER_BIT| GL_DEPTH_BUFFER_BIT );  		
			glColor3ub(0,0,0);	// Цвет линии - черный 
			glLineWidth(2.0) ;	    // Толщина линии

			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 
			//Поворот вокруг оси Y, M=Ry(angleY)
			glRotatef(angleY,0.0,1.0,0.0); 
			//Поворот вокруг оси X, M=Ry(angleY)*Rx(angleX) 
			glRotatef(angleX,1.0,0.0,0.0); 
			// Результат V2=Ry*Rx*V1
					
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10; znear=-10; zfar=10;
			//Устанавливаем область видимости
			glOrtho(left, right, bottom, top,znear,zfar); 

			glEnable (GL_CULL_FACE); //Разрешаем удалять не лицевые грани
			glCullFace (GL_BACK );
					
			glPolygonMode (GL_FRONT_AND_BACK ,GL_LINE); 

			GLfloat x1=-2.5, x2=2.5,y1=-5,y2=5,z1=-5,z2=5;
			Box(x1,x2,y1,y2,z1,z2);
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
 
//-- Функция обрабатывает сообщения от клавиш, имеющих ASCII - код  --

void Keyboard( unsigned char key, int x, int y )
{ 
#define ESCAPE '\033' 
 
if( key == ESCAPE ) exit(0);
         
switch(key)
{
	case'a':case'A':  // Пирамида без удаления нелицевых граней
		{
			Index=1;
			break;
		}
	case'b':case'B':  // Пирамида с удалением нелицевых граней
		{
			Index=2;
			break;
		}

	case'c':case'C':  // Параллепипед с удалением нелицевых граней
		{	
			Index=3;
			break;
		}
}

glutPostRedisplay(); //Требуем перерисовки окна

} 

//-- Функция обрабатывает сообщения от клавиш,--- 
//-- НЕ имеющих ASCII - кода  -------------------

void SpecialKey(int key, int x, int y )
{
	switch(key)
	{
		case GLUT_KEY_RIGHT: // Стрелка вправо (102)
		{
			angleY+=d_angle;		
			break;
		}
		case GLUT_KEY_LEFT:  // Стрелка влево (100)
		{
			angleY-=d_angle;	
			break;
		}
		case GLUT_KEY_UP:	 // Стрелка вверх (101)
		{
			angleX-=d_angle;		
			break;
		}
		case GLUT_KEY_DOWN:  // Стрелка вниз (103)
		{
			angleX+=d_angle;	
			break;
		}
	}
glutPostRedisplay(); //Требуем перерисовки окна
}


//--------- Пирамида --------------------------------------------

void Pyramid( GLfloat x1, GLfloat x2, GLfloat y1, GLfloat y2, 
	          GLfloat z1,GLfloat z2)
{		
//Основание ABCD: A(x1,y1,z1),B(x2,y1,z1),C(x2,y2,z1),D(x1,y2,z1)
//Вершина E(0,0,z2)

        glBegin ( GL_POLYGON );       //Основание 
          glVertex3f ( x2, y1, z1 );  //D
          glVertex3f ( x1, y1, z1 );  //A
          glVertex3f ( x1, y2, z1 );  //B
          glVertex3f ( x2, y2, z1 );	//C
        glEnd ();

		glBegin ( GL_POLYGON );       //EDC
   	      glVertex3f ( 0, 0, z2 );	  //E
          glVertex3f ( x2, y1, z1 );  //D
          glVertex3f ( x2, y2, z1 );  //C         
        glEnd ();

		glBegin ( GL_POLYGON );       //ECB
          glVertex3f ( 0, 0, z2 );	  //E
	      glVertex3f ( x2, y2, z1 );  //C  
          glVertex3f ( x1, y2, z1 );  //B					       
        glEnd ();

		glBegin ( GL_POLYGON );       //EBA
          glVertex3f ( 0, 0, z2 );	  //E
          glVertex3f ( x1, y2, z1 );  //B	
		  glVertex3f ( x1, y1, z1 );  //A
        glEnd ();

		glBegin ( GL_POLYGON );       //EAD
          glVertex3f ( 0, 0, z2 );	  //E
          glVertex3f ( x1, y1, z1 );  //A
          glVertex3f ( x2, y1, z1 );  //D

        glEnd ();	
        
}


//-----------------------------------------------------------------

void    Box ( GLfloat x1, GLfloat x2, GLfloat y1, GLfloat y2, 
	          GLfloat z1, GLfloat z2)
{				
        glBegin ( GL_POLYGON );      // front face 
          glVertex3f ( x1, y1, z2 );
          glVertex3f ( x2, y1, z2 );
          glVertex3f ( x2, y2, z2 );
          glVertex3f ( x1, y2, z2 );
        glEnd ();

        glBegin ( GL_POLYGON );       // back face
          glVertex3f ( x2, y1, z1 );
          glVertex3f ( x1, y1, z1 );
          glVertex3f ( x1, y2, z1 );
          glVertex3f ( x2, y2, z1 );
        glEnd ();

        glBegin ( GL_POLYGON );       // left face
          glVertex3f ( x1, y1, z1 );
          glVertex3f ( x1, y1, z2 );
          glVertex3f ( x1, y2, z2 );
          glVertex3f ( x1, y2, z1 );
        glEnd ();

        glBegin ( GL_POLYGON);        // right face
          glVertex3f ( x2, y1, z2 );
          glVertex3f ( x2, y1, z1 );
          glVertex3f ( x2, y2, z1 );
          glVertex3f ( x2, y2, z2 );
        glEnd ();

        glBegin ( GL_POLYGON );       // top face
          glVertex3f ( x1, y2, z2 );
          glVertex3f ( x2, y2, z2 );
          glVertex3f ( x2, y2, z1 );
          glVertex3f ( x1, y2, z1 );
        glEnd ();

        glBegin ( GL_POLYGON );       // bottom face
          glVertex3f ( x2, y1, z2 );
          glVertex3f ( x1, y1, z2 );
          glVertex3f ( x1, y1, z1 );
          glVertex3f ( x2, y1, z1 );
        glEnd ();
}

 
//================ main ============================================

int main(int argc, char *argv[]) 
{ 
//----- Функции библиотеки GLUT ------------------------------------

    glutInit(&argc, argv); // Инициализация библиотеки GLUT
//Используется режим RGB для выбора цвета,одинарный видеобуфер,
//допускается использование теста глубины
    glutInitDisplayMode(GLUT_RGB|GLUT_SINGLE| GLUT_DEPTH ); 
// Координаты левого верхнего угла окна OpenGL на экране монитора		                                           
	glutInitWindowPosition  (x_win,y_win);     
//Ширина и высота окна OpenGL                                            
    glutInitWindowSize(Width, Height); 
//Создание окна с заголовком
	glutCreateWindow("Пример.    Рисование примитивов");
//Регистрация функции обратного вызова OnDraw - вызывается
//системой при необходимости перерисовать окно (аналог OnPaint в MFC) 
    glutDisplayFunc(OnDraw); 
//Регистрация функции обратного вызова OnSize - вызывается	 
//системой при изменении размеров окна (аналог OnSize в MFC) 
    glutReshapeFunc(OnSize); 
//Регистрация функции обратного вызова Keyboard -вызывается	
//системой при при нажати клавиши, имеющей ASCII-код 
    glutKeyboardFunc(Keyboard); 
//Регистрация функции обратного вызова SpesialKey -вызывается    
//системой при при нажати клавиши, НЕ имеющей ASCII-кода 
	glutSpecialFunc(SpecialKey);
//Запуск бесконечного цикла обработки сообщений Windows                              
    glutMainLoop(); 
//---------------------------------------------------------------------
	return 0;
} 
 
 