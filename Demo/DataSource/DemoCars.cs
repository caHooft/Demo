using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Models;

namespace Demo.DataSource
{
    public class DemoCars
    {
        private static DemoCars instance = null;
        public static DemoCars Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DemoCars();
                }
                return instance;
            }
        }
        public List<Car> Cars { get; set; }

        private DemoCars()
        {
            this.Reset();
            this.Initialize();
        }

        public void Reset()
        {
            this.Cars = new List<Car>();
        }

        public void Initialize()
        {

            this.Cars.AddRange(new List<Car>()
            {
                new Car()
                {
                    ID = 0,
                    AmountMade = 1,
                    _brand = Brands.Audi,
                    Colour= "red",
                    CreationTime = DateTime.Now,
                    APK = true
                },
                new Car()
                {
                    ID = 1,
                    AmountMade = 1,
                    _brand = Brands.BMW,
                    Colour= "Blue",
                    CreationTime = DateTime.Now,
                    APK = false
                }
            });
        }
    }
}