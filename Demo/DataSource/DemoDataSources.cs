using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Models;
using static Demo.Models.Person;

namespace Demo.DataSource
{
    public class DemoDataSources
    {
        private static DemoDataSources instance = null;
        public static DemoDataSources Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DemoDataSources();
                }
                return instance;
            }
        }
        public List<Person> People { get; set; }
        public List<Car> Cars { get; set; }
        //public List<Company> Companies { get; set; }


        private DemoDataSources()
        {
            this.Reset();
            this.Initialize();
        }

        public void Reset()
        {
            this.People = new List<Person>();
            this.Cars = new List<Car>();
            //this.Companies = new List<Company>();
        }

        public void Initialize()
        {
            this.Cars.AddRange(new List<Car>
            {
                new Car()
                {
                    ID = 0,
                    AmountMade = 1,
                    Brand = _Brands.Audi,
                    Name= "A4",
                    TimeWhenAddedToDatabase = DateTime.Now,
                    APK = true,
                    //People = new List<Person>{ People[0], People[1]}
                },
                new Car()
                {
                    ID = 1,
                    AmountMade = 1234234,
                    Brand = _Brands.BMW,
                    Name= "I3",
                    TimeWhenAddedToDatabase = DateTime.Now,
                    APK = false,
                    //People = new List<Person>{ People[0], People[1], People[2]}
                },
                new Car()
                {
                    ID = 2,
                    AmountMade = 353451,
                    Brand = _Brands.Mini,
                    Name= "Clubman",
                    TimeWhenAddedToDatabase = DateTime.Now,
                    APK = true,
                },
                new Car()
                {
                    ID = 3,
                    AmountMade = 1678678,
                    Brand = _Brands.Ford,
                    Name= "Focus",
                    TimeWhenAddedToDatabase = DateTime.Now,
                    APK = false,
                },
            });

            this.People.AddRange(new List<Person>()
            {
                new Person()
                {
                   ID = 100,
                   Name="Sam Nasr",
                   //OwnedCar = Cars[0].Name,
                   Car = Cars[0],

                   //CurrentOrder = new Order()
                   //{
                   //    OrderID = 103,
                   //    ShippingAddress = "1234 Walnut Street, Cleveland, Ohio 44101",
                   //},

                   //OrdersShipped = new List<Order>()
                   // {
                   //     new Order()
                   //     {
                   //         OrderID = 101,
                   //         ShippingAddress = "2121 E.9th Street, Cleveland, Ohio 44103",
                   //     },
                   //     new Order()
                   //     {
                   //         OrderID = 102,
                   //         ShippingAddress = "3221 W.6th Street, Cleveland, Ohio 44104",
                   //     },
                   // },
                },

              new Person()
                {
                   ID = 200,
                   Name="James Williams",
                   //OwnedCar = Cars[1].Name,
                   Car = Cars[1],

                   //CurrentOrder = new Order()
                   //{
                   //    OrderID = 203,
                   //    ShippingAddress = "8901 Chestnut Street, Cleveland, Ohio 44101",

                   //},

                   //OrdersShipped = new List<Order>()
                   // {
                   //     new Order()
                   //     {
                   //         OrderID = 201,
                   //         ShippingAddress = "5477 E.49th Street, Cleveland, Ohio 44103",
                   //     },
                   //     new Order()
                   //     {
                   //         OrderID = 202,
                   //         ShippingAddress = "7181 W.6th Street, Cleveland, Ohio 44104",
                   //     },
                   // },
                }

            });

            //this.Companies.AddRange(new List<Company>()
            //{
            //    new Company()
            //    {
            //        ID = 0,
            //        Name = "Owners",
            //        //OwnedCars =  new List<Car>{ Cars[1]},
            //        Owners = new List<Person>{ People[1]}
            //    },
            //    new Company()
            //    {
            //        ID = 1,
            //        Name = "Owners2",
            //    },
            //});
        }
    }
}