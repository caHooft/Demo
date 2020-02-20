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
        static IEdmModel GetEdmModel()
        { 
            var builder = new ODataModelBuilder();

            //EntitySetConfiguration<Car> cars = builder.EntitySet<Car>("cars");
            //EntityTypeConfiguration<Car> Car = cars.EntityType;
            //Car.EnumProperty<_Brands>(c => c.Brand).Name = "Brand";

            builder.Namespace = "Demos";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Car>("Cars");

            //declare de ENUM en geef de opties (members)
            var _Brands = builder.EnumType<_Brands>();
            _Brands.Member(Models._Brands.Audi);
            _Brands.Member(Models._Brands.BMW);
            _Brands.Member(Models._Brands.Ferrari);
            _Brands.Member(Models._Brands.Ford);
            _Brands.Member(Models._Brands.Honda);
            _Brands.Member(Models._Brands.Mercedes);
            _Brands.Member(Models._Brands.Mini);
            _Brands.Member(Models._Brands.Nissan);
            _Brands.Member(Models._Brands.Porsche);
            _Brands.Member(Models._Brands.Tesla);
            _Brands.Member(Models._Brands.Toyota);
            _Brands.Member(Models._Brands.Volkswagen);

            //deze werkt zonder dat je elk type hoeft te declaren maar dan moet je dit in de gegenereerde code doen
            //builder.EnumType<_Brands>();

            var cars = builder.EntityType<Car>();

            cars.HasKey(c => c.ID);
            cars.Property(c => c.AmountMade);
            cars.Property(c => c.APK);
            cars.Property(c => c.Colour);
            cars.Property(c => c.TimeWhenAddedToDatabase);
            cars.EnumProperty(c => c.Brand);

            //builder.ComplexType<JobParameter>();
            //builder.ComplexType<JobStatusResult>();
            //builder.EnumType<JobStatus>();
            //builder.EnumType<JobParameterType>();

            //cars.EnumProperty(c => c.Brand);

            //cars.EnumProperty<_Brands>(c => c.Brand).Name = "Brand";
            //cars.EnumProperty(c => c.Brand);

            //cars.EnumProperty<_Brands>(c => c.Brand);

            //cars.Property<_Brands>(c => c.Brand);

            //EdmEnumType color = new EdmEnumType("NS", "Color");
            //color.AddMember(new EdmEnumMember(color, "Red", EdmValue (0)));
            //model.AddElement(color);

            //var people = builder.EntitySet<Person>("People");
            //var trips = builder.EntitySet<Trip>("Trips");
            //

            //people.EntityType.Count().Filter().OrderBy().Expand().Select();
            //trips.EntityType.Count().Filter().OrderBy().Expand().Select();
            cars.Count().Filter().OrderBy().Expand().Select();

            //var edmModel = builder.GetEdmModel();

            return builder.GetEdmModel();
        }
    }
}