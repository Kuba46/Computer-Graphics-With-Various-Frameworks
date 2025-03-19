#pragma once

#include <SFML/Graphics.hpp>
#include <SFML/Window.hpp>

#include <iostream>

#define _USE_MATH_DEFINES
#include <math.h>

#include "CubeGeometry.hpp"

class RotatingCube 
{
public:
    RotatingCube() : angleX(0), angleY(0) {}

    void run();

private:
    float angleX, angleY;
    CubeGeometry cubeGeometry;

    void update();

    void draw(sf::RenderWindow& window);

    Point3D rotateX(const Point3D& point, float angle);
    Point3D rotateY(const Point3D& point, float angle);

    sf::Vertex project(const Point3D& point, const sf::RenderWindow& window);

    bool isEdge(int i, int j);
};