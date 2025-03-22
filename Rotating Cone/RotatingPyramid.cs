using Geometry;
using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

public class RotatingPyramid : Form
{
    private System.Windows.Forms.Timer timer;
    private float angleX = 0;
    private float angleY = 0;
    private float angleZ = 0;
    private PyramidGeometry coneGeometry;

    public RotatingPyramid()
    {
        Text = "Rotating Cube";
        Size = new Size(800, 800);
        DoubleBuffered = true;
        Paint += new PaintEventHandler(OnPaint);
        timer = new System.Windows.Forms.Timer();
        timer.Interval = 1;
        timer.Tick += new EventHandler(OnTimerTick);
        timer.Start();
        coneGeometry = new PyramidGeometry();
    }

    private void OnTimerTick(object? sender, EventArgs e)
    {
        angleX += 0.9f;
        angleY += 0.6f;
        angleZ += 0.5f;
        Invalidate();
    }

    private void OnPaint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(Color.Black);

        PyramidGeometry.Point3D[] rotatedVertices = RotateVertices(coneGeometry.Vertices, angleX, angleY, angleZ);

        PointF[] projected = ProjectVertices(rotatedVertices, ClientSize.Width, ClientSize.Height, 256, 4);

        Pen pen = new Pen(Color.White);
        DrawPyramid(g, pen, projected);
    }

    private PyramidGeometry.Point3D[] RotateVertices(PyramidGeometry.Point3D[] vertices, float angleX, float angleY, float angleZ)
    {
        PyramidGeometry.Point3D[] rotatedVertices = new PyramidGeometry.Point3D[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            rotatedVertices[i] = RotateX(vertices[i], angleX);
            rotatedVertices[i] = RotateY(rotatedVertices[i], angleY);
            rotatedVertices[i] = RotateZ(rotatedVertices[i], angleZ);
        }
        return rotatedVertices;
    }

    private PyramidGeometry.Point3D RotateX(PyramidGeometry.Point3D point, float angle)
    {
        float rad = angle * (float)Math.PI / 180;
        float cos = (float)Math.Cos(rad);
        float sin = (float)Math.Sin(rad);
        float y = point.Y * cos - point.Z * sin;
        float z = point.Y * sin + point.Z * cos;
        return new PyramidGeometry.Point3D(point.X, y, z);
    }

    private PyramidGeometry.Point3D RotateY(PyramidGeometry.Point3D point, float angle)
    {
        float rad = angle * (float)Math.PI / 180;
        float cos = (float)Math.Cos(rad);
        float sin = (float)Math.Sin(rad);
        float x = point.X * cos + point.Z * sin;
        float z = -point.X * sin + point.Z * cos;
        return new PyramidGeometry.Point3D(x, point.Y, z);
    }

    private PyramidGeometry.Point3D RotateZ(PyramidGeometry.Point3D point, float angle)
    {
        float rad = angle * (float)Math.PI / 180;
        float cos = (float)Math.Cos(rad);
        float sin = (float)Math.Sin(rad);
        float x = point.X * cos - point.Y * sin;
        float y = point.X * sin + point.Y * cos;
        return new PyramidGeometry.Point3D(x, y, point.Z);
    }

    private PointF[] ProjectVertices(PyramidGeometry.Point3D[] vertices, int width, int height, float fov, float viewerDistance)
    {
        PointF[] points = new PointF[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            points[i] = Project(vertices[i], width, height, fov, viewerDistance);
        }
        return points;
    }

    private PointF Project(PyramidGeometry.Point3D point, int width, int height, float fov, float viewerDistance)
    {
        float factor = fov / (viewerDistance + point.Z);
        float x = point.X * factor + width / 2;
        float y = -point.Y * factor + height / 2;
        return new PointF(x, y);
    }

    private void DrawPyramid(Graphics g, Pen pen, PointF[] projected)
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

    private void DrawLine(Graphics g, Pen pen, PointF p1, PointF p2)
    {
        g.DrawLine(pen, p1, p2);
    }
}