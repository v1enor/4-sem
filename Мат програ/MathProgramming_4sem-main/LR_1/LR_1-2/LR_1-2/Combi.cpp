#include "Combi.h"
#include <algorithm>
namespace combi
{
	subset::subset(short n) // конструктор(количество элементов исходного множества)
	{
		this->n = n;
		this->sset = new short[n];
		this->reset();
	};
	void  subset::reset() // сбросить генератор, начать сначала
	{
		this->sn = 0;
		this->mask = 0;
	};
	short subset::getfirst() // сформормировать массив индексов по битовой маске  
	{
		__int64 buf = this->mask;
		this->sn = 0;
		for (short i = 0; i < n; i++)
		{
			if (buf & 0x1) this->sset[this->sn++] = i; // если в двоичной
			buf >>= 1; // сдвиг
		}
		return this->sn;
	};
	short subset::getnext() // ++ маска и сформировать массив индексов 
	{
		int rc = -1;
		this->sn = 0;
		if (++this->mask < this->count()) rc = getfirst();
		return rc;
	};
	short subset::ntx(short i) // получить i-й элемент массива индексов
	{
		return  this->sset[i];
	};
	unsigned __int64 subset::count() // вычислить общее количество подмножеств
	{
		return (unsigned __int64)(1 << this->n);
	};
};
