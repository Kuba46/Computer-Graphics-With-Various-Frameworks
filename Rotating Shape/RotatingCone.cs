using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RotatingCone : RotatingShape
{
    public RotatingCone() : base(new ConeGeometry(), "Rotating Cone", 0.7f, 0.5f, 0.4f) { }

    protected override void DrawShape(Graphics g, Pen pen, PointF[] projected)
    {
        int segments = projected.Length - 1;

        for (int i = 1; i <= segments; i++)
        {
            DrawLine(g, pen, projected[i], projected[(i % segments) + 1]);
        }

        for (int i = 1; i <= segments; i++)
        {
            DrawLine(g, pen, projected[0], projected[i]);
        }
    }
}
