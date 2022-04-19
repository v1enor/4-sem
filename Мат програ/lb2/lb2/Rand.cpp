
#include "Rand2.h" 
#include <ctime>    
namespace auxil
{
    void start()                          // �����  ���������� ��. �����
    {
        srand((unsigned)time(NULL));
    };
    double dget(double rmin, double rmax) // �������� ��������� �����
    {
        return ((double)rand() / (double)RAND_MAX) * (rmax - rmin) + rmin;
    };
    int iget(int rmin, int rmax)         // �������� ��������� �����

    {
        return (int)dget((double)rmin, (double)rmax);
    };
}
