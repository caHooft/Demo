using System;
using System.Collections.Generic;
using System.Web;
using Demo.DataSource;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;

namespace Demo.Controllers
{
    [EnableQuery]
    public class PeopleController : ODataController
    {
        public IHttpActionResult Get()
        {
            return Ok(DemoDataSources.Instance.People.AsQueryable());
        }
    }
}