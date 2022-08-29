using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using laba12.Model;
using laba12.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace laba12.ViewModel
{
    public class MarketViewModel : ViewModelBase
    {
        private ObservableCollection<string> nameProduct1;
        public ObservableCollection<string> NameProduct1
        {
            get { return nameProduct1; }
            set { nameProduct1 = value; RaisePropertyChanged(() => NameProduct1); }
        }

        private ObservableCollection<int> count1;
        public ObservableCollection<int> Count1
        {
            get { return count1; }
            set { count1 = value; RaisePropertyChanged(() => Count1); }
        }

        private string selectedProduct1;
        public string SelectedProduct1
        {
            get { return selectedProduct1; }
            set { selectedProduct1 = value; RaisePropertyChanged(() => SelectedProduct1); }
        }

        private string selectedProduct2;
        public string SelectedProduct2
        {
            get { return selectedProduct2; }
            set { selectedProduct2 = value; RaisePropertyChanged(() => SelectedProduct2); }
        }

        private ObservableCollection<string> nameProduct2;
        public ObservableCollection<string> NameProduct2
        {
            get { return nameProduct2; }
            set { nameProduct2 = value; RaisePropertyChanged(() => NameProduct2); }
        }

        private ObservableCollection<int> count2;
        public ObservableCollection<int> Count2
        {
            get { return count2; }
            set { count2 = value; RaisePropertyChanged(() => Count2); }
        }

        //private int sum;
        //public int Sum
        //{
        //    get { return sum; }
        //    set { sum = value; RaisePropertyChanged(() => Sum); }
        //}

        private ObservableCollection<string> name1;
        private ObservableCollection<int> c1;
        private ObservableCollection<string> name2;
        private ObservableCollection<int> c2;
        private UnitOfWork unitOfWork;
        public MarketViewModel()
        {
            unitOfWork = new UnitOfWork();

            var result = unitOfWork.Product.GetAll().ToList();

            name1 = new ObservableCollection<string>();
            c1 = new ObservableCollection<int>();
            name2 = new ObservableCollection<string>();
            c2 = new ObservableCollection<int>();
            for (int i = 0; i < result.Count(); i++)
            {
                name1.Add(result[i].Name);
                c1.Add(result[i].Count);
            }
            NameProduct1 = name1;
            Count1 = c1;
        }

        public ICommand Add_Click
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if(SelectedProduct1 != null)
                    {
                        var result = unitOfWork.Product.GetByName(SelectedProduct1);
                        var cart = unitOfWork.ShoppingCart.GetByProductId(result.Id);
                        if(cart != null && result.Count != 0)
                        {
                            unitOfWork.ShoppingCart.Update(cart, new ShoppingCart(cart.Count + 1, cart.ProductId));
                            unitOfWork.Product.Update(result, new Product(result.Name, result.Price, result.Count - 1));
                            unitOfWork.Save();
                            
                            
                            var k1 = unitOfWork.Product.GetAll().ToList();
                            c1.Clear();
                            for (int i = 0; i < k1.Count(); i++)
                            {
                                c1.Add(k1[i].Count);
                            }
                            Count1 = c1;
                            c2.Clear();
                            var k = unitOfWork.ShoppingCart.GetAll().ToList();
                            for (int i = 0; i < k.Count(); i++)
                            {
                                c2.Add(k[i].Count);
                            }
                            Count2 = c2;
                            
                        }
                        else
                        {
                            if (result.Count != 0)
                            {
                                unitOfWork.ShoppingCart.Create(new ShoppingCart(1, result.Id));
                                unitOfWork.Product.Update(result, new Product(result.Name, result.Price, result.Count - 1));
                                unitOfWork.Save();
                                var k1 = unitOfWork.Product.GetAll().ToList();
                                c1.Clear();
                                for (int i = 0; i < k1.Count(); i++)
                                {
                                    c1.Add(k1[i].Count);
                                }
                                Count1 = c1;
                                var k = unitOfWork.ShoppingCart.GetAll().ToList();
                                c2.Clear();
                                name2.Clear();
                                for (int i = 0; i < k.Count(); i++)
                                {
                                    c2.Add(k[i].Count);
                                    name2.Add(unitOfWork.Product.Get((int)k[i].ProductId).Name);
                                    
                                }

                                NameProduct2 = name2;
                                Count2 = c2;
                            }
                        }
                        //var k3 = unitOfWork.ShoppingCart.GetAll().ToList();
                        //for (int i = 0; i < k3.Count(); i++)
                        //{
                        //    Sum += unitOfWork.Product.Get((int)k3[i].ProductId).Price * k3[i].Count;
                        //}

                    }
                });
            }
        }

        public ICommand Delete_Click
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (SelectedProduct2 != null)
                    {
                        var result = unitOfWork.Product.GetByName(SelectedProduct2);
                        var cart = unitOfWork.ShoppingCart.GetByProductId(result.Id);

                        if(cart.Count != 1)
                        {
                            unitOfWork.ShoppingCart.Update(cart, new ShoppingCart(cart.Count - 1, cart.ProductId));
                            unitOfWork.Product.Update(result, new Product(result.Name, result.Price, result.Count + 1));
                            unitOfWork.Save();

                            var k1 = unitOfWork.Product.GetAll().ToList();
                            c1.Clear();
                            for (int i = 0; i < k1.Count(); i++)
                            {
                                c1.Add(k1[i].Count);
                            }
                            Count1 = c1;

                            var k = unitOfWork.ShoppingCart.GetAll().ToList();
                            c2.Clear();
                            for (int i = 0; i < k.Count(); i++)
                            {
                                c2.Add(k[i].Count);
                            }
                            Count2 = c2;
                        }
                        else
                        {
                            unitOfWork.ShoppingCart.Delete(cart.Id);
                            unitOfWork.Product.Update(result, new Product(result.Name, result.Price, result.Count + 1));
                            unitOfWork.Save();

                            var k1 = unitOfWork.Product.GetAll().ToList();
                            c1.Clear();
                            for (int i = 0; i < k1.Count(); i++)
                            {
                                c1.Add(k1[i].Count);
                            }
                            Count1 = c1;

                            var k = unitOfWork.ShoppingCart.GetAll().ToList();
                            c2.Clear();
                            name2.Clear();
                            for (int i = 0; i < k.Count(); i++)
                            {
                                c2.Add(k[i].Count);
                                name2.Add(unitOfWork.Product.Get((int)k[i].ProductId).Name);

                            }

                            NameProduct2 = name2;
                            Count2 = c2;
                        }

                    }
                });
            }
        }
    }
}
