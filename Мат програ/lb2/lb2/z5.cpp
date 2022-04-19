#include "z5.h"
namespace boatfnc
{
    int calcv(combi2::xcombination s, const int v[])  // ���
    {
        int rc = 0;
        for (int i = 0; i < s.m; i++) rc += v[s.ntx(i)];
        return rc;
    };
    int calcc(combi2::xcombination s, const int c[]) // ����� 
    {
        int rc = 0;
        for (int i = 0; i < s.m; i++) rc += c[s.ntx(i)];
        return rc;
    };
    void   copycomb(short m, short* r1, const short* r2) // ����������    
    {
        for (int i = 0; i < m; i++)  r1[i] = r2[i];
    };
}
int  boat(
    int V,         // [in]  ������������ ��� �����
    short m,       // [in]  ���������� ���� ��� �����������     
    short n,       // [in]  ����� �����������  
    const int v[], // [in]  ��� ������� ����������  
    const int c[], // [in]  ����� �� ��������� ������� ����������     
    short r[]      // [out] ���������: ������� ��������� �����������  
)
{
    combi2::xcombination xc(n, m);
    int rc = 0, i = xc.getfirst(), cc = 0;
    while (i > 0)
    {
        if (boatfnc::calcv(xc, v) <= V)
            if ((cc = boatfnc::calcc(xc, c)) > rc)
            {
                rc = cc; boatfnc::copycomb(m, r, xc.sset);
            }
        i = xc.getnext();
    };
    return rc;
};
