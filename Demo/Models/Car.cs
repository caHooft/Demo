using Microsoft.AspNet.OData.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public enum _Brands { Tesla, Ferrari, Mini, Porsche, Volkswagen, Nissan, Audi, Ford, Honda, BMW, Mercedes, Toyota };

    public class Car
    {
        [Key]
        public int ID { get; set; }
        public double AmountMade { get; set; }
        public Boolean APK { get; set; }
        public String Name { get; set; }
        public DateTime TimeWhenAddedToDatabase { get; set; }
        public _Brands Brand { get; set; }
        public List<Person> People { get; set; }

        //[Singleton]
        //public Company Company { get; set; }

        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}