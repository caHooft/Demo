using System;
using System.Collections.Generic;
using System.Web;
using Demo.DataSource;
using Demo.Models;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using static Demo.Models.Person;

namespace Demo.Controllers
{
    [EnableQuery]
    //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
    public class PeopleController : ODataController
    {
        private static IList<Person> _People = null;
        //private static float maxValue = Demo.DataSource.DemoDataSources.Instance.maxValue;
       // private static float minValue = Demo.DataSource.DemoDataSources.Instance.minValue;

        public PeopleController()
        {
            //if (maxValue == null || minValue == null)
            //{
            //    maxValue = Demo.DataSource.DemoDataSources.Instance.maxValue;
            //    minValue = Demo.DataSource.DemoDataSources.Instance.minValue;

            //}

            if (_People == null)
            {
                //_People = DemoDataSources.Instance.People.ToList();
                _People = Demo.DataSource.DemoDataSources.Instance.People.ToList();
            }
        }

        public IHttpActionResult Get(int key)
        {
            //return Ok(DemoDataSources.Instance.People.AsQueryable());
            return Ok(_People.AsQueryable().First(p => p.ID==key));
        }

        public IHttpActionResult Get()
        {
            //return Ok(DemoDataSources.Instance.People.AsQueryable());
            return Ok(_People.AsQueryable());
        }

        [ODataRoute("People({key})/Car")]
        public IHttpActionResult GetCar(int key)
        {
            return Ok(_People.First(p => p.ID == key).Car);
        }

        [ODataRoute("People({key})/Name")]
        public IHttpActionResult GetName(int key)
        {
            return Ok(_People.First(p => p.ID == key).Name);
        }

        //[EnableQuery]
        //public IHttpActionResult GetOrdersShipped(int key)
        //{
        //    var OrdersShipped = _People.Single(a => a.ID == key).OrdersShipped;
        //    return Ok(OrdersShipped);
        //}

        //[EnableQuery]
        //[ODataRoute("people({ID})/OrdersShipped({OrderID})")]
        ////sShipped
        ////"url": "http://localhost:52412/odata/people"
        //public IHttpActionResult GetSingleOrderShipped(int Id, int OrderId)
        //{
        //    var OrdersShipped = _People.Single(a => a.ID == Id).OrdersShipped;
        //    var OrderShipped = OrdersShipped.Single(pi => pi.OrderID == OrderId);
        //    return Ok(OrderShipped);
        //}

        //private static IList<Person> GetDemoData()
        //{
        //    var Customers = new List<Person>()
        //    {
        //        new Person()
        //        {
        //           ID = 100,
        //           Name="Sam Nasr",

        //           CurrentOrder = new Order()
        //           {
        //               OrderID = 103,
        //               ShippingAddress = "1234 Walnut Street, Cleveland, Ohio 44101",
        //           },

        //           OrdersShipped = new List<Order>()
        //            {
        //                new Order()
        //                {
        //                    OrderID = 101,
        //                    ShippingAddress = "2121 E.9th Street, Cleveland, Ohio 44103",
        //                },
        //                new Order()
        //                {
        //                    OrderID = 102,
        //                    ShippingAddress = "3221 W.6th Street, Cleveland, Ohio 44104",
        //                },
        //            },
        //        },


        //      new Person()
        //        {
        //           ID = 200,
        //           Name="James Williams",

        //           CurrentOrder = new Order()
        //           {
        //               OrderID = 203,
        //               ShippingAddress = "8901 Chestnut Street, Cleveland, Ohio 44101",
        //           },

        //           OrdersShipped = new List<Order>()
        //            {
        //                new Order()
        //                {
        //                    OrderID = 201,
        //                    ShippingAddress = "5477 E.49th Street, Cleveland, Ohio 44103",
        //                },
        //                new Order()
        //                {
        //                    OrderID = 202,
        //                    ShippingAddress = "7181 W.6th Street, Cleveland, Ohio 44104",
        //                },
        //            },
        //        }

        //    };
        //    return Customers;
        //}

    }
}