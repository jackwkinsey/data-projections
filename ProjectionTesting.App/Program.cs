using ProjectionTesting.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectionTesting.Data;

namespace ProjectionTesting.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var entityMap = new Dictionary<string, string>()
            {
                {"x", "year"},
                {"y", "cylinders"},
                {"radius", "hp"},
                {"color", "make"}
            };

            var p = Projection.Map<object, Point>(new
            {
                Make = "Ford",
                Model = "Escort",
                Year = 1988,
                Cylinders = 4,
                HP = 200
            }, entityMap);

            Console.WriteLine($"SINGLE POINT:\n\tPOS: {p.X}, {p.Y}\n\tRADIUS: {p.Radius}\n\tCOLOR: {p.Color}\n\n");

            var plot = new ScatterPlot();
            var cars = new[]
            {
               new
               {
                   make = "Ford",
                   model = "Escort",
                   year = 1989,
                   cylinders = 4,
                   hp = 200
               },
               new
               {
                   make = "Ford",
                   model = "Fiesta",
                   year = 2005,
                   cylinders = 6,
                   hp = 300
               },
               new
               {
                   make = "Chevy",
                   model = "Malibu",
                   year = 2018,
                   cylinders = 6,
                   hp = 350
               },
               new
               {
                   make = "Chevy",
                   model = "Impala",
                   year = 2011,
                   cylinders = 6,
                   hp = 350
               },
               new
               {
                   make = "Tesla",
                   model = "Model 3",
                   year = 2018,
                   cylinders = 8,
                   hp = 450
               },
               new
               {
                   make = "Volkswagen",
                   model = "Beetle",
                   year = 1969,
                   cylinders = 4,
                   hp = 200
               }
            };

            plot.Points = Projection.MapList<object, Point>(cars, entityMap);
            var plotPoints = plot.Points as Point[] ?? plot.Points.ToArray();

            foreach (var point in plotPoints)
            {
                Console.WriteLine(
                    $"SINGLE POINT:\n\tPOS: {point.X}, {point.Y}\n\tRADIUS: {point.Radius}\n\tCOLOR: {point.Color}");
            }
        }
    }
}