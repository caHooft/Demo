using System;
using Demo.DataSource;
using Demo.Models;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

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

        public HttpResponseMessage Post(Car car)
        {
            //Add a car to the database.
            DemoDataSources.Instance.Cars.Add(car);

            //Set the responce into the varabel responce. I do this so i can easily debug when something is wrong.
            HttpResponseMessage response = Request.CreateResponse<Car>(HttpStatusCode.Created, car);

            //This is the link to the created item. It shield give a direct route towards the created item.
            string uriToTheCreatedItem = Url.Route(null, new { id = car.ID });

            //Makes a new URI from the uri of the newly create item.
            response.Headers.Location = new Uri(Request.RequestUri, uriToTheCreatedItem);

            return response;
        }

        public async Task<IHttpActionResult> Patch (int key, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //If there is no car that has a matching car.ID with the ID given by the client side than stop. Also send a bad request so i can debug if needed.
            if (key != car.ID)
            {

                return BadRequest();
            }
            
            //If there is a car that has a matching Car.ID with the given key by the client side. Delete the car that is currently in this position than create a new car with the specs given from the client side.
            if (key == car.ID)
            {
                //Remove old entry from the database based on ID.
                DemoDataSources.Instance.Cars.RemoveAll(r => r.ID == key);

                //Insert new entry into database based on ID.
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
            //Removes a entry from the database based on ID. I made it remove all in case double ID entries exist.
            DemoDataSources.Instance.Cars.RemoveAll(r => r.ID == key);
            //Return a no content HttpStatusCode. My choice went to No content because there now is no content at this point in  the database.
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}