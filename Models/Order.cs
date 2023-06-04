using System.ComponentModel;

namespace CustomerApp.Models
{
    public class Order
    {
        [DisplayName("Order Id")]
        public int Id { get; set; }
        [DisplayName("Fecha inicio")]
        public DateTime DateOrdered { get; set; }

        [DisplayName("Fecha final")]
        public DateTime DateShipped { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } 
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    }
}