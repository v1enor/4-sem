#include <stdio.h>
#include <stdlib.h>
//--для возведения в степень
#include <math.h>

int main()
{
    int m[4] = { 2, 5, 6, 9 }; //--множество
    int w = 4; //--кол-во элементов множества

    int i, j, n;

    n = pow(2, w);
    for (i = 0; i < n; i++) //--перебор битовых маск
    {
        printf("{");
        for (j = 0; j < w; j++) //--перебор битов в маске
            if (i & (1 << j)) //--если j-й бит установлен
                printf("%d ", m[j]); //--то выводим j-й элемент множества
        printf("}\n");
    }
   return 0;
}