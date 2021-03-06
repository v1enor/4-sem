// Lab2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <ctime> 
#include <locale>
#include <iomanip> 
#include "Combi.h"
#include "Boat.h"
#include "Auxil.h"
#define N (sizeof(AA)/2)
#define M 3
#define NN 8
#define MM 5

int main()
{
	setlocale(LC_ALL, "rus");
	//-------------------------------------------------------------------------------
	clock_t t1 = 0, t2 = 0;
	int *v = new int[NN]; // вес
	int *c = new int[NN]; // доход 
	int *minv = new int[MM];   // минимальный  вес 
	int *maxv = new int[NN];    // максимальный вес
	short r[MM];
	for (int i = 0; i < NN; i++)
	{
		v[i] = 100 + rand() % 200;
		c[i] = 10 + rand() % 100;
	}
	for (int j = 0; j < MM; j++)
	{
		//c
		minv[j] = 50 + rand() % 120;
		maxv[j] = 150 + rand() % 850;
	}
	auxil::start(); // старт генерации 
	t1 = clock();
	int cc = boat_с(
		MM,    // [in]  количество мест для контейнеров
		minv,  // [in]  максимальный вес контейнера на каждом  месте 
		maxv,  // [in]  минимальный вес контейнера на каждом  месте  
		NN,    // [in]  всего контейнеров  
		v,     // [in]  вес каждого контейнера  
		c,     // [in]  доход от перевозки каждого контейнера   
		r      // [out] номера  выбранных контейнеров  
	);
	t2 = clock();
	std::cout << std::endl << "- Задача о размещении контейнеров на судне -";
	std::cout << std::endl << "- общее количество контейнеров   : " << NN;
	std::cout << std::endl << "- количество мест для контейнеров  : " << MM;
	std::cout << std::endl << "- минимальный  вес контейнера  : ";
	for (int i = 0; i < MM; i++) std::cout << std::setw(3) << minv[i] << " ";
	std::cout << std::endl << "- максимальный вес контейнера  : ";
	for (int i = 0; i < MM; i++) std::cout << std::setw(3) << maxv[i] << " ";
	std::cout << std::endl << "- вес контейнеров      : ";
	for (int i = 0; i < NN; i++) std::cout << std::setw(3) << v[i] << " ";
	std::cout << std::endl << "- доход от перевозки     : ";
	for (int i = 0; i < NN; i++) std::cout << std::setw(3) << c[i] << " ";
	std::cout << std::endl << "- выбраны контейнеры (0,1,...,m-1) : ";
	for (int i = 0; i < MM; i++) std::cout << r[i] << " ";
	std::cout << std::endl << "- доход от перевозки     : " << cc << std::endl;
	std::cout << "время выполнения - " << ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC) << "сек" << std::endl;
	system("pause");
	return 0;
}