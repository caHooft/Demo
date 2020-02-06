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
                    Brand = _Brands.Audi,
                    Colour= "red",
                    CreationTime = DateTime.Today,
                    APK = true
                },
                new Car()
                {
                    ID = 1,
                    AmountMade = 1234234,
                    Brand = _Brands.BMW,
                    Colour= "Blue",
                    CreationTime = DateTime.UtcNow,
                    APK = false
                },
                new Car()
                {
                    ID = 2,
                    AmountMade = 353451,
                    Brand = _Brands.Mini,
                    Colour= "red",
                    CreationTime = DateTime.Now,
                    APK = true
                },
                new Car()
                {
                    ID = 3,
                    AmountMade = 1678678,
                    Brand = _Brands.Ford,
                    Colour= "Blue",
                    CreationTime = DateTime.UtcNow,
                    APK = false
                },
                new Car()
                {
                    ID = 4,
                    AmountMade = 123424,
                    Brand = _Brands.Honda,
                    Colour= "red",
                    CreationTime = DateTime.Today,
                    APK = true
                },
                new Car()
                {
                    ID = 5,
                    AmountMade = 1345353,
                    Brand = _Brands.Nissan,
                    Colour= "Blue",
                    CreationTime = DateTime.Now,
                    APK = false
                },
            });
        }
    }
}