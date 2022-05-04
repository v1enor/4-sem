#pragma once
namespace combi
{
	struct subset // Для генерации множества всех подмножеств
	{
		short n, sn, *sset; // мощность исходного, текущего, индексы текущего
		unsigned __int64 mask; // битовая маска
		subset(short n = 1);	// конструктор
		short getfirst();
		short getnext();
		short ntx(short i);	// получить итый элемент массива индексов
		unsigned __int64 count();	//общее количество подмножеств
		void reset();
	};
	struct xcombination
	{
		short n, m, *sset;
		xcombination(short n = 1, short m = 1);
		void reset();
		short getfirst();
		short getnext();
		short ntx(short i);	//i-ый элемент массива индексов
		unsigned __int64 nc;
		unsigned __int64 count() const;
	};
	struct  permutation    // генератор   перестановок     
	{
		const static bool L = true;  // левая стрелка 
		const static bool R = false; // правая стрелка   
		short  n,              // количество элементов исходного множества 
			*sset;           // массив индексов текущей перестановки
		bool  *dart;           // массив  стрелок (левых-L и правых-R) 
		permutation(short n = 1); // конструктор (количество элементов исходного множества) 
		void reset();                // сбросить генератор, начать сначала 
		__int64 getfirst();          // сформировать первый массив индексов    
		__int64 getnext();           // сформировать случайный массив индексов  
		short ntx(short i);          // получить i-й элемент масива индексов 
		unsigned __int64 np;         // номер перествновки 0,... count()-1 
		unsigned __int64 count() const;  // вычислить общее кол. перестановок    
	};
	struct  accomodation  // генератор размещений 
	{
		short  n,      // количество элементов исходного множества  
			   m,      // количество элементов в размещении 
			*sset;      // массив индесов текущего размещения  
		xcombination  *cgen;   // указатель на генератор сочетаний
		permutation *pgen;   // указатель на генератор перестановок
		accomodation(short n = 1, short m = 1);  // конструктор  
		void reset();     // сбросить генератор, начать сначала 
		short getfirst();     // сформировать первый массив индексов   
		short getnext();      // сформировать следующий массив индексов  
		short ntx(short i);   // получить i-й элемент массива индексов  
		unsigned __int64 na;  // номер размещения 0, ..., count()-1 
		unsigned __int64 count() const;  // общее количество размещений 
	};

}