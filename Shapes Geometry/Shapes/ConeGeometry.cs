using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ConeGeometry : IShapeGeometry
{
    public Point3D[] Vertices { get; private set; }

    public ConeGeometry(int segments = 30)
    {
        List<Point3D> vertices = new List<Point3D>();

        vertices.Add(new Point3D(0, 0, 2)); // Apex at (0, 0, 2)

        float radius = 1;
        float angleIncrement = 360f / segments;
        for (int i = 0; i < segments; i++)
        {
            float angle = i * angleIncrement * (float)Math.PI / 180;
            vertices.Add(new Point3D(radius * (float)Math.Cos(angle), radius * (float)Math.Sin(angle), 0));
        }
        Vertices = vertices.ToArray();
    }
}
