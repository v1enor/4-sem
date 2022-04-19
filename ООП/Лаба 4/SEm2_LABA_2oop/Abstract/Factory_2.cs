using System;
using System.Collections.Generic;
using System.Text;

namespace laba_2
{
    internal class Factory_2 : IAbstractFactory
    {
        public IProduct_1 Create_1()
        {
            return new Product_2_1();
        }

        public IProduct_2 Create_2()
        {
            return new Product_2_2();
        }
    }
}
