using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public abstract class RotatingShape : Form, IRotate
{
    protected System.Windows.Forms.Timer timer;
    protected float angleX = 0;
    protected float angleY = 0;
    protected float angleZ = 0;
    protected IShapeGeometry shapeGeometry;

    protected float angleXIncrement;
    protected float angleYIncrement;
    protected float angleZIncrement;

    public RotatingShape(IShapeGeometry geometry, string title, float angleXIncrement, float angleYIncrement, float angleZIncrement)
    {
        Text = title;
        Size = new Size(800, 800);
        DoubleBuffered = true;
        Paint += new PaintEventHandler(OnPaint);
        timer = new System.Windows.Forms.Timer();
        timer.Interval = 1;
        timer.Tick += new EventHandler(OnTimerTick);
        timer.Start();
        shapeGeometry = geometry;

        this.angleXIncrement = angleXIncrement;
        this.angleYIncrement = angleYIncrement;
        this.angleZIncrement = angleZIncrement;
    }

    private void OnTimerTick(object? sender, EventArgs e)
    {
        angleX += angleXIncrement;
        angleY += angleYIncrement;
        angleZ += angleZIncrement;
        Invalidate();
    }

    private void OnPaint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(Color.Black);

        Point3D[] rotatedVertices = RotateVertices(shapeGeometry.Vertices, angleX, angleY, angleZ);

        PointF[] projected = ProjectVertices(rotatedVertices, ClientSize.Width, ClientSize.Height, 256, 4);

        Pen pen = new Pen(Color.White);
        DrawShape(g, pen, projected);
    }

    public Point3D[] RotateVertices(Point3D[] vertices, float angleX, float angleY, float angleZ)
    {
        Point3D[] rotatedVertices = new Point3D[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            rotatedVertices[i] = RotateX(vertices[i], angleX);
            rotatedVertices[i] = RotateY(rotatedVertices[i], angleY);
            rotatedVertices[i] = RotateZ(rotatedVertices[i], angleZ);
        }
        return rotatedVertices;
    }

    private Point3D RotateX(Point3D point, float angle)
    {
        float rad = angle * (float)Math.PI / 180;
        float cos = (float)Math.Cos(rad);
        float sin = (float)Math.Sin(rad);
        float y = point.Y * cos - point.Z * sin;
        float z = point.Y * sin + point.Z * cos;
        return new Point3D(point.X, y, z);
    }

    private Point3D RotateY(Point3D point, float angle)
    {
        float rad = angle * (float)Math.PI / 180;
        float cos = (float)Math.Cos(rad);
        float sin = (float)Math.Sin(rad);
        float x = point.X * cos + point.Z * sin;
        float z = -point.X * sin + point.Z * cos;
        return new Point3D(x, point.Y, z);
    }

    private Point3D RotateZ(Point3D point, float angle)
    {
        float rad = angle * (float)Math.PI / 180;
        float cos = (float)Math.Cos(rad);
        float sin = (float)Math.Sin(rad);
        float x = point.X * cos - point.Y * sin;
        float y = point.X * sin + point.Y * cos;
        return new Point3D(x, y, point.Z);
    }

    private PointF[] ProjectVertices(Point3D[] vertices, int width, int height, float fov, float viewerDistance)
    {
        PointF[] points = new PointF[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            points[i] = Project(vertices[i], width, height, fov, viewerDistance);
        }
        return points;
    }

    private PointF Project(Point3D point, int width, int height, float fov, float viewerDistance)
    {
        float factor = fov / (viewerDistance + point.Z);
        float x = point.X * factor + width / 2;
        float y = -point.Y * factor + height / 2;
        return new PointF(x, y);
    }

    protected abstract void DrawShape(Graphics g, Pen pen, PointF[] projected);

    public void DrawLine(Graphics g, Pen pen, PointF p1, PointF p2)
    {
        g.DrawLine(pen, p1, p2);
    }
}
