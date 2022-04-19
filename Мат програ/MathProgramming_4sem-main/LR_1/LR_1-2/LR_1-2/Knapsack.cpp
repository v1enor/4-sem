#include "Knapsack.h"
#define NINF 0x80000000    // самое малое int-число
int calcv(combi::subset s, const int v[])  // объем в рюкзаке
{
	int rc = 0;
	for (int i = 0; i < s.sn; i++) rc += v[s.ntx(i)];
	return rc;
};
int calcc(combi::subset s, const int v[], const int c[]) //стоимость в рюкзаке
{
	int rc = 0;
	for (int i = 0; i < s.sn; i++) rc += (v[s.ntx(i)] * c[s.ntx(i)]);
	return rc;
};
void setm(combi::subset s, short m[])//отметить выбранные предметы
{
	for (int i = 0; i < s.n; i++) m[i] = 0;
	for (int i = 0; i < s.sn; i++) m[s.ntx(i)] = 1;
};
int   knapsack_s(
	int V,         // [in] вместимостьрюкзака
	short n,       // [in] количество типов предметов
	const int v[], // [in] размер предмета каждого типа
	const int c[], // [in] стоимость предмета каждого типа
	short  m[]     // [out] количество предметов каждого типа {0,1}
)
{
	combi::subset s(n);
	int maxc = NINF, cc = 0;
	short  ns = s.getfirst();  // сформормировать массив индексов по битовой маске   
	while (ns >= 0)
	{
		if (calcv(s, v) <= V)
			if ((cc = calcc(s, v, c)) > maxc)
			{
				maxc = cc;
				setm(s, m);
			}
		ns = s.getnext();
	};
	return maxc;
};
