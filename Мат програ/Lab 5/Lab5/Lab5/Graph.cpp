#include "stdafx.h"
#include "Graph.h"
namespace graph
{
 
AMatrix::AMatrix(int n, int mr[])
 {
   this->nV = n;
   this->mr = mr;
 };  

AMatrix::AMatrix(const AList& al)
 {
   this->nV = al.nV; 
   this->mr = new int [this->nV * this->nV];
   for(int k = 0; k < this->nV*this->nV; k++)
	   mr[k] = 0;
   for (int i = 0; i < this->nV; i++) 
      for (int j = 0; j < al.size(i); j++) 
		  this->set(i,al.get(i,j),1);
  };

void AMatrix::set(int i, int j, int r)
{
	this->mr[i*this->nV+j] = r;
};

int  AMatrix::get(int i, int j)const 
{
	return this->mr[i*this->nV+j];
};    

//------------List
void AList::create(int n) 
{
	this->mr = new std::list<int>[this->nV = n];
}; 

AList::AList(const AMatrix& am)
  {     
	 this->create(am.nV);
	 for (int i = 0; i < this->nV; i++)
       for (int j = 0; j < this->nV; j++)
			 if (am.get(i,j)!=0) 
				 this->add(i,j);  
  };   

AList::AList(int n, int mr[]) 
  {
    this->create(n);
    for (int i = 0; i < this->nV; i++)
       for (int j = 0; j < this->nV; j++)
			 if (mr[i*this->nV+j]!= 0) 
				 this->add(i,j);  

  }; 

void AList::add(int i, int j)
{
	this->mr[i].push_back(j);
};

int  AList::size(int i) const 
{
	return (int)this->mr[i].size();
}; 

int  AList::get(int i, int j)const
  {
	 std::list<int>::iterator rc = this->mr[i].begin(); 
	 for (int k = 0; k < j; k++)
		 rc++;
	 return (int)*rc;
  };
};
