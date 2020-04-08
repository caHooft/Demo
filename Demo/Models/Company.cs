﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Person> Owners { get; set; }
        public List<Car> OwnedCars { get; set; }
    }
}