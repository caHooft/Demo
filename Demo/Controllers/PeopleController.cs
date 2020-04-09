using System;
using System.Collections.Generic;
using System.Web;
using Demo.DataSource;
using Demo.Models;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;

namespace Demo.Controllers
{
    [EnableQuery]
    //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
    public class PeopleController : ODataController
    {
        private static IList<Person> _People = null;

        public PeopleController()
        {
            if (_People == null)
            {
                _People = DemoDataSources.Instance.People.ToList();
            }
        }

        public IHttpActionResult Get()
        {
            return Ok(DemoDataSources.Instance.People.AsQueryable());
        }

    }
}