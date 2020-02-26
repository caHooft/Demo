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
        public List<Vechicle> Vechicles { get; set; }
        public List<Car> Cars { get; set; }

        private DemoDataSources()
        {
            this.Reset();
            this.Initialize();
        }

        public void Reset()
        {
            this.People = new List<Person>();
            this.Vechicles = new List<Vechicle>();
            this.Cars = new List<Car>();
        }

        public void Initialize()
        {
            this.Vechicles.AddRange(new List<Vechicle>()
            {
                new Vechicle()
                {
                    ID = "0"
                },
                new Vechicle()
                {
                    ID = "1"
                },
                new Vechicle()
                {
                    ID = "2"
                },
                new Vechicle()
                {
                    ID = "3"
                }
            });

            this.People.AddRange(new List<Person>
            {
                new Person()
                {
                    ID = "001",
                    Name = "Angel",
                    //Vechicles = new List<Vechicle>{Vechicles[0], Vechicles[1]}
                },
                new Person()
                {
                    ID = "002",
                    Name = "Clyde",
                    Description = "Contrary to popular belief, Lorem Ipsum is not simply random text.",
                    //Vechicles = new List<Vechicle>{Vechicles[2], Vechicles[3]}
                },
                new Person()
                {
                    ID = "003",
                    Name = "Elaine",
                    Description = "It has roots in a piece of classical Latin literature from 45 BC, making Lorems over 2000 years old."
                }
            });

            this.Cars.AddRange(new List<Car>()
            {
                new Car()
                {
                    ID = 0,
                    AmountMade = 1,
                    Brand = _Brands.Audi,
                    Colour= "red",
                    TimeWhenAddedToDatabase = DateTime.Now,
                    APK = true
                },
                new Car()
                {
                    ID = 1,
                    AmountMade = 1234234,
                    Brand = _Brands.BMW,
                    Colour= "Blue",
                    TimeWhenAddedToDatabase = DateTime.Now,
                    APK = false
                },
                new Car()
                {
                    ID = 2,
                    AmountMade = 353451,
                    Brand = _Brands.Mini,
                    Colour= "red",
                    TimeWhenAddedToDatabase = DateTime.Now,
                    APK = true
                },
                new Car()
                {
                    ID = 3,
                    AmountMade = 1678678,
                    Brand = _Brands.Ford,
                    Colour= "Blue",
                    TimeWhenAddedToDatabase = DateTime.Now,
                    APK = false
                },
            });
        }
    }
}