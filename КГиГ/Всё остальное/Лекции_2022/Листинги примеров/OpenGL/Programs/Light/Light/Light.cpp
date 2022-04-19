#include "Light.h"

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


//Параметры материала парпллелепипеда 
float mat1_dif[]={0.8f,0.8f,0.0f}; 
float mat1_amb[]= {0.2f,0.2f,0.2f}; 
float mat1_spec[]={0.6f,0.6f,0.6f}; 
float mat1_shininess=0.5f*128; 

 
 //Параметры материала пирамиды 
float mat3_dif[]={0.9f,0.2f,0.0f}; 
float mat3_amb[]= {0.2f,0.2f,0.2f}; 
float mat3_spec[]={0.6f,0.6f,0.6f}; 
float mat3_shininess=0.1f*128; 
 



//------ Эта функция управляет всем выводом на экран----------- 
void OnDraw(void) 
{   
	switch(Index)
	{
		case 0:
		{
			Init();
			glClearColor(1.0,1.0,1.0,0.0);
			glClear(GL_COLOR_BUFFER_BIT| GL_DEPTH_BUFFER_BIT ); 
			glutSwapBuffers(); // Переключение буферов (Обязательно 
	                   // при использовании двойной буферизации GLUT_DOUBLE
			break;
		}

		case 1:
		{
			glClearColor(1.0,1.0,1.0,0.0); //Цвет фона в окне
			glClear(GL_COLOR_BUFFER_BIT| GL_DEPTH_BUFFER_BIT );  // Очистить буфер цвета - залить цветом фона		
			
			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 
			glRotatef(angleY,0.0,1.0,0.0); // Вокруг оси Y, M=Ry(angleY) 
			glRotatef(angleX,1.0,0.0,0.0); // Вокруг оси X, M=Ry(angleY)*Rx(angleX) 
			// Результат V2=Ry*Rx*V1
					
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10; znear=-10; zfar=10;
			glOrtho(left, right, bottom, top,znear,zfar); 

			glMaterialfv (GL_FRONT,GL_AMBIENT,mat1_amb); 
			glMaterialfv (GL_FRONT,GL_DIFFUSE,mat1_dif); 
			glMaterialfv (GL_FRONT,GL_SPECULAR,mat1_spec); 
			glMaterialf  (GL_FRONT,GL_SHININESS,mat1_shininess); 

			GLfloat x1=-2.5, x2=2.5,y1=-5,y2=5,z1=-5,z2=5;
			Box(x1,x2,y1,y2,z1,z2);
			glutSwapBuffers(); // Переключение буферов (Обязательно 
	                           // при использовании двойной буферизации GLUT_DOUBLE
			break;		
			
			
		}

		case 2:
		{
		
			glClearColor(1.0,1.0,1.0,0.0); //Цвет фона в окне
			glClear(GL_COLOR_BUFFER_BIT| GL_DEPTH_BUFFER_BIT );  // Очистить буфер цвета - залить цветом фона		
			
			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 
			glRotatef(angleY,0.0,1.0,0.0); // Вокруг оси Y, M=Ry(angleY) 
			glRotatef(angleX,1.0,0.0,0.0); // Вокруг оси X, M=Ry(angleY)*Rx(angleX) 
			// Результат V2=Ry*Rx*V1
					
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10; znear=-10; zfar=10;
			glOrtho(left, right, bottom, top,znear,zfar); 

			glMaterialfv (GL_FRONT,GL_AMBIENT,mat3_amb); 
			glMaterialfv (GL_FRONT,GL_DIFFUSE,mat3_dif); 
			glMaterialfv (GL_FRONT,GL_SPECULAR,mat3_spec); 
			glMaterialf  (GL_FRONT,GL_SHININESS,mat3_shininess); 
			GLfloat x1=-2.5, x2=2.5,y1=-5,y2=5,z1=-5,z2=5;	
			Pyramid(x1,x2,y1,y2,z1,z2);

			glutSwapBuffers(); // Переключение буферов (Обязательно 
	                           // при использовании двойной буферизации GLUT_DOUBLE
			break;		
			
			
			
		}
		case 3:
		{
			
		}
		case 4:
		{
			
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
	case'a':case'A':	// Параллепипед
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

	case'd':case'D':	//  Пирамида и параллепипед
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

//------------------ Init()-------------------------------------
 
void Init () 
// Инициализация параметров материалов и источника света 

{ 
   GLfloat light_ambient[] = { 0.0, 0.0, 0.0, 1.0 }; 
   GLfloat light_diffuse[] = { 1.0, 1.0, 1.0, 1.0 }; 
   GLfloat light_specular[] = { 1.0, 1.0, 1.0, 1.0 }; 
   GLfloat light_position[] = { 0.0, 0.0, 1.0, 0.0 }; 

   //устанавливаем параметры источника света  
   glLightfv (GL_LIGHT0, GL_AMBIENT, light_ambient); 
   glLightfv (GL_LIGHT0, GL_DIFFUSE, light_diffuse); 
   glLightfv (GL_LIGHT0, GL_SPECULAR, light_specular);
   glLightfv (GL_LIGHT0, GL_POSITION, light_position);
 
   // включаем освещение и источник света  
   glEnable (GL_LIGHTING); 
   glEnable (GL_LIGHT0); 
   // Разрешаем тест глубины
   glEnable(GL_DEPTH_TEST);
  
} 



//--------- Пирамида --------------------------------------------

void Pyramid( GLfloat x1, GLfloat x2, GLfloat y1, GLfloat y2, GLfloat z1,GLfloat z2)
{		
//Основание ABCD: A(x1,y1,z1),B(x2,y1,z1),C(x2,y2,z1),D(x1,y2,z1)
//Вершина E(0,0,z2)
GLfloat VN[3]; //Вектор нормали;
Point A(x1,y1,z1),B(x2,y1,z1),C(x2,y2,z1),D(x1,y2,z1),E(0,0,z2);

		GetNormal(A,B,D,VN); // Внешняяя нормаль к основанию
        glBegin ( GL_POLYGON );         // Основание 
          glNormal3fv (VN);
          glVertex3f ( x2, y1, z1 );	//D
          glVertex3f ( x1, y1, z1 );	//A
          glVertex3f ( x1, y2, z1 );	//B
          glVertex3f ( x2, y2, z1 );	//C
        glEnd ();

		GetNormal(E,D,C,VN); // Внешняяя нормаль к EDC
		glBegin ( GL_POLYGON );         // EDC
		  glNormal3fv (VN);
		  glVertex3f ( 0, 0, z2 );	//E
          glVertex3f ( x2, y1, z1 );	//D
	      glVertex3f ( x2, y2, z1 );	//C         
        glEnd ();

		GetNormal(E,C,B,VN); // Внешняяя нормаль к ECB
		glBegin ( GL_POLYGON );         // ECB
          glNormal3fv (VN);
		  glVertex3f ( 0, 0, z2 );	//E
		  glVertex3f ( x2, y2, z1 );	//C  
          glVertex3f ( x1, y2, z1 );	//B					       
        glEnd ();

		GetNormal(E,B,A,VN); // Внешняяя нормаль к EBA
		glBegin ( GL_POLYGON );         // EBA
		  glNormal3fv (VN);
		  glVertex3f ( 0, 0, z2 );	//E
		  glVertex3f ( x1, y2, z1 );	//B	
		  glVertex3f ( x1, y1, z1 );	//A
        glEnd ();

		GetNormal(E,A,D,VN); // Внешняяя нормаль к EAD
		glBegin ( GL_POLYGON );         // EAD
          glNormal3fv (VN);
		  glVertex3f ( 0, 0, z2 );	//E
		  glVertex3f ( x1, y1, z1 );	//A
		  glVertex3f ( x2, y1, z1 );	//D
        glEnd ();	
        
}


//-----------------------------------------------------------------

void    Box ( GLfloat x1, GLfloat x2, GLfloat y1, GLfloat y2, GLfloat z1, GLfloat z2)
{				
        glBegin ( GL_POLYGON );         // front face - обход по часовой стрелке 
          glNormal3f ( 0.0, 0.0, 1.0 );
          glVertex3f ( x1, y1, z2 );
          glVertex3f ( x2, y1, z2 );
          glVertex3f ( x2, y2, z2 );
          glVertex3f ( x1, y2, z2 );
        glEnd ();

        glBegin ( GL_POLYGON );         // back face
          glNormal3f ( 0.0, 0.0, -1.0 );
          glVertex3f ( x2, y1, z1 );
          glVertex3f ( x1, y1, z1 );
          glVertex3f ( x1, y2, z1 );
          glVertex3f ( x2, y2, z1 );
        glEnd ();

        glBegin ( GL_POLYGON );         // left face
          glNormal3f ( -1.0, 0.0, 0.0 );
          glVertex3f ( x1, y1, z1 );
          glVertex3f ( x1, y1, z2 );
          glVertex3f ( x1, y2, z2 );
          glVertex3f ( x1, y2, z1 );
        glEnd ();

        glBegin ( GL_POLYGON);         // right face
          glNormal3f ( 1.0, 0.0, 0.0 );
          glVertex3f ( x2, y1, z2 );
          glVertex3f ( x2, y1, z1 );
          glVertex3f ( x2, y2, z1 );
          glVertex3f ( x2, y2, z2 );
        glEnd ();

        glBegin ( GL_POLYGON );         // top face
          glNormal3f ( 0.0, 1.0, 0.0 );
          glVertex3f ( x1, y2, z2 );
          glVertex3f ( x2, y2, z2 );
          glVertex3f ( x2, y2, z1 );
          glVertex3f ( x1, y2, z1 );
        glEnd ();

        glBegin ( GL_POLYGON );         // bottom face
          glNormal3f ( 0.0, -1.0, 0.0 );
          glVertex3f ( x2, y1, z2 );
          glVertex3f ( x1, y1, z2 );
          glVertex3f ( x1, y1, z1 );
          glVertex3f ( x2, y1, z1 );
        glEnd ();
}

//-------------GetNormal-------------------------------------
void GetNormal(Point &P1,Point &P2,Point &P3,GLfloat *VN)
// Вычисляет ЕДИНИЧНЫЙ вектор нормали к плоскости,определяемой
// точками P1,P2,P3(P=(P.x,P.y,P.z)
// Вектора P1P2, P1P3 и VN образуют правую тройку 
// Результат записывается в вектор VN[3]
{
	double V1[3]={P2.x-P1.x,P2.y-P1.y,P2.z-P1.z}; //P1P2
	double V2[3]={P3.x-P1.x,P3.y-P1.y,P3.z-P1.z}; //P1P3
	double x=V1[1]*V2[2]-V1[2]*V2[1];
	double y=-(V1[0]*V2[2]-V1[2]*V2[0]);
	double z=V1[0]*V2[1]-V1[1]*V2[0];
	double r=sqrt(x*x+y*y+z*z);
	VN[0]=x/r;
	VN[1]=y/r;
	VN[2]=z/r;
}

 
//================ main ==================================================
int main(int argc, char *argv[]) 
{ 
//----- Функции библиотеки GLUT ------------------------------------------
    glutInit(&argc, argv); // Инициализация библиотеки GLUT
//Используется режим RGB для выбора цвета,одинарный видеобуфер,
//допускается использование теста глубины
    glutInitDisplayMode(GLUT_RGB|GLUT_DOUBLE); 
			                                           
		glutInitWindowPosition  (x_win,y_win);     // Координаты левого верхнего угла 
	                                           //окна OpenGL на экране монитора
    glutInitWindowSize(Width, Height);         //Ширина и высота окна OpenGL 
		glutCreateWindow("Пример_4.  Свет"); //Создание окна с заголовком
	
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
 
 