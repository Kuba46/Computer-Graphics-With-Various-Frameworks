#pragma once

#include "Point3D.hpp"

class CubeGeometry 
{
public:
    Point3D vertices[8];

    CubeGeometry() {
        vertices[0] = Point3D(-1, -1, -1);
        vertices[1] = Point3D(1, -1, -1);
        vertices[2] = Point3D(1, 1, -1);
        vertices[3] = Point3D(-1, 1, -1);
        vertices[4] = Point3D(-1, -1, 1);
        vertices[5] = Point3D(1, -1, 1);
        vertices[6] = Point3D(1, 1, 1);
        vertices[7] = Point3D(-1, 1, 1);
    }
};