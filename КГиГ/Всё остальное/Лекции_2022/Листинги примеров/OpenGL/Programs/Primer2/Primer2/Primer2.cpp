#include "Primer2.h"
 const float pi=3.14159;
//---- Глобальные переменные---------------------------------
GLint x_win=100;     // x - координата левого верхнего угла окна OpenGL на экране
GLint y_win=50;     // y - координата левого верхнего угла окна OpenGL на экране
GLint Width = 800;	  // Начальная ширина окна 
GLint Height = 600;   // Начальная высота окна 
GLint left,right,top,bottom; // Для определения области видимости графических
                             //данных после проектирования в СКН
GLint Index=0;  // Для выбора рисунка
float **MasFunc=NULL; // Для массива значений функции
int NamberPoints; // Число точек для графика функции
float angle=0;    // Угол для поворота треугольника, град
float d_angle=10;    // Шаг изменеия угла, град
char MyText1[]="Font GLUT_BITMAP_8_BY_13 ";
char MyText2[]="Font GLUT_BITMAP_9_BY_15 ";
char MyText3[]="Font  GLUT_BITMAP_TIMES_ROMAN_10";
char MyText4[]="Font GLUT_BITMAP_HELVETICA_12";
char MyText5[]="Font GLUT_BITMAP_HELVETICA_18";
 
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
			break;
		}

		case 1:
		{
			glClearColor(0.0,0.0,0.0,0.0); //Цвет фона в окне
			glClear(GL_COLOR_BUFFER_BIT);  // Очистить буфер цвета - залить цветом фона		
			glColor3ub(255,255,0);	// Цвет линии 
			glLineWidth(3.0) ;	    // Толщина линии

			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 
			glRotatef(angle,0.0,0.0,1.0); //  
			
			
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10;
			gluOrtho2D(left, right, bottom, top); // (left,bottom)- (right,top)
			Triangle();
			break;
		}

		case 2:
		{
			glClearColor(0.0,1.0,0.0,0.0); //Цвет фона в окне
			glClear(GL_COLOR_BUFFER_BIT);  // Очистить буфер цвета - залить цветом фона	
			glColor3ub(0,0,255);	       // Цвет линии 

			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 	
			
			
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-10; right=10; bottom=-10; top=10;
			gluOrtho2D(left, right, bottom, top); // (left,bottom)- (right,top)
			Rectangle();
			break;
		}
		case 3:
		{
			glClearColor(1.0,1.0,1.0,0.0); //Цвет фона в окне
			glClear(GL_COLOR_BUFFER_BIT);  // Очистить буфер цвета - залить цветом фона	
			//glColor3ub(0,0,0);	// Цвет линии 
			//glLineWidth(2.0) ;	// Толщина линии
			
			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 

			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			//left=-10; right=10; bottom=-10; top=10;
			gluOrtho2D(left, right, bottom, top); // (left,bottom)- (right,top)
			MyFunction();
			break;
		}

		case 4:
		{
			glClearColor(1.0,1.0,1.0,0.0);
			glClear(GL_COLOR_BUFFER_BIT); 

			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 

			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-30; right=30; bottom=-30; top=30;
			gluOrtho2D(left, right, bottom, top); // (left,bottom)- (right,top)

			glColor3ub(0,0,0);	// Цвет текста
			glRasterPos2i(-10,0);
			int len=strnlen(MyText1,100);
			for(int i=0;i<len;i++)glutBitmapCharacter(GLUT_BITMAP_8_BY_13,MyText1[i]);

			glColor3ub(255,0,0);	// Цвет текста
			glRasterPos2i(-10,3);
			len=strnlen(MyText2,100);
			for(int i=0;i<len;i++)glutBitmapCharacter(GLUT_BITMAP_9_BY_15,MyText2[i]);
			
			glColor3ub(0,255,0);	// Цвет текста
			glRasterPos2i(-10,6);
			len=strnlen(MyText3,100);
			for(int i=0;i<len;i++)glutBitmapCharacter(GLUT_BITMAP_TIMES_ROMAN_10,MyText3[i]);
			glColor3ub(0,0,255);	// Цвет текста
			glRasterPos2i(-10,9);
			len=strnlen(MyText4,100);
			for(int i=0;i<len;i++)glutBitmapCharacter(GLUT_BITMAP_HELVETICA_12,MyText4[i]);

			glColor3ub(0,125,125);	// Цвет текста
			glRasterPos2i(-10,12);
			len=strnlen(MyText5,100);
			for(int i=0;i<len;i++)glutBitmapCharacter(GLUT_BITMAP_HELVETICA_18,MyText5[i]);


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
//if( key == ESCAPE ) Index=1;
         
switch(key)
{
	case'a':case'A':	// Треугольник
		{
			Index=1;
			break;
		}
	case'b':case'B':	// Закрашенный прямоугольник
		{
			Index=2;
			break;
		}

	case'f':case'F':	// График функции
		{
			if(MasFunc!=NULL)MasFunc=NULL;

			float x_begin=-8*pi, x_end=8*pi, dx=pi/10;
			NamberPoints=(int)((x_end-x_begin)/dx)+1;	//Число отсчетов аргумента
			
			MasFunc=new float*[NamberPoints];
			for(int i=0;i<NamberPoints;i++) MasFunc[i]=new float[2];
			
			CreateMasFunc(MyF1,x_begin,dx,NamberPoints,MasFunc);
			float maxF=MasFunc[0][1];
			for(int i=0;i<NamberPoints;i++)	//Поиск максимального значения y
			{
				if(maxF<MasFunc[i][1])maxF=MasFunc[i][1];
			}
			left=x_begin; right=x_end; bottom=-maxF; top=maxF;
			Index=3;
			break;
		}

	case't':case'T':	// Вывод текста
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
			angle+=d_angle;		
			break;
		}
		case GLUT_KEY_LEFT:	// Стрелка влево (100)
		{
			angle-=d_angle;	
			break;
		}
	}

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
	  /*glVertex2f(-5.0,-5.0); 
	  glVertex2f(-5.0,5.0); 
	  glVertex2f(5.0,5.0); 
	  glVertex2f(5.0,-5.0); */

      for(int i=0;i<4;i++) glVertex2fv(VectCoords[i]); 
    glEnd(); 	
}

//------------- MyFunction ------------------------------------------
void MyFunction()
{
	if(left*right<0)        // Нужна ось Y -?
	{	
		glColor3ub(0,0,255);	// Цвет линии 
		glLineWidth(3.0) ;	    // Толщина линии
		glBegin(GL_LINE_STRIP); // Ось y
		  glVertex2f(0,bottom); 
		  glVertex2f(0,top);     
		glEnd(); 
	}

	if(top*bottom<0)        // Нужна ось X -?
	{
		glColor3ub(0,0,255);	// Цвет линии 
		glLineWidth(3.0) ;	    // Толщина линии
		glBegin(GL_LINE_STRIP); // Ось X
		  glVertex2f(left,0); 
		  glVertex2f(right,0);     
		glEnd(); 
	}

    glColor3ub(255,0,0);	// Цвет линии 
	glLineWidth(2.0) ;	    // Толщина линии
	glBegin(GL_LINE_STRIP); // Линия графика
      for(int i=0;i<NamberPoints;i++) glVertex2fv(MasFunc[i]); 
    glEnd(); 	
}

//-------- Функция------------------------------------------------
void CreateMasFunc(pFunc FuncName,float x_begin,float dx,int N,float **Mas)
//Функция создает массив значений функции y=f(x)
//pFunc - указатель на функцию f(x)
//x_begin - начальное значение аргуиента
//dx - шаг изменения аргумента
//N - число точек для аргумента
//Mas - массив размером Nx2 для записи значений функции

{
	for(int i=0;i<N;i++)
	{
		float x=x_begin+i*dx;
		float y=FuncName(x);
		Mas[i][0]=x;
		Mas[i][1]=y;
	}		
}

//--------- MayF1 ------------------------------------------------------
float MyF1(float x)
{
	float y;
	if (fabs(x)<0.0001) y=1;
	else y=(sin(x)/x);
	return y;
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
	glutCreateWindow("Пример_2.    Рисование примитивов"); //Создание окна с заголовком
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
//Удаление динамического массива 
	for(int i=0;i<NamberPoints;i++) delete MasFunc[i]; 
	delete MasFunc;
	return 0;
} 
 
 