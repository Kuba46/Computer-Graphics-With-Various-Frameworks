using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IcosahedronGeometry : IShapeGeometry
{
    public Point3D[] Vertices { get; private set; }

    public IcosahedronGeometry()
    {
        float t = (1 + (float)Math.Sqrt(5)) / 2;
        Vertices = new Point3D[]
        {
            new Point3D(-1,  t, 0),
            new Point3D( 1,  t, 0),
            new Point3D(-1, -t, 0),
            new Point3D( 1, -t, 0),
            new Point3D( 0, -1,  t),
            new Point3D( 0,  1,  t),
            new Point3D( 0, -1, -t),
            new Point3D( 0,  1, -t),
            new Point3D( t, 0, -1),
            new Point3D( t, 0,  1),
            new Point3D(-t, 0, -1),
            new Point3D(-t, 0,  1)
        };
    }
}
