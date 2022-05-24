 #pragma once
#include <list>
#include "Graph.h"
namespace graph
{
struct AList;                        
struct AMatrix  // матрица смежности 
 {
     int nV;                  // количество вершин 
     int  *mr;                       // матрица  
     AMatrix(int n, int mr[]);       // создать матрицу n*n и	
     AMatrix(const AList& al);       // создать матрицу из спискового 
     void set(int i, int j, int r);  // записать mr[i,j] = r
     int  get(int i, int j)const;    // элемент mr[i,j] 
};

struct AList  // списки смежности 
 {
     int nV;                 // количество вершин 
     std::list<int> *mr;            // массив списков
     void create(int n);            // создать массив пустых списков
     AList(int n, int mr[]);        // создать списковое представление	 
     AList(const AMatrix& am);      // создать списковое представление  
     void add(int i, int j);        // добавить в i-ый список
     int  size(int i) const;        // размер i-го списка  
     int  get(int i, int j)const;   // j-ый  элемент i-го списка 
 };

};
#pragma once
