using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RotatingPyramid : RotatingShape
{
    public RotatingPyramid() : base(new PyramidGeometry(), "Rotating Pyramid", 5.9f, 0.6f, 0.5f) { }

    protected override void DrawShape(Graphics g, Pen pen, PointF[] projected)
    {
        DrawLine(g, pen, projected[0], projected[1]);
        DrawLine(g, pen, projected[1], projected[2]);
        DrawLine(g, pen, projected[2], projected[3]);
        DrawLine(g, pen, projected[3], projected[0]);

        DrawLine(g, pen, projected[0], projected[4]);
        DrawLine(g, pen, projected[1], projected[4]);
        DrawLine(g, pen, projected[2], projected[4]);
        DrawLine(g, pen, projected[3], projected[4]);
    }
}