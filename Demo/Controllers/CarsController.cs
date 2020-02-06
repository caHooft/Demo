using System;
using System.Collections.Generic;
using System.Web;
using Demo.DataSource;
using Demo.Models;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class CarsController : ODataController
    {
        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(DemoCars.Instance.Cars.AsQueryable());
        }

        public IHttpActionResult Post(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Products.Add(product);
            //await db.SaveChangesAsync();


            //await DemoCars.Instance.Cars.SaveChangesAsync();
            
            DemoCars.Instance.Cars.Add(car);

            return Created(car);
        }
    }
}