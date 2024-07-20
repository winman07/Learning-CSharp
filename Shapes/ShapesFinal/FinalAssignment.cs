using System;
using Shapes3D;

namespace FinalAssignment
{
    static class Solver
    {
        public static void Main(String[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: Solver <input_file>");
                return;
            }
            string filepath = args[0];
            
            if (!System.IO.File.Exists(filepath))
            {
                Console.WriteLine("Error: File not found.");
                return;
            }
            double total = 0;
            List<Shape> shapesList = new List<Shape>();
            
            //Read through the provided input line by line
            foreach (string line in System.IO.File.ReadLines(filepath))
            {
                string[] lineData = line.Split(',');
                
                //No calculation until data is provided
                if (lineData.Length == 0)
                    continue;

                string shapeType = lineData[0].ToLower();

                //switch to get necessary data, including enough lines for each piece of data that the shape specifies
                //includes methods for volume and area to be called
                switch (shapeType)
                {
                    case "cube":
                    shapesList.Add(new Cube(double.Parse(lineData[1])));
                    break;

                    case "cuboid":
                    shapesList.Add(new Cuboid(double.Parse(lineData[1]), double.Parse(lineData[2]), double.Parse(lineData[3])));
                    break;

                    case "cylinder":
                    shapesList.Add(new Cylinder(double.Parse(lineData[1]), double.Parse(lineData[2])));
                    break;

                    case "sphere":
                    shapesList.Add(new Sphere(double.Parse(lineData[1])));
                    break;

                    case "prism":
                    shapesList.Add(new Prism(double.Parse(lineData[1]), int.Parse(lineData[2]), double.Parse(lineData[3])));
                    break;

                    case "area":
                    total += CalculateTotal(shapesList, shape => shape.SurfaceArea, int.Parse(lineData[1]));
                    shapesList.Clear();
                    break;

                    case "volume":
                    total += CalculateTotal(shapesList, shape => shape.Volume, int.Parse(lineData[1]));
                    shapesList.Clear();
                    break;
                }
            }
            //Print results to console
            Console.WriteLine($"The sum of measurements is {total:F2}");
        }

        //function to calculate data
        private static double CalculateTotal(List<Shape> shapes, Func<Shape, double> measurementFunc, int scale)
        {
            double totalMeasurement = 0;
            foreach (var shape in shapes)
            {
                totalMeasurement += measurementFunc(shape);
            }
            return totalMeasurement * scale;
        }
    }
}