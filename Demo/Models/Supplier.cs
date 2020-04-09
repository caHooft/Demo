using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class Supplier
    {
        public int id { get; set; }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}