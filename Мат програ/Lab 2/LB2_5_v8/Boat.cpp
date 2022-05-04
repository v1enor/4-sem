#include "pch.h"
#include "Boat.h"
#include "Combi.h"
namespace boatfnc
{
	bool compv(combi::accomodation s, const int ming[], const int maxg[], const int v[])
	{
		int i = 0;
		while (i < s.m && v[s.ntx(i)] <= maxg[i] && v[s.ntx(i)] >= ming[i]) i++;	// пока контейнер удовлетворяет условиям перевозки 
		return (i == s.m);
	};
	int calcc(combi::accomodation s, const int c[])		// подсчет дохода от перевозки
	{
		int rc = 0;
		for (int i = 0; i < s.m; i++) rc += c[s.ntx(i)];
		return rc;
	};
	void copycomb(short m, short *r1, const short *r2)
	{
		for (int i = 0; i < m; i++)  r1[i] = r2[i];
	};
}
int boat_с(      // функция возвращает доход от перевозки контейнеров
	short m,      // [in] количество мест для контейнеров
	int minv[],   // [in] минимальный вес контейнера на каждом  месте 
	int maxv[],   // [in] максимальный вес коннтейнера каждом месте 
	short n,      // [in] всего контейнеров  
	const int v[],// [in] вес каждого контейнера  
	const int c[],// [in] доход от перевозки каждого контейнера   
	short r[]     // [out] номера выбранных контейнеров  
)
{
	combi::accomodation s(n, m);	// размещения
	int rc = 0, i = s.getfirst(), cc = 0;
	while (i > 0)
	{
		if (boatfnc::compv(s, minv, maxv, v))	// если загрузка уд.условию
			if ((cc = boatfnc::calcc(s, c)) > rc)	// если цена выше предыдущей
			{
				rc = cc; 
				boatfnc::copycomb(m, r, s.sset);
			}
		i = s.getnext();
	};
	return rc;
};
