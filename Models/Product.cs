    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    namespace CustomerApp.Models
    {
        public class Product
        {
            [DisplayName("Product Id")]
            public int Id { get; set; }
            [DisplayName("Nombre")]
            [StringLength(25)]
            public string Name { get; set; }
            [DisplayName("Precio")]
            public double Price { get; set; }

            public string Logo { get; set; }

            public ICollection<OrderProduct> OrderProducts { get; set; }
        }
    }