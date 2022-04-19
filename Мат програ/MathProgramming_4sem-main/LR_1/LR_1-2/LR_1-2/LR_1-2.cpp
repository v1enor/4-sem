#include <iostream>
#include <ctime>
#include "Knapsack.h"
#include "Auxil.h"
#include <tchar.h>

#define N 100

clock_t SS[N];
int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "rus");

    int V = 1000,   // вместимость рюкзака
        v[N],       // размер предмета каждого типа
        c[N];       // стоимость предмета каждого типа 
    short m[N];     // количество предметов каждого типа {0,1}
    int maxcc = 0;
    int n = 0;

    auxil::start();
    for (int i = 0; i < N; i++) v[i] = auxil::iget(10, 100);
    for (int i = 0; i < N; i++) c[i] = auxil::iget(5, 50);


    for (int n = 10; n < 21; n++)
    {
        SS[n] = clock();
        maxcc = knapsack_s(V, n, v, c, m); // измеряемая функция
        SS[n] = -(SS[n] - clock());
        std::cout << std::endl << "n = " << n << " " << SS[n];
    }
    return 0;
}