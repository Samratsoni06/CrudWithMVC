using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using TestApplication.Context;


namespace TestApplication.Controllers
{
    public class ProductController : Controller
    {
        SJMSEntities _context = new SJMSEntities();
        string message = string.Empty;
        public ActionResult Product(Product_Master objproduct)
        {
            List<Category_Master> Categorylist = _context.Category_Master.ToList();
            ViewData["Listitem"] = new SelectList(Categorylist, "CategoryID", "CategoryName");

            return View(objproduct);
        }
        public ActionResult AllProduct()
        {
            var response = _context.Product_Master.ToList();
            return View(response);
        }

        [HttpPost]
        public ActionResult SaveEdit(Product_Master product)
        {
            Product_Master Master = new Product_Master();
            try
            {
                if (ModelState.IsValid)
                {
                    Master.ProductID = product.ProductID;
                    Master.ProductName = product.ProductName;
                    Master.CategoryID = product.CategoryID;
                    Master.SalePrice = product.SalePrice;
                    Master.CostPrice = product.CostPrice;
                    Master.Inventory = product.Inventory;

                    if (product.ProductID == 0)
                    {
                        _context.Product_Master.Add(Master);
                        _context.SaveChanges();
                        message = "Product Add Sucess!";
                    }
                    else
                    {
                        _context.Entry(Master).State = EntityState.Modified;
                        _context.SaveChanges();
                        message = "Product Updatedd!";
                    }
                    ViewBag.messange = message;
                    ModelState.Clear();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            List<Category_Master> Categorylist = _context.Category_Master.ToList();
            ViewData["Listitem"] = new SelectList(Categorylist, "CategoryID", "CategoryName");

            return View("Product");
        }
        public string GetProductName(string Product)
        {
            string responde = _context.Product_Master.Where(x => x.ProductName == Product)
                .Select(x => x.ProductName).FirstOrDefault();
            return responde;
        }
        public ActionResult DeleteProduct(int ProductID)
        {
            var res = _context.Product_Master.Where(x => x.ProductID == ProductID).First();
            _context.Product_Master.Remove(res);
            _context.SaveChanges();
            var response = _context.Product_Master.ToList();
            return View("AllProduct", response);
        }
    }
}