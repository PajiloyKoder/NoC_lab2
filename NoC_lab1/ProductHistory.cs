using NoC_lab1.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoC_lab1
{
    public class ProductHistory
    {
        public Stack<Product> History { get; private set; }
        public ProductHistory()
        {
            History = new Stack<Product>();
        }
    }
}
