using APieceOfWoodIT.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace APieceOfWoodIT.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Card
        public ActionResult Index()
        {
            List<Tmp> tmp = db.Tmps.ToList();
            List<Product> products = new List<Product>();
            foreach (var product in tmp) {
                if (product.Id.Equals(User.Identity.GetUserId()))
                {
                    Product p = db.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
                    products.Add(p);
                }
            }
            return View(products);
        }

        public ActionResult Delete(int id)
        {
            List<Tmp> tmp = db.Tmps.ToList();
            foreach (var product in tmp)
            {
                if(product.Id.Equals(User.Identity.GetUserId()) && product.ProductId == id)
                {
                    db.Tmps.Remove(product);
                    break;
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddOrder()
        {
            List<Tmp> tmp = db.Tmps.ToList();
            Order o = new Order(User.Identity.GetUserId());
            db.Orders.Add(o);
            db.SaveChanges();
            int orderId=0;

            foreach (var order in db.Orders)
            {
                if (order.Equals(o))
                {
                    orderId=order.OrderId; break;
                }
            }

            foreach (var product in tmp)
            {
                if (product.Id.Equals(User.Identity.GetUserId()))
                {
                    OrderProduct or = new OrderProduct(orderId, product.ProductId);
                    db.OrderProducts.Add(or);
                    
                }
            }

            foreach (var product in tmp)
            {
                if (product.Id.Equals(User.Identity.GetUserId()))
                {
                    db.Tmps.Remove(product);
                }
            }

            db.SaveChanges();
            return View("OrderCompleted");
        }

    }
}