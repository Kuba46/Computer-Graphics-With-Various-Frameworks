using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RotatingCube : RotatingShape
{
    public RotatingCube() : base(new CubeGeometry(), "Rotating Cube", 4.1f, 1.1f, 0.6f) { }

    protected override void DrawShape(Graphics g, Pen pen, PointF[] projected)
    {
        DrawLine(g, pen, projected[0], projected[1]);
        DrawLine(g, pen, projected[1], projected[2]);
        DrawLine(g, pen, projected[2], projected[3]);
        DrawLine(g, pen, projected[3], projected[0]);
        DrawLine(g, pen, projected[4], projected[5]);
        DrawLine(g, pen, projected[5], projected[6]);
        DrawLine(g, pen, projected[6], projected[7]);
        DrawLine(g, pen, projected[7], projected[4]);
        DrawLine(g, pen, projected[0], projected[4]);
        DrawLine(g, pen, projected[1], projected[5]);
        DrawLine(g, pen, projected[2], projected[6]);
        DrawLine(g, pen, projected[3], projected[7]);
    }
}