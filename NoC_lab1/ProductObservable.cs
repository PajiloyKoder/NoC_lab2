using NoC_lab1.DB;
using NoC_lab1.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoC_lab1
{
    public class ProductObservable : IObservable
    {
        Product product;
        private IRepository<Product> prodRepo = PojiloyFactory.ReturnProductRepository();

        List<IObserver> observers;
        public ProductObservable()
        {
            observers = new List<IObserver>();
            product = new Product();
        }

        public ProductObservable(Product product)
        {
            observers = new List<IObserver>();
            this.product = product;
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyUpdateObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(product);
            }
        }

        public void NotifyCreateObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(product);
            }
        }

        public void NotifyDeleteObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Delete(product);
            }
        }

        public void ChangeModel(Product product)
        {
            prodRepo.Update(product);
            this.product = product;
            NotifyUpdateObservers();
        }

        public void CreateModel(Product product)
        {
            prodRepo.Create(product);
            this.product = product;
            NotifyCreateObservers();
        }

        public void DeleteModel(int id)
        {
            prodRepo.Delete(id);
            NotifyDeleteObservers();
        }
    }
}
