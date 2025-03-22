using System;
using System.Drawing;
using System.Windows.Forms;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        Application.Run(new RotatingPyramid());
    }
}