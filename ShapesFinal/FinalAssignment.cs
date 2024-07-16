using System;
using Shapes3D;

namespace Solver
{
    static class Solver
    {
        public static void Main(String[] args)
        {
            string filepath = args[0];
            double total = 0;
            List <Shape3D> wadeList = new List<Shape3D> <Shape3D>();

            foreach (string line in System.IO.File.ReadLines(filepath))
            {
                string[] lineData = line.Split(',');
                
            }
        }
    }
}