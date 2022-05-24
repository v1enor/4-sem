#include "Figures.h"
 const float pi=3.14159;
//---- Глобальные переменные---------------------------------
GLint x_win=100;     // x - координата левого верхнего угла окна OpenGL на экране
GLint y_win=50;     // y - координата левого верхнего угла окна OpenGL на экране
GLint Width = 800;	  // Начальная ширина окна 
GLint Height = 600;   // Начальная высота окна 
GLint left,right,top,bottom,znear,zfar; // Для определения области видимости графических
                             //данных после проектирования в СКН
GLint Index=0;  // Для выбора рисунка

float angleX=0;    // Угол для поворота вокруг оси X, град
float angleY=0;    // Угол для поворота вокруг оси X, град
float d_angle=10;    // Шаг изменеия угла, град

 
//------ Эта функция управляет всем выводом на экран----------- 
void OnDraw(void) 
{   
	//glClearColor(1.0,1.0,1.0,0.0); // Если нужен одинаковый фон для всех значений Index
	//glClear(GL_COLOR_BUFFER_BIT); 
	switch(Index)
	{
		case 0:
		{
			glClearColor(1.0,1.0,1.0,0.0);
			glClear(GL_COLOR_BUFFER_BIT); 
			glutSwapBuffers(); // Переключение буферов (Обязательно 
	                   // при использовании двойной буферизации GLUT_DOUBLE
			break;
		}

		case 1:
		{
			glClearColor(0.0,0.0,0.0,0.0); //Цвет фона в окне
			//glEnable     ( GL_DEPTH_TEST );
			glClear(GL_COLOR_BUFFER_BIT| GL_DEPTH_BUFFER_BIT );  // Очистить буфер цвета - залить цветом фона		
			glColor3ub(255,0,0);	// Цвет линии 
			glLineWidth(1.0) ;	    // Толщина линии

			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 	// Видовая матрица  M=I	
			glRotatef(angleY,0.0,1.0,0.0); // Вокруг оси Y, M=Ry(angleY) 
			glRotatef(angleX,1.0,0.0,0.0); // Вокруг оси X, M=Ry(angleY)*Rx(angleX) 
			// Результат V2=Ry*Rx*V1
					
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10; znear=-10; zfar=10;
			glOrtho(left, right, bottom, top,znear,zfar); 

			//glEnable (GL_CULL_FACE);
			//glCullFace (GL_FRONT );
			//glCullFace (GL_BACK );
					
			glPolygonMode (GL_FRONT_AND_BACK ,GL_LINE); 

			GLfloat x1=-2.5, x2=2.5,y1=-2.5,y2=2.5,z1=0.0,z2=5;
			Pyramid(x1,x2,y1,y2,z1,z2);
			glutSwapBuffers(); // Переключение буферов (Обязательно 
	                   // при использовании двойной буферизации GLUT_DOUBLE
			break;
			
		}

		case 2:
		{
			glClearColor(0.0,0.0,0.0,0.0); //Цвет фона в окне
			//glEnable     ( GL_DEPTH_TEST );
			glClear(GL_COLOR_BUFFER_BIT| GL_DEPTH_BUFFER_BIT );  // Очистить буфер цвета - залить цветом фона		
			glColor3ub(255,0,0);	// Цвет линии 
			glLineWidth(1.0) ;	    // Толщина линии

			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 	// Видовая матрица  M=I	
			glRotatef(angleY,0.0,1.0,0.0); // Вокруг оси Y, M=Ry(angleY) 
			glRotatef(angleX,1.0,0.0,0.0); // Вокруг оси X, M=Ry(angleY)*Rx(angleX) 
			// Результат V2=Ry*Rx*V1
					
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10; znear=-10; zfar=10;
			glOrtho(left, right, bottom, top,znear,zfar); 

			glEnable (GL_CULL_FACE);
			glCullFace (GL_BACK );
					
			glPolygonMode (GL_FRONT_AND_BACK ,GL_LINE); 

			GLfloat x1=-2.5, x2=2.5,y1=-2.5,y2=2.5,z1=0.0,z2=5;
			Pyramid(x1,x2,y1,y2,z1,z2);
			glutSwapBuffers(); // Переключение буферов (Обязательно 
	                           // при использовании двойной буферизации GLUT_DOUBLE
			break;
			
		}
		case 3:
		{
			glClearColor(0.0,0.0,0.0,0.0); //Цвет фона в окне
			glClear(GL_COLOR_BUFFER_BIT| GL_DEPTH_BUFFER_BIT );  // Очистить буфер цвета - залить цветом фона		
			glColor3ub(255,0,0);	// Цвет линии 
			glLineWidth(1.0) ;	    // Толщина линии

			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 
			glRotatef(angleY,0.0,1.0,0.0); // Вокруг оси Y, M=Ry(angleY) 
			glRotatef(angleX,1.0,0.0,0.0); // Вокруг оси X, M=Ry(angleY)*Rx(angleX) 
			// Результат V2=Ry*Rx*V1
					
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10; znear=-10; zfar=10;
			glOrtho(left, right, bottom, top,znear,zfar); 

			glEnable (GL_CULL_FACE);
			//glCullFace (GL_FRONT );
			glCullFace (GL_BACK );
					
			glPolygonMode (GL_FRONT_AND_BACK ,GL_LINE); 

			GLfloat x1=-2.5, x2=2.5,y1=-5,y2=5,z1=-5,z2=5;
			Box(x1,x2,y1,y2,z1,z2);
			glutSwapBuffers(); // Переключение буферов (Обязательно 
	                           // при использовании двойной буферизации GLUT_DOUBLE
			break;		
		}
		case 4: //Показывать
		{
			glClearColor(1.0,1.0,1.0,0.0); //Цвет фона в окне		
			glClear(GL_COLOR_BUFFER_BIT| GL_DEPTH_BUFFER_BIT );  // Очистить буфер цвета - залить цветом фона	
			glEnable     ( GL_DEPTH_TEST );	// Разрешаем тест глубины !!!!!
			//glColor3ub(255,0,0);	// Цвет линии 
			//glLineWidth(1.0) ;	    // Толщина линии

			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 
			glRotatef(angleY,0.0,1.0,0.0); // Вокруг оси Y, M=Ry(angleY) 
			glRotatef(angleX,1.0,0.0,0.0); // Вокруг оси X, M=Ry(angleY)*Rx(angleX) 
			// Результат V2=Ry*Rx*V1
					
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10; znear=-15; zfar=15;
			glOrtho(left, right, bottom, top,znear,zfar); 

			glEnable (GL_CULL_FACE);
			glCullFace (GL_BACK );
					
			//glPolygonMode (GL_FRONT_AND_BACK ,GL_FILL); 

			GLfloat x1=-2.5, x2=2.5,y1=-2.5,y2=2.5,z1=-2.5,z2=2.5;
			Box(x1,x2,y1,y2,z1,z2);

//--------------- Пирамида --------------------------------------
			glColor3ub(0,0,255);	// Цвет линии 
			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 	// Видовая матрица  M=I	
			
			glRotatef(angleY,0.0,1.0,0.0); // Вокруг оси Y, M=Ry(angleY) 
			glRotatef(angleX,1.0,0.0,0.0); // Вокруг оси X, M=Ry(angleY)*Rx(angleX)
			glTranslatef(0.0,0.0,-10.0);	// Смещение	
			// Результат V2=Ry*Rx*V1*Txyz
					
			//glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			//glLoadIdentity(); 
			//left=-10; right=10; bottom=-10; top=10; znear=-10; zfar=10;
			//glOrtho(left, right, bottom, top,znear,zfar); 

			//glEnable (GL_CULL_FACE);
			//glCullFace (GL_BACK );
			//		
			//glPolygonMode (GL_FRONT_AND_BACK ,GL_LINE); 

		    x1=-2.5, x2=2.5,y1=-2.5,y2=2.5,z1=0.0,z2=5.0;
			Pyramid(x1,x2,y1,y2,z1,z2);
			glutSwapBuffers(); // Переключение буферов (Обязательно 
							   // при использовании двойной буферизации GLUT_DOUBLE

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

 
//-- Функция обрабатывает сообщения от клавиш, имеющих ASCII - код  -------

void Keyboard( unsigned char key, int x, int y )
{ 
#define ESCAPE '\033' 
 
if( key == ESCAPE ) exit(0);
         
switch(key)
{
	case'a':case'A':	// Gbhfvblf
		{
			Index=1;
			break;
		}
	case'b':case'B':	// Пирамида
		{
			Index=2;
			break;
		}

	case'c':case'C':	// Параллепипед с удалением нелицевых граней
		{
			
			Index=3;
			break;
		}

	case'd':case'D':	//  Пирамида и параллепипед - показывать
		{
			Index=4;
			break;
		}
}

glutPostRedisplay();

} 

//-- Функция обрабатывает сообщения от клавиш, НЕ имеющих ASCII - кода  -------

void SpecialKey(int key, int x, int y )
{
	switch(key)
	{
		case GLUT_KEY_RIGHT:	// Стрелка вправо (102)
		{
			angleY+=d_angle;		
			break;
		}
		case GLUT_KEY_LEFT:	// Стрелка влево (100)
		{
			angleY-=d_angle;	
			break;
		}
		case GLUT_KEY_UP:	// Стрелка вверх (101)
		{
			angleX-=d_angle;		
			break;
		}
		case GLUT_KEY_DOWN:	// Стрелка вниз (103)
		{
			angleX+=d_angle;	
			break;
		}
	}
glutPostRedisplay();
}


//--------- Пирамида --------------------------------------------

void Pyramid( GLfloat x1, GLfloat x2, GLfloat y1, GLfloat y2, GLfloat z1,GLfloat z2)
{		
//Основание ABCD: A(x1,y1,z1),B(x2,y1,z1),C(x2,y2,z1),D(x1,y2,z1)
//Вершина E(0,0,z2)

        glBegin ( GL_POLYGON );         // Основание 
         
glColor3ub(255,0,0);	// Цвет вершины 
	      glVertex3f ( x2, y1, z1 );	//D
glColor3ub(0,255,0);	// Цвет вершины 
          glVertex3f ( x1, y1, z1 );	//A
glColor3ub(0,0,255);	// Цвет вершины 
          glVertex3f ( x1, y2, z1 );	//B
glColor3ub(255,255,0);	// Цвет вершины 
          glVertex3f ( x2, y2, z1 );	//C
        glEnd ();

		

				glBegin ( GL_POLYGON );         // EDC
  glColor3ub(0,0,255);	// Цвет вершины         
					glVertex3f ( 0, 0, z2 );	//E
glColor3ub(0,0,120);	// Цвет вершины 
          glVertex3f ( x2, y1, z1 );	//D
glColor3ub(0,0,0);	// Цвет вершины 
					glVertex3f ( x2, y2, z1 );	//C         
        glEnd ();



				glBegin ( GL_POLYGON );         // ECB
glColor3ub(0,0,255);	// Цвет вершины          
					glVertex3f ( 0, 0, z2 );	//E
glColor3ub(0,0,120);	// Цвет вершины 
					glVertex3f ( x2, y2, z1 );	//C 
glColor3ub(0,0,0);	// Цвет вершины 
          glVertex3f ( x1, y2, z1 );	//B					       
        glEnd ();

				glBegin ( GL_POLYGON );         // EBA
glColor3ub(0,0,255);	// Цвет вершины            
					glVertex3f ( 0, 0, z2 );	//E
glColor3ub(0,0,120);	// Цвет вершины 
					glVertex3f ( x1, y2, z1 );	//B	
glColor3ub(0,0,0);	// Цвет вершины 
					glVertex3f ( x1, y1, z1 );	//A
        glEnd ();

				glBegin ( GL_POLYGON );         // EAD
glColor3ub(0,0,255);	// Цвет вершины            
					glVertex3f ( 0, 0, z2 );	//E
glColor3ub(0,0,120);	// Цвет вершины 
					glVertex3f ( x1, y1, z1 );	//A
glColor3ub(0,0,0);	// Цвет вершины 
					glVertex3f ( x2, y1, z1 );	//D

        glEnd ();	
        
}


//-----------------------------------------------------------------

void    Box ( GLfloat x1, GLfloat x2, GLfloat y1, GLfloat y2, GLfloat z1, GLfloat z2)
{				
        glBegin ( GL_POLYGON );     // front face - обход по часовой стрелке 
			glColor3ub(255,0,0);	// Цвет вершины  
			glVertex3f ( x1, y1, z2 );
			glColor3ub(200,0,0);	// Цвет вершины  
			glVertex3f ( x2, y1, z2 );
			glColor3ub(150,0,0);	// Цвет вершины  
			glVertex3f ( x2, y2, z2 );
			glColor3ub(50,0,0);	// Цвет вершины  
			glVertex3f ( x1, y2, z2 );
        glEnd ();

        glBegin ( GL_POLYGON );         // back face
			glColor3ub(255,0,0);	// Цвет вершины            
			glVertex3f ( x2, y1, z1 );
			glColor3ub(200,0,0);	// Цвет вершины 
			glVertex3f ( x1, y1, z1 );
			glColor3ub(150,0,0);	// Цвет вершины  
		    glVertex3f ( x1, y2, z1 );
			glColor3ub(50,0,0);	// Цвет вершины  
            glVertex3f ( x2, y2, z1 );
        glEnd ();

        glBegin ( GL_POLYGON );         // left face
			glColor3ub(255,0,0);	// Цвет вершины           
			glVertex3f ( x1, y1, z1 );
			glColor3ub(200,0,0);	// Цвет вершины 
			glVertex3f ( x1, y1, z2 );
			glColor3ub(150,0,0);	// Цвет вершины  
			glVertex3f ( x1, y2, z2 );
			glColor3ub(50,0,0);	// Цвет вершины  
			glVertex3f ( x1, y2, z1 );
        glEnd ();

        glBegin ( GL_POLYGON);         // right face
			glColor3ub(255,0,0);	// Цвет вершины               
			glVertex3f ( x2, y1, z2 );
			glColor3ub(200,0,0);	// Цвет вершины     
			glVertex3f ( x2, y1, z1 );
			glColor3ub(150,0,0);	// Цвет вершины     
			glVertex3f ( x2, y2, z1 );
			glColor3ub(50,0,0);	// Цвет вершины     
			glVertex3f ( x2, y2, z2 );

        glEnd ();

        glBegin ( GL_POLYGON );         // top face
			glColor3ub(255,0,0);	// Цвет вершины           
			glVertex3f ( x1, y2, z2 );
			glColor3ub(200,0,0);	// Цвет вершины    
			glVertex3f ( x2, y2, z2 );
			glColor3ub(150,0,0);	// Цвет вершины
			glVertex3f ( x2, y2, z1 );
			glColor3ub(50,0,0);	// Цвет вершины
			glVertex3f ( x1, y2, z1 );
        glEnd ();

        glBegin ( GL_POLYGON );         // bottom face
			glColor3ub(255,0,0);	// Цвет вершины                 
			glVertex3f ( x2, y1, z2 );
			glColor3ub(200,0,0);	// Цвет вершины    
			glVertex3f ( x1, y1, z2 );
			glColor3ub(150,0,0);	// Цвет вершины
			glVertex3f ( x1, y1, z1 );
			glColor3ub(50,0,0);	// Цвет вершины
			glVertex3f ( x2, y1, z1 );
        glEnd ();
}

 
//================ main ==================================================
int main(int argc, char *argv[]) 
{ 
//----- Функции библиотеки GLUT ------------------------------------------
    glutInit(&argc, argv); // Инициализация библиотеки GLUT
//Используется режим RGB для выбора цвета,одинарный видеобуфер,
//допускается использование теста глубины
    glutInitDisplayMode(GLUT_RGB|GLUT_DOUBLE| GLUT_DEPTH ); 
			                                           
	glutInitWindowPosition  (x_win,y_win);     // Координаты левого верхнего угла 
	                                           //окна OpenGL на экране монитора
    glutInitWindowSize(Width, Height);         //Ширина и высота окна OpenGL 
	glutCreateWindow("Пример_4.   Две фигуры"); //Создание окна с заголовком
    glutDisplayFunc(OnDraw); // Регистрация функции обратного вызова OnDraw - вызывается
	                         // системой при необходимости перерисовать окно (аналог OnPaint в MFC) 
    glutReshapeFunc(OnSize); // Регистрация функции обратного вызова OnSize - вызывается
	                         // системой при изменении размеров окна (аналог OnSize в MFC) 
    glutKeyboardFunc(Keyboard); // Регистрация функции обратного вызова Keyboard -вызывается
                                // системой при при нажати клавиши, имеющей ASCII-код 
	glutSpecialFunc(SpecialKey);// Регистрация функции обратного вызова SpesialKey -вызывается
                                // системой при при нажати клавиши, НЕ имеющей ASCII-кода 
    glutMainLoop(); //Запуск бесконечного цикла обработки сообщений Windows
//-------------------------------------------------------------------------------

	return 0;
} 
 
 