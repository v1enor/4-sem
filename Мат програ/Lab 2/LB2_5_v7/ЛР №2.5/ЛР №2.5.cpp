//моё: веса контейнеров рандом(100-900) \ ограничение по весу 1500 \ количество мест 5 \ количество контейнеров 25 \ // стоимость 10- 150

// Main 
#include <iostream>
#include "Combi2.h"
#include <tchar.h>
#include "Boat.h"
#include <iomanip>

#define NN 25 // кколичество контейнеров
#define MM 5 // мест 
int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "rus");
    int V = 1500;
    int v[NN];
    int c[NN];

    for (int i = 0; i < NN; i++)
    {
        v[i] = 100 + (rand() % (900 - 100) + 1); // запись случайного числа, которое вернет rand()
        c[i] = 10 + (rand() % (150 - 10) + 1);
    }
    short  r[MM];
    int cc = boat(
        V,   // [in]  максимальный вес груза
        MM,  // [in]  количество мест для контейнеров     
        NN,  // [in]  всего контейнеров  
        v,   // [in]  вес каждого контейнера  
        c,   // [in]  доход от перевозки каждого контейнера     
        r    // [out] результат: индексы выбранных контейнеров  
    );
    std::cout << std::endl << "- Задача о размещении контейнеров на судне";
    std::cout << std::endl << "- общее количество контейнеров    : " << NN;
    std::cout << std::endl << "- количество мест для контейнеров : " << MM;
    std::cout << std::endl << "- ограничение по суммарному весу  : " << V;
    std::cout << std::endl << "- вес контейнеров                 : ";
    for (int i = 0; i < NN; i++) std::cout << std::setw(3) << v[i] << " ";
    std::cout << std::endl << "- доход от перевозки              : ";
    for (int i = 0; i < NN; i++) std::cout << std::setw(3) << c[i] << " ";
    std::cout << std::endl << "- выбраны контейнеры (0,1,...,m-1): ";
    for (int i = 0; i < MM; i++) std::cout << r[i] << " ";
    std::cout << std::endl << "- доход от перевозки              : " << cc;
    std::cout << std::endl << "- общий вес выбранных контейнеров : ";
    int s = 0; for (int i = 0; i < MM; i++) s += v[r[i]]; std::cout << s;
    std::cout << std::endl << std::endl;
    system("pause");
    return 0;
}

