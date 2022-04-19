#include "pch.h" 
#include "Auxil.h" 
#include <ctime>
// ctime - библиотека с определениями функций для получения инфы о дате\времени
namespace auxil
{
	void start() // старт генератора сл. чисел 
	{
		srand((unsigned)time(NULL));
		// time - количество секунд с 1 января 1970 года
		// srand - инициализацию генератора случайных чисел rand, в него передается уникальное значение, чтобы каждый раз генерировалась новая последовательность
	};
	double dget(double rmin, double rmax) // получить случайное число двойной точности
	{
		return ((double)rand() / (double)RAND_MAX)*(rmax - rmin) + rmin;
	};
	int iget(int rmin, int rmax) // получить случайное целое число 
	{
		return (int)dget((double)rmin, (double)rmax);
	};
}