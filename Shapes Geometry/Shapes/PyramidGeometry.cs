using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PyramidGeometry : IShapeGeometry
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
}