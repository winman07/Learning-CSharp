using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateRectangleArea();
        }
        public static void CalculateRectangleArea()
        {
            double rectangleLength;
            double rectangleWidth;
            double totalArea;

            Console.WriteLine("What is the Lenght of your rectangle?");
            rectangleLength = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the width of your rectangle?");
            rectangleWidth = double.Parse(Console.ReadLine());

            totalArea = rectangleLength * rectangleWidth;
            Console.WriteLine("The area of your rectangle is " + totalArea);
        }
    }
}