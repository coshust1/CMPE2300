/////////////////////////////////////////////////////////
///Caleb Oshust
///Sept 11, 2023
///CMPE 2300
///ICA1 Balls
///
///Generate instances of ball class and move them in renderer
///Submission Code : 1231_2300_A01
//////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA1
{
    public class CBall
    {
        // Declare private variables for the position, direction, color, and size of the ball.
        private Point position;
        private Point direction;
        private Color color;
        private int size;

        // Constructor to create a new ball with the specified color and a default position, direction, and size.
        public CBall(Color Color)
        {
            color = Color;
            position = new Point(400, 300);
            direction = new Point(100, 20);
            size = 50;
        }

        // Constructor to create a new ball with the specified color and direction, and a default position and size.
        public CBall(Color Color, Point Direction)
        : this(Color)
        {
            direction = Direction;
        }

        // Method to move the ball.
        public void Move()
        {
            // If the ball hits the left or right wall, reverse its x direction and decrease its size.
            if (position.X < 0 || position.X > 800)
            {
                direction.X = -(direction.X);
                size -= 2;
            }
            // If the ball hits the top or bottom wall, reverse its y direction and decrease its size.
            if (position.Y < 0 || position.Y > 800)
            {
                direction.Y = -(direction.Y);
                size -= 2;
            }
            // Update the position of the ball.
            position.Offset(direction);
        }

        // Method to render the ball on the drawer.
        public void Renderer(CDrawer drawer)
        {
            // Draw the ball on the drawer if its size is greater than 1.
            if (size > 1)
            {
                drawer.AddCenteredEllipse(position, size, size, color);
                drawer.Render();
            }
        }
    }
}
