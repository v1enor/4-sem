using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace laba_2
{
    internal class Factory_1 : IAbstractFactory
    {
        public IProduct_1 Create_1()
        {
            return new Product_1_1();
        }

        public IProduct_2 Create_2()
        {
            return new Product_1_2();
        }
    }
}