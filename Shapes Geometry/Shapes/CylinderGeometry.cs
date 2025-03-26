using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CylinderGeometry : IShapeGeometry
{
    public Point3D[] Vertices { get; private set; }

    public CylinderGeometry(int segments = 30, float height = 2, float radius = 1)
    {
        List<Point3D> vertices = new List<Point3D>();

        float angleIncrement = 360f / segments;
        for (int i = 0; i < segments; i++)
        {
            float angle = i * angleIncrement * (float)Math.PI / 180;
            vertices.Add(new Point3D(radius * (float)Math.Cos(angle), radius * (float)Math.Sin(angle), height / 2));
            vertices.Add(new Point3D(radius * (float)Math.Cos(angle), radius * (float)Math.Sin(angle), -height / 2));
        }

        Vertices = vertices.ToArray();
    }
}