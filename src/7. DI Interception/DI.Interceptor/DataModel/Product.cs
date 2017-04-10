using System;

namespace DataModel
{
    public class Product : IProduct
    {
        public Product()
        {

        }

        public virtual int DoStuff(int x)
        {
            return ++x;
        }

    }
}
