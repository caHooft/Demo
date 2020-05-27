using Demo.Models;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Demo.Controllers
{
    public class RangeController : ODataController
    {
        private static IList<Range> _Range = null;

        public RangeController()
        {
            if (_Range == null)
            {
                //_Range = Demo.DataSource.DemoDataSources.Instance.Ranges.ToList();
                //_RangeS = Demo.DataSource.DemoDataSources.Instance.
            }
        }

        //public IHttpActionResult Get(int key)
        //{
        //    return Ok(_Range.AsQueryable().First(p => p.minValue == key));
        //}

        //public IHttpActionResult Get()
        //{
        //    return Ok(_Range.AsQueryable());
        //}
    }
}