using CustomerApp.Data;
using CustomerApp.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CustomerApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerContext _customerContext;
        public CustomerController(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public static bool status = false;
        public IActionResult DisplayData(int Id)
        {
            return View(_customerContext.Customers.FirstOrDefault(x=> x.Id==Id));
        }
        public IActionResult Customers()
        {
            return View(_customerContext.Customers.ToList());
        }
        //public IActionResult NewCustomer()
        //{
        //    Customer customer = new Customer
        //    {
        //        Id = 4,
        //        FirstName = "Daniel",
        //        LastName = "Galindo",
        //        Address = "Dirección1",
        //        Phone = "54234432",
        //        Email = "daniel@example.com",
        //        status = true
        //    };
        //    Data data = new Data();
        //    data.NewCustomer(customer);
        //    return RedirectToAction("Customers");
        //}

        [HttpGet]
        public IActionResult NewCustomerForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewCustomerForm(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerContext.Customers.Add(customer);
                _customerContext.SaveChanges();
                return RedirectToAction("Customers");
            }
            else
                return View();
        }

        public IActionResult statuschange()
        {
            if (status == true)
                status = false;
            else
                status = true;
            return RedirectToAction("Customers");
        }

        public IActionResult ModificarCustomer(int Id)
        {
            Data data = new Data();
            return View(_customerContext.Customers.FirstOrDefault(x => x.Id==Id));
        }

        public IActionResult EnviarModificarCustomer(Customer customer)
        {
            if (ModelState.IsValid) { 
                Customer Ncustomer = new Customer();
            Ncustomer =  _customerContext.Customers.FirstOrDefault(c => c.Id==customer.Id);
            if (Ncustomer != null)
            {
                Ncustomer.FirstName = customer.FirstName;
                Ncustomer.LastName = customer.LastName;
                Ncustomer.Phone = customer.Phone;
                Ncustomer.Email = customer.Email;
                Ncustomer.Address = customer.Address;
                Ncustomer.status = customer.status;
                
                _customerContext.SaveChanges();
                return RedirectToAction("Customers");
            }
            return RedirectToAction("Customers");
            }
            else { return RedirectToAction("Customers"); }
        }

        public IActionResult BajaCustomer(int Id)
        {
            Customer Ncustomer = new Customer();
            Ncustomer = _customerContext.Customers.FirstOrDefault(c => c.Id == Id);
            if (Ncustomer.status == true)
                Ncustomer.status = false;
            else
                Ncustomer.status = true;
            _customerContext.SaveChanges();
            return RedirectToAction("Customers");
        }

        public IActionResult Identificarse(int Id)
        {
            Customer customer = new Customer();
            customer = _customerContext.Customers.FirstOrDefault(c => c.Id == Id);
            Data.customer = customer;
            return RedirectToAction("Customers");
        }
    }
}
