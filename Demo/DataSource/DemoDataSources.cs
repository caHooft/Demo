using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Models;

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
        public List<Range> Ranges { get; set; }

        //public int minValue { get; set; }
        //public int maxValue { get; set; }
        //public struct Range { }
        //public List<Range> Ranges { get; set; }

        //public struct Ranges
        //{
        //    public int min;
        //    public int max;
        //}

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
            this.Ranges = new List<Range>();
            //this.Ranges = new List<Range>();
            //this.Companies = new List<Company>();
        }

        public void Initialize()
        {
            this.Ranges.AddRange(new List<Range>()
            {
                new Range()
                {
                    maxValue = 10,
                    minValue = 0,
                },
            });

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
                },
                new Car()
                {
                    ID = 1,
                    AmountMade = 1234234,
                    Brand = _Brands.BMW,
                    Name= "I3",
                    TimeWhenAddedToDatabase = DateTime.Now,
                    APK = false,
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
                   Car = Cars[0], 
                   
                   Ranges = new Range
                   {
                       maxValue =10,
                       minValue=0,
                   }                

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
                   Car = Cars[1],


                   Ranges = new Range
                   {
                       maxValue =10,
                       minValue=0,
                   }  

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

            Cars[0].People = new List<Person> { };
            Cars[1].People = new List<Person> { People[0] };
            Cars[2].People = new List<Person> { People[1] };
            Cars[3].People = new List<Person> { People[0], People[1] };
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