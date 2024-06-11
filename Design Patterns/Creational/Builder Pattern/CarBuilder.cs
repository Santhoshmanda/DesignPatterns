using System;
using System.Runtime.ConstrainedExecution;

namespace Design_Patterns.Creational.BuilderPattern
{

    // if there are many paramters and some will be optional then
    // you need to have  ctor with all the params or so many ctor overlaoding has to be done
    // if method signarture matches we can't do setting of params
    //diff betwen builder and decator.decorator can do dynamic construction

    //DbContextOptionsBuilder
    //HttpClientBuilder

    public class Car
	{
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public Car(CarBuilder builder)
        {
            this.Make=builder.Make;
            this.Model = builder.Model;
            this.Year = builder.Year;
            this.Color = builder.Color;
        }


    }
    public   class CarBuilder
	{
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }


        public CarBuilder WithMake(string make)
        {
            this.Make = make;
            return this;
        }

        public CarBuilder WithModel(string model)
        {
            this.Model=model;
            return this;
        }

        public CarBuilder WithYear(int Year)
        {
            this.Year = Year;
            return this;
        }

        public CarBuilder WithColor(string color)
        {
            this.Color = color;
            return this;

        }

        public Car Build()
        {
            return new Car(this);
        }

    }

  //  Car car = new CarBuilder().WithColor("red").WithMake("Hyundai").Build();


}

