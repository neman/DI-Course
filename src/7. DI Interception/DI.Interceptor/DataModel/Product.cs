using System;

namespace DataModel
{
    public class Product
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
