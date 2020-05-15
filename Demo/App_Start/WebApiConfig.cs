using Demo.Models;
using System;
using Microsoft.OData.Edm;
using System.Web.Http;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using System.Net.Http.Formatting;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Routing.Conventions;

namespace Demo
{
    public static class WebApiConfig
    {
        //public static void Register(HttpConfiguration config)
        //{
        //    DataSource.DemoDataSources.Instance.Initialize();
        //    config.MapODataServiceRoute("odata", "odata", GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
        //    config.EnsureInitialized();
        //}

        public static void Register(HttpConfiguration config)
        {
            //DataSource.DemoDataSources.Instance.Initialize();

            //config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            var bh = new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer);
            //config.MapODataServiceRoute("OData", "odata", GetEdmModel());

           config.MapODataServiceRoute("OData", "odata", GetEdmModel(), new DefaultODataPathHandler(),
           ODataRoutingConventions.CreateDefaultWithAttributeRouting("OData", config), bh);

            //config.Formatters.Clear();                             //Remove all other formatters
            //config.Formatters.Add(new JsonMediaTypeFormatter());   //Enable JSON in the web service
        }

        public static IEdmModel GetEdmModel ()
        {
            //ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var builder = new ODataModelBuilder();
            //var OrderType = builder.EntityType<Order>();
            //builder.Function("GetName")
            //    .Returns<string>()
            //    .Parameter<int>("key");
            //builder.EntitySet<Person>("People");
            //builder.EntitySet<Car>("Cars");
            builder.Namespace = typeof(Person).Namespace;

            builder.ContainerName = "DefaultContainer";

            //Singleton stuff

            //var builder = new ODataModelBuilder();
            //builder.Singleton<Company>("Companies");
            //builder.Namespace = typeof(Company).Namespace;
            //builder.Namespace = typeof(Person).Namespace;

            //EntityTypeConfiguration Companies = builder.AddEntityType(typeof(Company));
            //EntitySetConfiguration<Company> employeesConfiguration = builder.EntitySet<Company>("Companies");
            //employeesConfiguration.HasSingletonBinding(c => c.Owners, "Owners");
            //employeesConfiguration.HasSingletonBinding(c => c.OwnedCars, "Cars");

            //Companies.HasKey(typeof(Company).GetProperty("ID"));
            //EntityTypeConfiguration companyConfig = builder.AddSingleton<Company>("Umbrella");
            //EntityTypeConfiguration companyConfig = builder.AddEntityType(typeof(Company));
            //companyConfig.HasKey(typeof(Company).GetProperty("ID"));
            //companyConfig.HasKey(typeof(Company).GetProperty("Name"));

            EntityTypeConfiguration personConfig = builder.AddEntityType(typeof(Person));
            personConfig.HasKey(typeof(Person).GetProperty("ID"));
            personConfig.AddProperty(typeof(Person).GetProperty("Name"));
            personConfig.AddNavigationProperty(typeof(Person).GetProperty("Car"), EdmMultiplicity.One);
            //personConfig.AddProperty(typeof(Person).GetProperty("OwnedCar"));
            //personConfig.AddNavigationProperty(typeof(Person).GetProperty("OwnedCars"), EdmMultiplicity.One);
            //employeesConfiguration.HasSingletonBinding(c => c.Company, "Umbrella");

            EntityTypeConfiguration carConfig = builder.AddEntityType(typeof(Car));

            carConfig.HasKey(typeof(Car).GetProperty("ID"));
            carConfig.AddProperty(typeof(Car).GetProperty("AmountMade"));
            carConfig.AddProperty(typeof(Car).GetProperty("APK"));
            carConfig.AddProperty(typeof(Car).GetProperty("Name"));
            carConfig.AddProperty(typeof(Car).GetProperty("TimeWhenAddedToDatabase"));
            carConfig.AddEnumProperty(typeof(Car).GetProperty("Brand"));
            //carConfig.AddCollectionProperty(typeof(Car).GetProperty("People"));
            var np = carConfig.AddNavigationProperty(typeof(Car).GetProperty("People"),EdmMultiplicity.Many);
            //np.
            
            //Doesnt get through build: The property 'Name' does not belong to the type 'Demo.Models.Car'.
            //carConfig.AddProperty(typeof(Person).GetProperty("Name"));

            //Builds but than crashes
            //carConfig.AddComplexProperty(typeof(Car).GetProperty("People"));

            //doesnt even build
            //carConfig.AddProperty(typeof(Car).GetProperty("People"));

            //new declaration of variabels of the enum
            var _Brands = builder.AddEnumType(typeof(_Brands));
            _Brands.AddMember(Models._Brands.Audi);
            _Brands.AddMember(Models._Brands.BMW);
            _Brands.AddMember(Models._Brands.Ferrari);
            _Brands.AddMember(Models._Brands.Ford);
            _Brands.AddMember(Models._Brands.Honda);
            _Brands.AddMember(Models._Brands.Mercedes);
            _Brands.AddMember(Models._Brands.Mini);
            _Brands.AddMember(Models._Brands.Nissan);
            _Brands.AddMember(Models._Brands.Porsche);
            _Brands.AddMember(Models._Brands.Tesla);
            _Brands.AddMember(Models._Brands.Toyota);
            _Brands.AddMember(Models._Brands.Volkswagen);

            //EntitySetConfiguration Companies = builder.AddEntitySet("companies", companyConfig);

            EntitySetConfiguration People = builder.AddEntitySet("people", personConfig);            

            EntitySetConfiguration Cars = builder.AddEntitySet("cars", carConfig);

            var edmModel = builder.GetEdmModel();

            //return builder.GetEdmModel();
            return edmModel;
        }
    }
}