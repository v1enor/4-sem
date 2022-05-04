// main (решение задачи  о размещении контейнеров)  
#include <iostream>
#include <iomanip> 
#include "BoatC.h"
#include <tchar.h>
#include "Variant 12.h"
#define NN 8
#define MM 5
#define SPACE(n) setw(n)<<" "

using std::cout;
using std::endl;
using std::setw;



void fillArrayWithRandomValues(int* weights, int sizeOfArray, int min, int max) {

	std::srand(static_cast<unsigned int>(std::time(nullptr)));
	for (int i = 0; i < sizeOfArray; i++)
	{
		weights[i] = min + (rand() % (max - min + 1));
	}

}

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");
	int v[NN];// вес
	int c[NN]; // доход
	int minv[MM];
	int maxv[MM];
	fillArrayWithRandomValues(v, NN, 100, 200);
	fillArrayWithRandomValues(c, NN, 10, 100);
	fillArrayWithRandomValues(minv, MM, 50, 120);
	fillArrayWithRandomValues(maxv, MM, 150, 850);


	short r[MM];
	int cc = boat_с(
		MM,    // [in]  количество мест для контейнеров
		minv,  // [in]  максимальный вес контейнера на каждом  месте 
		maxv,  // [in]  минимальный вес контейнера на каждом  месте  
		NN,    // [in]  всего контейнеров  
		v,     // [in]  вес каждого контейнера  
		c,     // [in]  доход от перевозки каждого контейнера   
		r      // [out] номера  выбранных контейнеров  
	);



	cout << endl << "-- Задача о размещении контейнеров -- ";
	cout << endl << "-- всего контейнеров: " << NN;
	cout << endl << "-- количество ------ продолжительность -- ";
	cout << endl << "  мест     вычисления  ";
	clock_t t1, t2;
	for (int i = 4; i <= NN; i++) {
		t1 = clock();
		boat_с(i, minv, maxv, NN, v, c, r);
		t2 = clock();
		cout << endl << SPACE(7) << setw(2) << i
			<< SPACE(15) << setw(6) << (t2 - t1);
	}
	cout << endl; system("pause");
	return 0;
}


//cout << endl << "- Задача о размещении контейнеров на судне -";
//cout << endl << "- общее количество контейнеров   : " << NN;
//cout << endl << "- количество мест для контейнеров  : " << MM;
//cout << endl << "- минимальный  вес контейнера  : ";
//for (int i = 0; i < MM; i++) cout << setw(3) << minv[i] << " ";
//cout << endl << "- максимальный вес контейнера  : ";
//for (int i = 0; i < MM; i++) cout << setw(3) << maxv[i] << " ";
//cout << endl << "- вес контейнеров      : ";
//for (int i = 0; i < NN; i++) cout << setw(3) << v[i] << " ";
//cout << endl << "- доход от перевозки     : ";
//for (int i = 0; i < NN; i++) cout << setw(3) << c[i] << " ";
//cout << endl << "- выбраны контейнеры (0,1,...,m-1) : ";
//for (int i = 0; i < MM; i++) cout << r[i] << " ";
//cout << endl << "- доход от перевозки     : " << cc;
//cout << endl << endl;
//system("pause");
//return 0;



//cout << endl << "-- Задача о размещении контейнеров -- ";
//cout << endl << "-- всего контейнеров: " << NN;
//cout << endl << "-- количество ------ продолжительность -- ";
//cout << endl << "  мест     вычисления  ";
//clock_t t1, t2;
//for (int i = 4; i <= NN; i++) {
//	t1 = clock();
//	boat_с(i, minv, maxv, NN, v, c, r);
//	t2 = clock();
//	cout << endl << SPACE(7) << setw(2) << i
//		<< SPACE(15) << setw(6) << (t2 - t1);
//}
//cout << endl; system("pause");
//return 0;


