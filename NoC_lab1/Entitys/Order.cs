using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoC_lab1.Entitys
{
    public class Order
    {
        public int IdOrder { get; set; }

        public int Delivery { get; set; }

        public string Data { get; set; }

        public int Price { get; set; }

        public int idUser { get; set; }
    }
}
