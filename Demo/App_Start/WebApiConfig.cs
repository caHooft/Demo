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
        public static void Register(HttpConfiguration config)
        {
            var model = GetEdmModel();
            var pathHandler = new DefaultODataPathHandler();
            var routingConvention = ODataRoutingConventions.CreateDefaultWithAttributeRouting("OData", config);
            var batchHandler = new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer);

            config.MapODataServiceRoute("OData", "odata", model, batchHandler);

            config.Formatters.Clear();                             //Remove all other formatters
            config.Formatters.Add(new JsonMediaTypeFormatter());   //Enable JSON in the web service
            config.EnsureInitialized();
        }

        public static IEdmModel GetEdmModel ()
        {
            //ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var builder = new ODataModelBuilder { Namespace = typeof(Person).Namespace, ContainerName = "DefaultContainer" };

            ComplexTypeConfiguration<Range> rangeType = builder.ComplexType<Range>();
            //rangeType.Select();
            rangeType.Property(c => c.minValue);
            rangeType.Property(c => c.maxValue);

            var personConfig = builder.AddEntityType(typeof(Person));
            personConfig.HasKey(typeof(Person).GetProperty("ID"));
            personConfig.AddProperty(typeof(Person).GetProperty("Name"));
            personConfig.AddNavigationProperty(typeof(Person).GetProperty("Car"), EdmMultiplicity.ZeroOrOne);
            personConfig.AddComplexProperty(typeof(Person).GetProperty("minValue"));
            personConfig.AddComplexProperty(typeof(Person).GetProperty("maxValue"));
            personConfig.AddComplexProperty(typeof(Person).GetProperty("Ranges"));

            var carConfig = builder.AddEntityType(typeof(Car));
            carConfig.HasKey(typeof(Car).GetProperty("ID"));
            carConfig.AddProperty(typeof(Car).GetProperty("AmountMade"));
            carConfig.AddProperty(typeof(Car).GetProperty("APK"));
            carConfig.AddProperty(typeof(Car).GetProperty("Name"));
            carConfig.AddProperty(typeof(Car).GetProperty("TimeWhenAddedToDatabase"));
            carConfig.AddEnumProperty(typeof(Car).GetProperty("Brand"));
            carConfig.AddNavigationProperty(typeof(Car).GetProperty("People"), EdmMultiplicity.Many);

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

            builder.AddEntitySet("people", personConfig);  
            builder.AddEntitySet("cars", carConfig);

            var edmModel = builder.GetEdmModel();

            //return builder.GetEdmModel();
            return edmModel;
        }
    }
}

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