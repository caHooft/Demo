using System;
using System.Collections.Generic;
using System.Web;
using Demo.DataSource;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;

namespace Demo.Controllers
{
    
    public class VechiclesController : ODataController
    {
        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(DemoDataSources.Instance.Vechicles.AsQueryable());
        }
    }
}