using CustomerApp.Models;

namespace CustomerApp.Controllers
{
    public class Data
    {
        public static List<Product> products = new List<Product>();

        public static Customer customer;

        public static int ActiveOrder;
    }
}
