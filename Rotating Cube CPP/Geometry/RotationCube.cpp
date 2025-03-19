#include "RotationCube.h"

void RotatingCube::run()
{
    sf::RenderWindow window(sf::VideoMode(800, 800), "Rotating Cube CPP");
    window.setFramerateLimit(60);

    while (window.isOpen()) 
    {
        sf::Event event;
        while (window.pollEvent(event)) 
        {
            if (event.type == sf::Event::Closed)
            {
				window.close();
            }
        }

        update();
        window.clear(sf::Color::Black);
        draw(window);
        window.display();
    }
}

void RotatingCube::update()
{
	angleX += 0.0f;
	angleY += 0.1f;
}

void RotatingCube::draw(sf::RenderWindow& window)
{
    Point3D rotatedVertices[8];
    for (int i = 0; i < 8; ++i) 
    {
        rotatedVertices[i] = rotateX(cubeGeometry.vertices[i], angleX);
        rotatedVertices[i] = rotateY(rotatedVertices[i], angleY);
    }

    sf::Vertex lines[24];
    int index = 0;
    for (int i = 0; i < 8; ++i)
    {
        for (int j = i + 1; j < 8; ++j)
        {
            if (isEdge(i, j)) 
            {
                lines[index++] = project(rotatedVertices[i], window);
                lines[index++] = project(rotatedVertices[j], window);
            }
        }
    }

    window.draw(lines, index, sf::Lines);
}

Point3D RotatingCube::rotateX(const Point3D& point, float angle)
{
    float rad = angle * static_cast<float>(M_PI) / 180;
    float cosAngle = cos(rad);
    float sinAngle = sin(rad);
    return {
        point.x,
        cosAngle * point.y - sinAngle * point.z,
        sinAngle * point.y + cosAngle * point.z
    };
}

Point3D RotatingCube::rotateY(const Point3D& point, float angle)
{
    float rad = angle * static_cast<float>(M_PI) / 180;
    float cosAngle = cos(rad);
    float sinAngle = sin(rad);
    return {
        cosAngle * point.x + sinAngle * point.z,
        point.y,
        -sinAngle * point.x + cosAngle * point.z
    };
}

sf::Vertex RotatingCube::project(const Point3D& point, const sf::RenderWindow& window)
{
    float width = window.getSize().x;
    float height = window.getSize().y;
    float fov = 256.0f;
    float viewerDistance = 4.0f;
    float factor = fov / (viewerDistance - point.z);
    float x = point.x * factor + width / 2;
    float y = point.y * factor + height / 2;
    return sf::Vertex(sf::Vector2f(x, y), sf::Color::White);
}

bool RotatingCube::isEdge(int i, int j)
{
    static const std::pair<int, int> edges[12] = {
        {0, 1}, {1, 2}, {2, 3}, {3, 0},
        {4, 5}, {5, 6}, {6, 7}, {7, 4},
        {0, 4}, {1, 5}, {2, 6}, {3, 7}
    };

    for (const auto& edge : edges)
    {
        if ((i == edge.first && j == edge.second) || (i == edge.second && j == edge.first)) 
        {
            return true;
        }
    }
    return false;
}