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
            ODataModelBuilder builder = new ODataModelBuilder();

            builder.Namespace = "Demos";
            builder.ContainerName = "DefaultContainer";

            var cars = builder.EntityType<Car>();
            cars.HasKey(c => c.ID);
            cars.Property(c => c.AmountMade);
            cars.Property(c => c.APK);
            cars.Property(c => c.Colour);
            cars.Property(c => c.TimeWhenAddedToDatabase);

            //cars.EnumProperty<_Brands>(c => c.Brand);
            //cars.Property<_Brands>(c => c.Brand);
                       

            //var people = builder.EntitySet<Person>("People");
            //var trips = builder.EntitySet<Trip>("Trips");
            builder.EntitySet<Car>("Cars");

            //people.EntityType.Count().Filter().OrderBy().Expand().Select();
            //trips.EntityType.Count().Filter().OrderBy().Expand().Select();
            cars.Count().Filter().OrderBy().Expand().Select();

            //var edmModel = builder.GetEdmModel();

            return builder.GetEdmModel();
        }
    }
}