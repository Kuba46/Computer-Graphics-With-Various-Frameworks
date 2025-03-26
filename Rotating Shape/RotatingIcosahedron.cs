using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RotatingIcosahedron : RotatingShape
{
    public RotatingIcosahedron() : base(new IcosahedronGeometry(), "Rotating Icosahedron", 0.5f, 2.4f, 1.2f) { }

    protected override void DrawShape(Graphics g, Pen pen, PointF[] projected)
    {
        // Define the 20 triangular faces of the icosahedron
        int[][] faces = new int[][]
        {
            new int[] {0, 11, 5},
            new int[] {0, 5, 1},
            new int[] {0, 1, 7},
            new int[] {0, 7, 10},
            new int[] {0, 10, 11},
            new int[] {1, 5, 9},
            new int[] {5, 11, 4},
            new int[] {11, 10, 2},
            new int[] {10, 7, 6},
            new int[] {7, 1, 8},
            new int[] {3, 9, 4},
            new int[] {3, 4, 2},
            new int[] {3, 2, 6},
            new int[] {3, 6, 8},
            new int[] {3, 8, 9},
            new int[] {4, 9, 5},
            new int[] {2, 4, 11},
            new int[] {6, 2, 10},
            new int[] {8, 6, 7},
            new int[] {9, 8, 1}
        };

        // Draw each face
        foreach (var face in faces)
        {
            DrawLine(g, pen, projected[face[0]], projected[face[1]]);
            DrawLine(g, pen, projected[face[1]], projected[face[2]]);
            DrawLine(g, pen, projected[face[2]], projected[face[0]]);
        }
    }
}
