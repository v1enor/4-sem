#pragma once
#include <fstream>
using namespace std;

class CMatrix
{
public:
	// Поля.
	double **array;
	int n_rows = 1;							// Число строк
	int n_cols = 1;							// Число столбцов
public:
	// Конструкторы/Деструкторы.
	CMatrix();							// Конструктор по умолчанию (1 на 1)
	CMatrix(int, int);		    		// Конструктор
	CMatrix(int);						// Конструктор вектора (один столбец)
	CMatrix(const CMatrix&);			// Конструктор копирования
	~CMatrix();

	// Перегрузка операторов.

	// Выбор элемента матрицы по индексу.
	double& operator()(int, int);
	// Выбор элемента вектора по индексу.
	double& operator()(int);
	// Оператор "Присвоить":    M1=M2.
	CMatrix operator=(const CMatrix&);
	// Оператор "Произведение": М1*М2.
	CMatrix operator*(CMatrix&);
	// Оператор "+": M1+M2.
	CMatrix operator+(CMatrix&);
	// Оператор "-": M1-M2.
	CMatrix operator-(CMatrix&);

	// Методы
	void getInArray();
	// Возвращает число строк.
	int rows()const { return n_rows; };
	// Возвращает число столбцов.
	int cols()const { return n_cols; };
	// Возвращает матрицу, транспонированную к текущей.
	CMatrix Transp();
	// Возвращает строку по номеру.
	CMatrix GetRow(int);
	CMatrix GetRow(int, int, int);
	// Возвращает столбец по номеру.
	CMatrix GetCol(int);
	CMatrix GetCol(int, int, int);
	// Изменяет размер матрицы с уничтожением данных.
	CMatrix RedimMatrix(int, int);
	// Изменяет размер матрицы с сохранением данных, которые можно сохранить.
	CMatrix RedimData(int, int);
	// Изменяет размер матрицы с уничтожением данных.
	CMatrix RedimMatrix(int);
	// Изменяет размер матрицы с сохранением данных, которые можно сохранить.
	CMatrix RedimData(int);
	// Максимальный элемент матрицы
	double MaxElement();
	// Минимальный элемент матрицы
	double MinElement();
};