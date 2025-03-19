using System;
using System.Drawing;
using System.Windows.Forms;

using Geometry;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        Application.Run(new RotatingCube());
    }
}