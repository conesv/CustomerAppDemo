using CustomerApp.Data;
using CustomerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly CustomerContext _customerContext;

        public OrderController(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public IActionResult Order()
        {
            return View(_customerContext.Orders.ToList());
        }

        public IActionResult CreateOrder()
        {
            var order = new Order
            {
                DateOrdered = DateTime.Now,
                DateShipped = DateTime.Now.AddDays(2),
                CustomerId = Data.customer.Id,
                OrderProducts = new List<OrderProduct>()
            };

            foreach (var product in Data.products.DistinctBy(p=> p.Id).ToList())
            {
                 int count = Data.products.Count(c => c.Id==product.Id);
                var orderProduct = new OrderProduct
                {
                    ProductId = product.Id,
                    cantidad = count
                };

                order.OrderProducts.Add(orderProduct);
            }

            _customerContext.Orders.Add(order);
            _customerContext.SaveChanges();


            Data.products.Clear();
            return RedirectToAction("Order");
        }
        public IActionResult VerProductos(int orderId)
        {
            var order = _customerContext.Orders
        .Include(o => o.OrderProducts)
        .ThenInclude(op => op.Product)
        .FirstOrDefault(o => o.Id == orderId);

            if (order == null)
            {
                // Manejar la situación si no se encuentra la orden con el ID proporcionado
                return NotFound();
            }

            return View(order);
        }

        public IActionResult RemoverDeOrden(int Id, int Pid)
        {
            var orderToRemove = _customerContext.OrderProducts.FirstOrDefault(x=> x.OrderId == Id && x.ProductId == Pid);
            if (orderToRemove.cantidad == 1)
            {
                _customerContext.OrderProducts.Remove(orderToRemove);
            }
            else
            {
                orderToRemove.cantidad--;
            }
            _customerContext.SaveChanges();
            return RedirectToAction("Order");
        }

        public IActionResult EliminarOrden(int Id)
        {
            var orderToRemove = _customerContext.Orders.FirstOrDefault(x=> x.Id== Id);
            _customerContext.Orders.Remove(orderToRemove);
            _customerContext.SaveChanges();
            return RedirectToAction("Order");
        }

        public IActionResult addProduct(int Id)
        {
            List<Product> products = new List<Product>();
            products = _customerContext.Products.ToList();
            var order = _customerContext.Orders.FirstOrDefault(x => x.Id == Id);
            Data.ActiveOrder = order.Id;
            return View(products);
        }

        public IActionResult CaddProduct(int Id)
        {
            Product product = _customerContext.Products.FirstOrDefault(p => p.Id == Id);
            var order = _customerContext.Orders.FirstOrDefault(o => o.Id == Data.ActiveOrder);
            var orderProduct = new OrderProduct
            {
                OrderId=order.Id,
                ProductId = product.Id,
                cantidad = 1
            };
            order.OrderProducts.Add(orderProduct);
            _customerContext.SaveChanges();
            return RedirectToAction("Order");
        }

        public IActionResult AddOne(int Id,int Pid) 
        {
            var orderToRemove = _customerContext.OrderProducts.FirstOrDefault(x => x.OrderId == Id && x.ProductId==Pid);
            orderToRemove.cantidad++;
            _customerContext.SaveChanges();
            return RedirectToAction("Order");
        }
    }
}
