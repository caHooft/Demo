using System;
using System.Collections.Generic;
using System.Web;
using Demo.DataSource;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;

namespace Demo.Controllers
{
    
    public class TripsController : ODataController
    {
        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(DemoDataSources.Instance.Trips.AsQueryable());
        }
    }
}