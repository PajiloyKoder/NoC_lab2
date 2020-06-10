using NoC_lab1.DB;
using NoC_lab1.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoC_lab1
{
    public class ProductOrganizator
    {
        private IRepository<Product> ProdRepo = PojiloyFactory.ReturnProductRepository();
        private Product product;

        public ProductOrganizator(Product product)
        {
            this.product = product;
        }

        public Product SaveState()
        {
            ProdRepo.Update(product);
            return (Product)product.Clone();
        }

        public void RestoreState(Product product)
        {
            this.product = (Product)product.Clone();
        }
    }
}
