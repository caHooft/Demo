using Microsoft.AspNet.OData.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Demo.Models
{
    public class Person
    {
        public int ID { get; set; }

        public string OwnedCar { get; set; }

        [Required]
        public String Name { get; set; }
        
        //[Contained]
        public IList<Order> OrdersShipped { get; set; }

        //[Contained]
        public Order CurrentOrder { get; set; }
        //public List<Car> Cars { get; set; }

        //[Singleton]
        //public Company Company { get; set; }

        //public class Order
        //{
        //    public int OrderID { get; set; }
        //    public string ShippingAddress { get; set; }

        //}
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string ShippingAddress { get; set; }

    }
}