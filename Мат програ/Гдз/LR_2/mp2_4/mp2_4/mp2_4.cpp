#include <iostream>
using namespace std;
bool NextSet(int* a, int n, int m)
{
    int j = m - 1;
    while (j >= 0 && a[j] == n) j--;
    if (j < 0) return false;
    if (a[j] >= n)
        j--;
    a[j]++;
    if (j == m - 1) return true;
    for (int k = j + 1; k < m; k++)
        a[k] = 1;
    return true;
}
void Print(int* a, int n)
{
    static int num = 1;
    cout.width(3);
    cout << num++ << ":  ";
    for (int i = 0; i < n; i++)
        cout << a[i] << " ";
    cout << endl;
}
int main()
{
    int n, m, * a;
    cout << "N = ";
    cin >> n;
    cout << "M = ";
    cin >> m;
    int h = n > m ? n : m; // размер массива а выбирается как max(n,m)
    a = new int[h];
    for (int i = 0; i < h; i++)
        a[i] = 1;
    Print(a, m);
    while (NextSet(a, n, m))
        Print(a, m);
    cin.get(); cin.get();
    return 0;
}