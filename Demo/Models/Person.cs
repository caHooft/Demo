using Microsoft.AspNet.OData.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Demo.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Required]
        public String Name { get; set; }
        
        [Contained]
        public IList<CustomerOrders> OrdersShipped { get; set; }

        [Contained]
        public CustomerOrders CurrentOrder { get; set; }
        //public List<Car> Cars { get; set; }


        //[Singleton]
        //public Company Company { get; set; }
    }
}