using NoC_lab1.DB;
using NoC_lab1.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoC_lab1
{
    public class PojiloyFactory
    {
        public static IRepository<Order> ReturnOrderRepository()
        {
            return new OrderRepository();
        }

        public static IRepository<Product> ReturnProductRepository()
        {
            return new ProductRepository();
        }

        public static IRepository<Korzinka> ReturnKorzinaRepository()
        {
            return new KorzinaRepository();
        }
    }
}
