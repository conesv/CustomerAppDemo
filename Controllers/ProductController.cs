using CustomerApp.Data;
using CustomerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly CustomerContext _customerContext;

        public ProductController(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public IActionResult Product()
        {
            return View(_customerContext.Products.ToList());
        }
        [HttpGet]
        public IActionResult CrearProductForm() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult CrearProductForm(Product product) 
        {
                _customerContext.Products.Add(product);
                _customerContext.SaveChanges();
                return RedirectToAction("Product");
        }

        public IActionResult AddProduct(int Id)
        {
            Product product  = new Product();
            product = _customerContext.Products.FirstOrDefault(c => c.Id == Id);
            Data.products.Add(product);
            return RedirectToAction("Product");
        }
    }
}
