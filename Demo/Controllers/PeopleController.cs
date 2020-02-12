using System;
using System.Collections.Generic;
using System.Web;
using Demo.DataSource;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;

namespace Demo.Controllers
{
    [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
    public class PeopleController : ODataController
    {
        public IHttpActionResult Get()
        {
            return Ok(DemoDataSources.Instance.People.AsQueryable());
        }

    }
}