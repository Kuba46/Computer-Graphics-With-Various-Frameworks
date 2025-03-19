using System;
using System.Drawing;
using System.Windows.Forms;

namespace Geometry;

public class CubeGeometry
{
    public Point3D[] Vertices { get; private set; }

    public CubeGeometry()
    {
        Vertices = new Point3D[]
        {
                new Point3D(-1, -1, -1),
                new Point3D( 1, -1, -1),
                new Point3D( 1,  1, -1),
                new Point3D(-1,  1, -1),
                new Point3D(-1, -1,  1),
                new Point3D( 1, -1,  1),
                new Point3D( 1,  1,  1),
                new Point3D(-1,  1,  1)
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