using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Demo.Models
{
    public enum _Brands { Tesla, Ferrari, Mini, Porsche, Volkswagen, Nissan, Audi, Ford, Honda, BMW, Mercedes, Toyota };

    public class Car
    {
        [Key]
        public int ID { get; set; }
        public double AmountMade { get; set; }
        public Boolean APK { get; set; }
        public String Colour { get; set; }
        public DateTime TimeWhenAddedToDatabase { get; set; }
        public _Brands Brand { get; set; }
        public List<Person> People { get; set; }
    }
}