using Demo.Models;
using System;
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

        public static IEdmModel GetEdmModel ()
        {
            //use convention version to run without adding problems
            //var builder = new ODataConventionModelBuilder();
            var builder = new ODataModelBuilder();
            var entity = new EntityTypeConfiguration();

            //EntitySetConfiguration<Car> cars = builder.EntitySet<Car>("cars");
            //EntityTypeConfiguration<Car> Car = cars.EntityType;
            //Car.EnumProperty<_Brands>(c => c.Brand).Name = "Brand";

            builder.Namespace = "Demos";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Car>("Cars");


            //deze werkt zonder dat je elk type hoeft te declaren maar dan moet je dit in de gegenereerde code doen (client side)
            //builder.EnumType<_Brands>();

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

            //visual studio gaf aan dat dit beter zou moeten wezen dan AddEntityType echter werkt het niet echter mischien handig even te onderzoeken
            //EdmEntityType ;

            //getting closer to something that doesnt error
            //var a = builder.AddEntityType(T);
            //var a = builder.AddEntityType(Type T);

            //tried to convert it into a method gave reallt wierd errors
            //public virtual Microsoft.AspNet.OData.Builder.EntityTypeConfiguration AddEntityType(Type type);

            //Type T;

            //var a = builder.AddEntityType(T);

            //doesnt work because its a type that cant be set to a type...
            //Type a = EntityTypeConfiguration;

            //doesnt work while it give it the exact parameter it wants
            //EntityTypeConfiguration<TEntituType>;

            //i cant put a type in type configurator?..
            //var a = EntityTypeConfiguration<Type.EmptyTypes>;

            //if i give it a diffrent variabel it still says its a type...
            //var a = Microsoft.AspNet.OData.Builder.EntityTypeConfiguration<int a>;

            //var a = 

            //var a = entity.AddProperty(Car);
            //var a = entity;

            //a.ModelBuilder.AddEntityType(Person);

            //somehow even when litterally saying add entity type it doesnt wanna take a type
            //var a = entity.ModelBuilder.AddEntityType<Car>;

            //cannot assign method group to an emplicity-typed variabel
            //var a = entity.ModelBuilder.EntityType<Car>;

            //werkt niet
            //entity.BaseType{get;}

            //tried out if add entity existed in ODataModelBuilder class and it does
            //sadly it doesnt take a type which is exactly what i need
            //builder.AddEntityType(Person);



            var cars = builder.EntityType<Car>();

            cars.HasKey(c => c.ID);
            cars.Property(c => c.AmountMade);
            cars.Property(c => c.APK);
            cars.Property(c => c.Colour);
            cars.Property(c => c.TimeWhenAddedToDatabase);
            cars.EnumProperty(c => c.Brand);

            cars.Count().Filter().OrderBy().Expand().Select();

            //people.EntityType.Count().Filter().OrderBy().Expand().Select();
            //trips.EntityType.Count().Filter().OrderBy().Expand().Select();
            //cars.Count().Filter().OrderBy().Expand().Select();

            var edmModel = builder.GetEdmModel();

            //return builder.GetEdmModel();
            return edmModel;
        }
    }
}