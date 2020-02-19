﻿using System;
using System.Collections.Generic;
using System.Web;
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
        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(DemoCars.Instance.Cars.AsQueryable());
        }

        public IHttpActionResult Post(Car car)
        {

            DemoCars.Instance.Cars.Add(car);

            return Created(car);
        }

        public async Task<IHttpActionResult> Patch (int key, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != car.ID)
            {
                return BadRequest();
            }

            if (key == car.ID)
            {
                DemoCars.Instance.Cars.RemoveAt(key);
                
                car.TimeWhenAddedToDatabase = DateTime.Now;

                DemoCars.Instance.Cars.Insert(key, car);
            }

            return Updated(car);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DemoCars.Instance.Cars.RemoveAt(key);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}