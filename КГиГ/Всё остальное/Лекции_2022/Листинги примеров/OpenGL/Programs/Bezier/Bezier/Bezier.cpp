#include "Bezier.h"

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
GLint left,right,top,bottom,znear,zfar;                              
GLint Index=0;  // Для выбора рисунка
float angleX=0;    // Угол для поворота треугольника, град
float angleY=0;    // Угол для поворота треугольника, град
GLint NumPoints=4;
GLfloat Points2D_1[4][3]={{3.0,1.0,0.0},   //(x1,y1,z1=0)
	                    {6.0,9.0,0.0},   //(x2,y2,z2=0)
						{12.0,-3.0,0.0}, //(x3,y3,z3=0)
						{19.0,3.0,0.0}};  //(x4,y4,z4=0)

GLfloat Points2D_2[4][3]={{-5.0,1.0,0.0},   //(x1,y1,z1=0)
	                    {-2.0,9.0,0.0},   //(x2,y2,z2=0)
						{2.0,9.0,0.0}, //(x3,y3,z3=0)
						{5.0,1.0,0.0}};  //(x4,y4,z4=0)
int NumCoords=3; //Число координат (x,y,z)
int NumPoints3D=4; // Число точек в слое (листе) z=const
int NumSheets=3; // Число слоев (листов) z=const
float ***ppPoints; 


GLfloat Points3D[3][4][3]=	{
							  {
							    {-5.0,1.0,-4.0},  
								{-2.0,9.0,-4.0},  
								{2.0,9.0,-4.0},
								{5.0,1.0,-4.0}
							  }, 

								{
								  {-5.0,1.0,0.0},  
								  {-2.0,9.0,0.0},  
								  {2.0,9.0,0.0},
								  {5.0,1.0,0.0}
							    }, 

								{
								  {-5.0,1.0,4.0},  
								  {-2.0,9.0,4.0},  
								  {2.0,9.0,4.0},
								  {5.0,1.0,4.0}
							    } 

							};				


//------ Эта функция управляет всем выводом на экран----------- 
void OnDraw(void) 
{   
	switch(Index)
	{
		case 0:
		{
			glClearColor(1.0,1.0,1.0,0.0);
			glClear(GL_COLOR_BUFFER_BIT|GL_DEPTH_BUFFER_BIT); 
			glEnable(GL_DEPTH_TEST);	
			break;
		}

		case 1:
		{
			//Цвет фона в окне 
			glClearColor(1.0,1.0,1.0,0.0); // - белый
            // Очистить буфер цвета - залить цветом фона	
			glClear(GL_COLOR_BUFFER_BIT|GL_DEPTH_BUFFER_BIT);  	
			glColor3ub(0,0,255);	// Цвет линии 
			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=0; right=22; bottom=-5; top=11;
			gluOrtho2D(left, right, bottom, top); 
			DrawPoints(Points2D_1,NumPoints); // Рисуем точки,соединенные линиями
			glColor3ub(255,0,0);	// Цвет линии 
			glLineWidth(3.0) ;	    // Толщина линии
			Bezier2D_1(Points2D_1,NumPoints); // Кривая Безье
			break;
		}

		case 2:
		{
			//Цвет фона в окне 
			glClearColor(1.0,1.0,1.0,0.0); // - белый
            // Очистить буфер цвета - залить цветом фона	
			glClear(GL_COLOR_BUFFER_BIT|GL_DEPTH_BUFFER_BIT);  	
			glColor3ub(0,0,255);	// Цвет линии 
			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity(); 		
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-7; right=7; bottom=-2; top=11;
			gluOrtho2D(left, right, bottom, top); 
			DrawPoints(Points2D_2,NumPoints); // Рисуем точки,соединенные линиями
			glColor3ub(255,0,0);	// Цвет линии 
			glLineWidth(3.0) ;	    // Толщина линии
			Bezier2D_2(Points2D_2,NumPoints); // Кривая Безье
			break;        
		}	
		case 3:
		{
			//Цвет фона в окне 
			glClearColor(1.0,1.0,1.0,0.0); // - белый
            // Очистить буфер цвета - залить цветом фона	
			glClear(GL_COLOR_BUFFER_BIT|GL_DEPTH_BUFFER_BIT);  	
			glColor3ub(0,0,255);	// Цвет линии 
			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity();
			angleX=10;
			angleY=10;
			glRotatef(angleX,1.0,0.0,0.0);
			glRotatef(angleY,0.0,1.0,0.0);
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-7; right=7; bottom=-2; top=11; znear=-10; zfar=10;
			glOrtho(left, right, bottom, top,znear,zfar); 
			CopyPoints();
			DrawPoints3D(ppPoints,NumPoints,NumSheets,1); //Слои точек
			break;        
		}
		case 4:
		{
			//Цвет фона в окне 
			glClearColor(1.0,1.0,1.0,0.0); // - белый
            // Очистить буфер цвета - залить цветом фона	
			glClear(GL_COLOR_BUFFER_BIT|GL_DEPTH_BUFFER_BIT);  	
			glColor3ub(0,0,255);	// Цвет линии 
			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity();
			angleX=30;
			angleY=40;
			glRotatef(angleX,1.0,0.0,0.0);
			glRotatef(angleY,0.0,1.0,0.0);
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-7; right=7; bottom=-3; top=11; znear=-10; zfar=10;
			glOrtho(left, right, bottom, top,znear,zfar); 
			glLineWidth(2.0) ;	    // Толщина линии

			// Настройка поверхности Безье
    
			glMap2f(GL_MAP2_VERTEX_3,	// Тип генерируемых данных
			0.0f,						// Нижняя граница u
			10.0f,						// Верхняя граница u
			3,							// Расстояние между точками в данных
			4,							// Размерность в направлении u (порядок)
			0.0f,						// Нижняя граница v 
			10.0f,						// Верхняя граница v
			12,							// Расстояние между точками в данных
			3,							// Размерность в направлении v (порядок)
			&Points3D[0][0][0]);		// Массив контрольных точек   **ppPoints);

    
			glEnable(GL_MAP2_VERTEX_3);  //Активизация функции оценки
       
			glMapGrid2f(10,0.0f,10.0f,10,0.0f,10.0f); //Отображается сетка - 10 точек от 0 до 10
		
			glEvalMesh2(GL_LINE,0,10,0,10);//С помощью линий оценивается сетка

			glColor3ub(255,0,0);	// Цвет  
			CopyPoints();
			DrawPoints3D(ppPoints,NumPoints,NumSheets,1);
			break;        
		}
		case 5:
		{
			//Цвет фона в окне 
			glClearColor(1.0,1.0,1.0,0.0); // - белый
            // Очистить буфер цвета - залить цветом фона	
			glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); 
			glColor3ub(165,42,42);	// Цвет линии 
			InitLight(); //Настройка цвета
			glMatrixMode(GL_MODELVIEW); // Видовая матрица
			glLoadIdentity();
			angleX=30;
			angleY=30;
			glRotatef(angleX,1.0,0.0,0.0);
			glRotatef(angleY,0.0,1.0,0.0);
			glMatrixMode(GL_PROJECTION); // Ортографическая проекция 
			glLoadIdentity(); 
			left=-7; right=7; bottom=-3; top=11; znear=-10; zfar=10;
			glOrtho(left, right, bottom, top,znear,zfar); 
			glLineWidth(2.0) ;	    // Толщина линии

			// Настройка поверхности Безье
    
			glMap2f(GL_MAP2_VERTEX_3,	// Тип генерируемых данных
			0.0f,						// Нижняя граница u
			10.0f,						// Верхняя граница u
			3,							// Расстояние между точками в данных
			4,							// Размерность в направлении u (порядок)
			0.0f,						// Нижняя граница v 
			10.0f,						// Верхняя граница v
			12,							// Расстояние между точками в данных
			3,							// Размерность в направлении v (порядок)
			&Points3D[0][0][0]);		// Массив контрольных точек   
  
			glEnable(GL_MAP2_VERTEX_3);  //Активизация функции оценки
       
			glMapGrid2f(10,0.0f,10.0f,10,0.0f,10.0f); //Отображается сетка - 10 точек от 0 до 10
		
			glEvalMesh2(GL_FILL,0,10,0,10);//С помощью линий оценивается сетка
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


//===========================  Bezier2D =================================

void DrawPoints(GLfloat Points[][3],GLint NumPoints)
// Points - матрица размером NumPoints x 3
// NumPoints - число точек,каждая из которых имее 3 координаты (x,y,z)
{
	glPointSize(5.0);
	glBegin(GL_POINTS);
		for(int i = 0; i < NumPoints; i++) glVertex2fv(Points[i]);
	glEnd();

	glLineWidth(1.0) ;	    // Толщина линии
	glBegin(GL_LINE_STRIP);
		for(int i = 0; i < NumPoints; i++) glVertex2fv(Points[i]);
	glEnd();

    }



//--------- Bezier2D_1 --------------------------------------------
void  Bezier2D_1(GLfloat Points[][3],GLint NumPoints)
{        
    glMap1f(GL_MAP1_VERTEX_3,	// Тип генерируемых данных
    0.0f,						// Нижняя граница параметра u
    100.0f,						// Верхняя граница параметра u
    3,							// Расстояние между точками в данных
    NumPoints,					// Число контрольных точек
    &Points[0][0]);		    	// Массив контрольных точек

    glEnable(GL_MAP1_VERTEX_3); // Активизация функции оценки
	glBegin(GL_LINE_STRIP);     // Точки соединяются ломаной
		for(int i = 0; i <= 100; i++)
			{
				glEvalCoord1f((GLfloat) i); // Оценивается кривая в этой точке
            }
    glEnd();
}
//--------- Bezier2D_2 --------------------------------------------
void  Bezier2D_2(GLfloat Points[][3],GLint NumPoints)
{        
    glMap1f(GL_MAP1_VERTEX_3,	// Тип генерируемых данных
    0.0f,						// Нижняя граница u
    100.0f,						// Верхняя граница u
    3,							// Расстояние между точками в данных
    NumPoints,					// Число контрольных точек
    &Points[0][0]);			    // Массив контрольных точек

	glEnable(GL_MAP1_VERTEX_3); // Активизация функции оценки

    glMapGrid1d(100,0.0,100.0); // Отображается сетка: 100 точек - от 0 до 100
	glEvalMesh1(GL_LINE,1,100); // С помощью линий вычисляется сетка
}

//===========================  Bezier3D =====================================

void DrawPoints3D(float ***Points,int NumPoints,int NumSheets,int k)
//NumPoints - число точек в слое (листе) z=const
//NumSheets - число слоев (листов) z=const
//Здесь каждая очка имеет три координаты (x,y,z) - NumCoords=3
//При k=0 отображаются только точки, а при k=1 - точки и линии
    {
	
    glPointSize(5.0f);
	for(int i = 0; i < NumSheets; i++)//По числу слоев 
		{
			glBegin(GL_POINTS);
				for(int j = 0; j < NumPoints; j++) //По числу точек в слое
					glVertex3fv(Points[i][j]);	
			glEnd();
		}


//Можно и так
/*
    glBegin(GL_POINTS);
    for(int i = 0; i < NumSheets; i++) //По числу слоев 
			for(int j = 0; j < NumPoints; j++) //По числу точек в слое
				glVertex3fv(Points[i][j]);
	glEnd();
*/

	if(k!=0)
	{
//Точки в слое соединяем линиями 	
		glLineWidth(1.0) ;	    // Толщина линии
		for(int i = 0; i < NumSheets; i++)//По числу слоев 
		{
			glBegin(GL_LINE_STRIP);
				for(int j = 0; j < NumPoints; j++) //По числу точек в слое
					glVertex3fv(Points[i][j]);	
			glEnd();
		}
	}
    
    }
//============================ Init ===================================
void InitLight()
	{
	GLfloat  ambientLight[] = { 0.3f, 0.3f, 0.3f, 1.0f };
	GLfloat  diffuseLight[] = { 0.7f, 0.7f, 0.7f, 1.0f };
	GLfloat	 lightPos[] = { 20.0f, 0.0f, 0.0f, 0.0f };
	glEnable(GL_LIGHTING);

	// Устанавливаем свойства  источник света 0
	glLightfv(GL_LIGHT0,GL_AMBIENT,ambientLight);
	glLightfv(GL_LIGHT0,GL_DIFFUSE,diffuseLight);

	// Включаем источник света 0
	glLightfv(GL_LIGHT0,GL_POSITION,lightPos);
	glEnable(GL_LIGHT0);

	glEnable(GL_COLOR_MATERIAL);
	
	// Установка свойств материала
	glColorMaterial(GL_FRONT, GL_AMBIENT_AND_DIFFUSE);

	// Автомаимческая генерация нормалей 
	glEnable(GL_AUTO_NORMAL);
	}


//----------------- CopyPoints()----------------------------------------------
void CopyPoints()
{
	for(int i=0;i<NumSheets;i++)
		for(int j=0;j<NumPoints3D; j++)
			for(int k=0;k<NumCoords; k++) ppPoints[i][j][k]=Points3D[i][j][k];
}


//================ main ==================================================
int main(int argc, char *argv[]) 
{ 
//----- Функции библиотеки GLUT ------------------------------------------
 glutInit(&argc, argv); // Инициализация библиотеки GLUT
 glutInitDisplayMode(GLUT_RGB|GLUT_SINGLE); //Используется режим RGB для 
	                                          //выбора цвета и одинарный видеобуфер
	glutInitWindowPosition  (x_win,y_win);    // Координаты левого верхнего угла 
	                                          //окна OpenGL на экране монитора
  glutInitWindowSize(Width, Height);          //Ширина и высота окна OpenGL 
	glutCreateWindow("Кривая Безье 2D"); //Создание окна с заголовком
  glutDisplayFunc(OnDraw); // Регистрация функции обратного вызова OnDraw - вызывается
	                         // системой при необходимости перерисовать окно (аналог OnPaint в MFC) 
  glutReshapeFunc(OnSize);   // Регистрация функции обратного вызова OnSize - вызывается
	                         // системой при изменении размеров окна (аналог OnSize в MFC) 
  //-------Создаем меню -------------------------
	glutCreateMenu(Figure);
		glutAddMenuEntry("Bezier2D_1",1);
		glutAddMenuEntry("Bezier2D_2",2);
		glutAddMenuEntry("Points3D",3);
		glutAddMenuEntry("Bezier3D",4);
		glutAddMenuEntry("Bezier3D_Light",5);
		glutAddMenuEntry("Очистить",0);
		glutAttachMenu(GLUT_RIGHT_BUTTON);
//-------------------------------------------------
// Динамически создаем трехмерный массив (размерности NumSheets_X_NumPoints3D_X_NumCoords)

ppPoints=new float **[NumSheets]; //dim1
for(int i=0;i<NumSheets;i++)
{
	ppPoints[i]=new float *[NumPoints3D]; //dim2
	for(int j=0;j<NumPoints3D;j++) ppPoints[i][j]=new float[NumCoords];//dim3
}
//Init();
  glutMainLoop(); //Запуск бесконечного цикла обработки сообщений Windows

//Удаляем трехмерный динамический масив
for(int i=0;i<NumSheets;i++)
{
	for (int j = 0; j < NumPoints3D; j++) delete[]ppPoints[i][j];
}
for (int i = 0; i < NumSheets; i++) delete[]ppPoints[i];
delete[] ppPoints;

return 0;
} 


//Создание и уничтожение трёхмерного массива 
/*
int ***ppArr;
ppArr = new int**[dim1];
for (i = 0; i < dim1; i++) ppArr[i] = new int*[dim2];
for (i = 0; i < dim1; i++)
{
 for (j = 0; j < dim2; j++) ppArr[i][j] = new int[dim3];
}
ppArr[1][2][3] = 750; cout << ppArr[1][2][3] << endl; fdArr(ppArr,1,2,3);

for (i = 0; i < dim1; i++)
{
 for (j = 0; j < dim2; j++) delete[]ppArr[i][j];
}
for (i = 0; i < dim1; i++) delete[]ppArr[i];
delete[] ppArr;
}
*/
 