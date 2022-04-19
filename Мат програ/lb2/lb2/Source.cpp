#include <iostream>
#include "Header.h"
#include <tchar.h>
#include "Header1.h"
#include <iomanip> 
#include "Comb.h"
#include "Perest.h"
#include "z5.h"
#include "Razm.h"
#include <locale>
#include <ctime>
#include "Rand2.h"
#include <Windows.h>

#define N (sizeof(AA)/2)
#define M 3
#define NN 4

#define MM 3
#define JJ 6
        


int _tmain(int argc, _TCHAR* argv[])
{
    
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    setlocale(LC_ALL, "");

    ///////// Генератор подмножеств 

    char  AA[][2] = { "A", "B", "C", "D" };
    std::cout << std::endl << " - Генератор множества всех подмножеств -";
    std::cout << std::endl << "Исходное множество: ";
    std::cout << "{ ";
    for (int i = 0; i < sizeof(AA) / 2; i++)                                     //sizeof - это унарный оператор, возвращающий длину типа, помещенных в скобки.
        std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "Генерация всех подмножеств  ";
    combi1::subset s1(sizeof(AA) / 2);     // создание генератора   
    int  n = s1.getfirst();                // первое (пустое) подмножество    
    while (n >= 0)                         // пока есть подмножества 
    {
        std::cout << std::endl << "{ ";
        for (int i = 0; i < n; i++)
            std::cout << AA[s1.ntx(i)] << ((i < n - 1) ? ", " : " ");
        std::cout << "}";
        n = s1.getnext();                  // cледующее подмножество 
    };
    std::cout << std::endl << "всего: " << s1.count() << std::endl;
    system("pause");
    
    ////////////////////////////////////
    ///////////// Генератор сочетаний

    char  BB[][2] = { "A", "B", "C", "D", "E" };
    std::cout << std::endl << " --- Генератор сочетаний ---";
    std::cout << std::endl << "Исходное множество: ";
    std::cout << "{ ";
    for (int i = 0; i < sizeof(BB) / 2; i++)
        std::cout << BB[i] << ((i < sizeof(BB) / 2 - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "Генерация сочетаний ";
    combi2::xcombination xc(sizeof(BB) / 2, 3);
    std::cout << "из " << xc.n << " по " << xc.m;
    n = xc.getfirst();
    while (n >= 0)
    {
        std::cout << std::endl << xc.nc << ": { ";
        for (int i = 0; i < n; i++)
            std::cout << BB[xc.ntx(i)] << ((i < n - 1) ? ", " : " ");
        std::cout << "}";
        n = xc.getnext();
    };
    std::cout << std::endl << "всего: " << xc.count() << std::endl;
    system("pause");
    //////////////////////////////////// генератор перестановок


    std::cout << std::endl << " --- Генератор перестановок ---";
    std::cout << std::endl << "Исходное множество: ";
    std::cout << "{ ";
    for (int i = 0; i < sizeof(AA) / 2; i++)
        std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "Генерация перестановок ";
    combi3::permutation p(sizeof(AA) / 2);
    __int64  q = p.getfirst();
    while (q >= 0)
    {
        std::cout << std::endl << std::setw(4) << p.np << ": { ";
        for (int i = 0; i < p.n; i++)
            std::cout << AA[p.ntx(i)] << ((i < p.n - 1) ? ", " : " ");
        std::cout << "}";
        q= p.getnext();
    };
    std::cout << std::endl << "всего: " << p.count() << std::endl;
    system("pause");

    ////////////////////////////////////////////////////////////// генератор размещений

    std::cout << std::endl << " --- Генератор размещений ---";
    std::cout << std::endl << "Исходное множество: ";
    std::cout << "{ ";
    for (int i = 0; i < N; i++)
        std::cout << AA[i] << ((i < N - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "Генерация размещений  из  " << N << " по " << M;
    combi4::accomodation s(N, M);
    int  w = s.getfirst();
    while (w >= 0) {
        std::cout << std::endl << std::setw(2) << s.na << ": { ";
        for (int i = 0; i < 3; i++)
            std::cout << AA[s.ntx(i)] << ((i < n - 1) ? ", " : " ");
        std::cout << "}";
        w = s.getnext();
    };
    std::cout << std::endl << "всего: " << s.count() << std::endl;
    system("pause");

    ////////////////////////////////////



 
    
    
 
        int V = 1500,          //общий вес
            v[JJ],
            c[JJ];
        short  r[MM];
        clock_t  t1 = 0, t2 = 0;

        for (int q = 15; q < 25; q++)
        {


            auxil::start();                          // старт генерации 
            t1 = clock();                            // фиксация времени 
            for (int i = 0; i < JJ; i++)
            {
                v[i] = auxil::iget(100, 900);
                c[i] = auxil::iget(10, 150);



                int cc = boat(
                    V,   // [in]  максимальный вес груза
                    q,  // [in]  количество мест для контейнеров     
                    JJ,  // [in]  всего контейнеров  
                    v,   // [in]  вес каждого контейнера  
                    c,   // [in]  доход от перевозки каждого контейнера     
                    r    // [out] результат: индексы выбранных контейнеров  
                );

                std::cout << std::endl << "- Задача о размещении контейнеров на судне";
                std::cout << std::endl << "- общее количество контейнеров    : " << JJ;
                std::cout << std::endl << "- количество мест для контейнеров : " << q;
                std::cout << std::endl << "- ограничение по суммарному весу  : " << V;
                std::cout << std::endl << "- вес контейнеров                 : ";
                
                for (int i = 0; i < JJ; i++)
                    std::cout << std::setw(3) << v[i] << " ";
                std::cout << std::endl << "- доход от перевозки              : ";
                
                for (int i = 0; i < JJ; i++)
                    std::cout << std::setw(3) << c[i] << " ";
                std::cout << std::endl << "- выбраны контейнеры (0,1,...,m-1): ";
               
                for (int i = 0; i < JJ; i++)
                    std::cout << r[i] << " ";
                std::cout << std::endl << "- доход от перевозки              : " << cc;
                std::cout << std::endl << "- общий вес выбранных контейнеров : ";
                int qwe = 0;
                for (int i = 0; i < JJ; i++)
                qwe += v[r[i]];
                std::cout << qwe;
                std::cout << std::endl << std::endl;
                t2 = clock();
                std::cout << "Времени потребовавшего на выполнение задачи :" << (double)(t2 - t1) / (double)CLOCKS_PER_SEC << std::endl;
                system("pause");
            }
            return 0;

        }
}