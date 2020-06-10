using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoC_lab1.Entitys
{
    public class Product : ICloneable
    {
        public int IdProduct { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string info { get; set; }

        public int idManufacturer { get; set; }

        public int idProduct_type { get; set; }

        public object Clone()
        {
            return new Product
            {
                IdProduct = IdProduct,
                Name = Name,
                Price = Price,
                Quantity = Quantity,
                info = info,
                idManufacturer = idManufacturer,
                idProduct_type = idProduct_type
            };
        }


        public override string ToString()
        {
            string result = "";
            result += "idProduct: " + this.IdProduct + "\n";
            result += "Name: " + this.Name + "\n";
            result += "Price: " + this.Price + "\n";
            result += "Quantity: " + this.Quantity + "\n";
            result += "info: " + this.info + "\n";
            result += "IdManufacturer: " + this.idManufacturer + "\n";
            result += "Product_type: " + this.idProduct_type + "\n";
            return base.ToString();
        }
    }
}
