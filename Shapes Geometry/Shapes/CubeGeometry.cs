using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CubeGeometry : IShapeGeometry
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
}