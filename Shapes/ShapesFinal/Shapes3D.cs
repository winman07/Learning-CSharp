using System;
using System.Formats.Asn1;

namespace Shapes3D
{
    public abstract class Shape //main class set to eager-load surface area and volume
    {
        public abstract double SurfaceArea {get;}
        public abstract double Volume {get;}
    }

    public class Cuboid : Shape
    {
        public double Width {get;}
        public double Height {get;}
        public double Depth {get;}
        private double surfaceArea;
        private double volume;

        public Cuboid(double width, double height, double depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
            CalculateSurfaceArea();
            CalculateVolume();
        }

        private void CalculateSurfaceArea()
        {
            surfaceArea = 2 * (Width * Height + Height * Depth + Depth * Width);
        }

        private void CalculateVolume()
        {
            volume = Width * Height * Depth;
        }

        public override double SurfaceArea => surfaceArea;
        public override double Volume => volume;
    }

    public class Cube : Cuboid //derives from Cuboid class
    {
        public Cube (double sideLength) : base(sideLength, sideLength, sideLength) { }
    }

    public class Cylinder : Shape
    {
        public double Radius {get;}
        public double Height {get;}
        private double surfaceArea;
        private double volume;

        public Cylinder(double radius, double height)
        {
            Radius = radius;
            Height = height;
            CalculateSurfaceArea();
            CalculateVolume();
        }

        private void CalculateSurfaceArea()
        {
            surfaceArea = 2 * Math.PI * Radius * (Radius + Height);
        }

        private void CalculateVolume()
        {
            volume = Math.PI * (Radius * Radius) * Height;
        }

        public override double SurfaceArea => surfaceArea;
        public override double Volume => volume;
    }

    public class Sphere : Shape
    {
        public double Radius {get;}
        private double surfaceArea;
        private double volume;

        public Sphere(double radius)
        {
            Radius = radius;
            CalculateSurfaceArea();
            CalculateVolume();
        }

        private void CalculateSurfaceArea()
        {
            surfaceArea = 4 * Math.PI * (Radius * Radius);
        }

        private void CalculateVolume()
        {
            volume = (4.0 / 3.0) * Math.PI * (Radius * Radius * Radius);
        }

        public override double SurfaceArea => surfaceArea;
        public override double Volume => volume;
    }

    public class Prism : Shape
    {
        public double SideLength {get;}
        public int Faces {get;}
        public double Height {get;}
        private double surfaceArea;
        private double volume;

        public Prism(double sideLength, int faces, double height)
        {
            SideLength = sideLength;
            Faces = faces;
            Height = height;
            CalculateSurfaceArea();
            CalculateVolume();
        }

        private void CalculateSurfaceArea()
        {
            //base area and lateral surface area calculated first to get total surface area
            double baseArea = Faces * (SideLength * SideLength) / (4 * Math.Tan(Math.PI / Faces));
            double lateralSurfaceArea = Faces * SideLength * Height;
            surfaceArea = 2 * baseArea + lateralSurfaceArea;
        }

        private void CalculateVolume()
        {
            double baseArea = Faces * (SideLength * SideLength) / (4 * Math.Tan(Math.PI / Faces));
            volume = baseArea * Height;
        }

        public override double SurfaceArea => surfaceArea;
        public override double Volume => volume;
    }
}