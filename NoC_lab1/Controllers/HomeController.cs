using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NoC_lab1.DB;
using NoC_lab1.Entitys;
using NoC_lab1.Models;

namespace NoC_lab1.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            Orderrepo = new OrderRepository();
            ProductR = new ProductRepository();
            KorzinaR = new KorzinaRepository();
        }
        IRepository<Order> Orderrepo;
        IRepository<Product> ProductR;
        static ProductHistory productHistory = new ProductHistory();
        KorzinaRepository KorzinaR;
        
        public IActionResult Index()
        {
            
           
            var Products = ProductR.GetSome(null);
            ViewBag.Products = Products;
            return View();
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.ProductId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {

            Orderrepo.Create(order);
            return "Спасибо за покупку!";
        }
 
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.ProductId = id;
            return View();
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            ProductOrganizator productOrganizator = new ProductOrganizator(product);
            productHistory.History.Push(productOrganizator.SaveState());
            return RedirectToAction("Index");
        }
    
        public IActionResult UpdatePost(Product product)
        {
            ProductOrganizator productOrganizator = new ProductOrganizator(product);
            productOrganizator.RestoreState(productHistory.History.Pop());
            product = productOrganizator.SaveState();
            ProductR.Update(product);
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
           
           
            var product = ProductR.GetSome(null);
            ViewBag.product = product;
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            
            
            var korzina = KorzinaR.GetSome(null);
            ViewBag.Orders = korzina;
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            ProductObservable observable = new ProductObservable();
            DbObserver dbObserver = new DbObserver(observable);
            observable.DeleteModel(id.Value);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
