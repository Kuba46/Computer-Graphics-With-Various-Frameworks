using System;
using System.Drawing;
using System.Windows.Forms;

namespace Geometry;

public class PyramidGeometry
{
    public Point3D[] Vertices { get; private set; }

    public PyramidGeometry()
    {
        Vertices = new Point3D[]
        {
            new Point3D(0, 0, 0),
            new Point3D(2, 0, 0),
            new Point3D(2, 2, 0),
            new Point3D(0, 2, 0),
            new Point3D(1, 1, 4) // Apex vertex
        };
    }

    public struct Point3D
    {
        public float X;
        public float Y;
        public float Z;

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}