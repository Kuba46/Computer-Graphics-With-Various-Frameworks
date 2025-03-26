using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RotatingCylinder : RotatingShape
{
    public RotatingCylinder() : base(new CylinderGeometry(), "Rotating Cylinder", 0.6f, 0.5f, 0.4f) {}

    protected override void DrawShape(Graphics g, Pen pen, PointF[] projected)
    {
        int numVertices = projected.Length;
        int numSides = numVertices / 2;

        for (int i = 0; i < numSides; i++)
        {
            DrawLine(g, pen, projected[i], projected[(i + 1) % numSides]);
            DrawLine(g, pen, projected[i + numSides], projected[((i + 1) % numSides) + numSides]);
            DrawLine(g, pen, projected[i], projected[i + numSides]);
        }
    }
}
