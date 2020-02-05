using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Demo.Models
{
    public enum Brands { Tesla, Ferrari, Mini, Porsche, Volkswagen, Nissan, Audi, hyundai, Ford, Honda, BMW, Mercedes, Toyota };

    public class Car
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public double AmountMade { get; set; }
        public Brands _brand { get; set;}
        public String Colour { get; set; }
        public DateTime CreationTime { get; set; }
        public Boolean APK { get; set; }

    }
}