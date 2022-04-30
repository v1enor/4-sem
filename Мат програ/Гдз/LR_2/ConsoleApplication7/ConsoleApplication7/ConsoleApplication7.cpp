#include <tchar.h>
#include <iostream>
#include <iomanip> 
#include <ctime>
#include <algorithm>
#include <cstdlib>
#include "Salesman.h"
#define N 5

int Random(int min, int max) {
    return min + rand() % (max - min);
}

int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "rus");
    int array[N][N];

    for (int i = 0; i < N; ++i)
    {
        for (int j = 0; j < N; ++j)
        {
            if (i == j) {
                array[i][j] = 0;
            }
            else if ((i == 2 && j == 5) || (i == 3 && j == 7) || (i == 7 && j == 3)) {
                array[i][j] = INF;
            }
            else {
                array[i][j] = Random(10, 300);
            }
            /*srand(time(0));*/
        }
    }


    int r[N];                     // результат 
    int s = salesman(
        N,          // [in]  количество городов 
        (int*)array,          // [in]  массив [n*n] расстояний 
        r           // [out] массив [n] маршрут 0 x x x x  

    );
    std::cout << std::endl << "-- Задача коммивояжера -- ";
    std::cout << std::endl << "-- количество  городов: " << N;
    std::cout << std::endl << "-- матрица расстояний : ";
    for (int i = 0; i < N; i++)
    {
        std::cout << std::endl;
        for (int j = 0; j < N; j++)

            if (array[i][j] != INF) std::cout << std::setw(3) << array[i][j] << " ";

            else std::cout << std::setw(3) << "INF" << " ";
    }
    std::cout << std::endl << "-- оптимальный маршрут: ";
    for (int i = 0; i < N; i++) std::cout << r[i] << "-->"; std::cout << 0;
    std::cout << std::endl << "-- длина маршрута     : " << s;
    std::cout << std::endl;
    system("pause");
    return 0;
}