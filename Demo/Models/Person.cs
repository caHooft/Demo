using Microsoft.AspNet.OData.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Demo.Models
{
    public class Person
    {
        public String ID { get; set; }

        [Required]
        public String Name { get; set; }
        //public List<Car> Cars { get; set; }

        [Singleton]
        public Company Company { get; set; }
    }
}