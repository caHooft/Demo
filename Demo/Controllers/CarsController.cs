using System;
using Demo.DataSource;
using Demo.Models;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using System.Threading.Tasks;
using System.Net;

namespace Demo.Controllers
{
    public class CarsController : ODataController
    {
        public static object RouteData { get; internal set; }


        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(DemoDataSources.Instance.Cars.AsQueryable());
        }

        public IHttpActionResult Post(Car car)
        {
            DemoDataSources.Instance.Cars.Add(car);

            var header = HttpRequestHeader.Accept;
            
            return Created(car);

            //return Updated(car);

            //return HttpRequestHeader.Accept;

            //return StatusCode(HttpStatusCode.Created);
        }

        public async Task<IHttpActionResult> Patch (int key, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != car.ID)
            {
                car.TimeWhenAddedToDatabase = DateTime.Now;

                DemoDataSources.Instance.Cars.Insert(key, car);

                return BadRequest();
            }

            if (key == car.ID)
            {

                DemoDataSources.Instance.Cars.RemoveAll(r => r.ID == key);

                car.TimeWhenAddedToDatabase = DateTime.Now;

                DemoDataSources.Instance.Cars.Insert(key, car);
            }

            return Updated(car);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DemoDataSources.Instance.Cars.RemoveAll(r => r.ID == key);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}