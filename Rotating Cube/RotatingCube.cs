using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Geometry;

public class RotatingCube : Form
{
    private System.Windows.Forms.Timer timer;
    private float angleX = 0;
    private float angleY = 0;
    private CubeGeometry cubeGeometry;

    public RotatingCube()
    {
        this.Text = "Rotating Cube";
        this.Size = new Size(800, 800);
        this.DoubleBuffered = true;
        this.Paint += new PaintEventHandler(this.OnPaint);
        this.timer = new System.Windows.Forms.Timer();
        this.timer.Interval = 1;
        this.timer.Tick += new EventHandler(this.OnTimerTick);
        this.timer.Start();
        this.cubeGeometry = new CubeGeometry();
    }

    private void OnTimerTick(object? sender, EventArgs e)
    {
        this.angleX += 0.1f;
        this.angleY += 0.1f;
        this.Invalidate();
    }

    private void OnPaint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(Color.Black);

        CubeGeometry.Point3D[] rotatedVertices = RotateVertices(cubeGeometry.Vertices, angleX, angleY);

        PointF[] projected = ProjectVertices(rotatedVertices, this.ClientSize.Width, this.ClientSize.Height, 256, 4);

        Pen pen = new Pen(Color.White);
        DrawCube(g, pen, projected);
    }

    private CubeGeometry.Point3D[] RotateVertices(CubeGeometry.Point3D[] vertices, float angleX, float angleY)
    {
        CubeGeometry.Point3D[] rotated = new CubeGeometry.Point3D[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            rotated[i] = RotateX(vertices[i], angleX);
            rotated[i] = RotateY(rotated[i], angleY);
        }
        return rotated;
    }

    private CubeGeometry.Point3D RotateX(CubeGeometry.Point3D point, float angle)
    {
        float rad = angle * (float)Math.PI / 180;
        float cos = (float)Math.Cos(rad);
        float sin = (float)Math.Sin(rad);
        return new CubeGeometry.Point3D(
            point.X,
            cos * point.Y - sin * point.Z,
            sin * point.Y + cos * point.Z
        );
    }

    private CubeGeometry.Point3D RotateY(CubeGeometry.Point3D point, float angle)
    {
        float rad = angle * (float)Math.PI / 180;
        float cos = (float)Math.Cos(rad);
        float sin = (float)Math.Sin(rad);
        return new CubeGeometry.Point3D(
            cos * point.X + sin * point.Z,
            point.Y,
            -sin * point.X + cos * point.Z
        );
    }

    private PointF[] ProjectVertices(CubeGeometry.Point3D[] vertices, int width, int height, float fov, float viewerDistance)
    {
        PointF[] projected = new PointF[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            projected[i] = Project(vertices[i], width, height, fov, viewerDistance);
        }
        return projected;
    }

    private PointF Project(CubeGeometry.Point3D point, int width, int height, float fov, float viewerDistance)
    {
        float factor = fov / (viewerDistance - point.Z);
        float x = point.X * factor + width / 2;
        float y = point.Y * factor + height / 2;
        return new PointF(x, y);
    }

    private void DrawCube(Graphics g, Pen pen, PointF[] projected)
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

    private void DrawLine(Graphics g, Pen pen, PointF p1, PointF p2)
    {
        g.DrawLine(pen, p1, p2);
    }
}