using Demo.Models;
using Microsoft.OData.Edm;
using System.Web.Http;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace Demo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();
        }
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "Demos";
            builder.ContainerName = "DefaultContainer";
            var people = builder.EntitySet<Person>("People");
            var trips = builder.EntitySet<Trip>("Trips");
            var cars = builder.EntitySet<Car>("Cars");
            people.EntityType.Count().Filter().OrderBy().Expand().Select();
            trips.EntityType.Count().Filter().OrderBy().Expand().Select();
            cars.EntityType.Count().Filter().OrderBy().Expand().Select();
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}