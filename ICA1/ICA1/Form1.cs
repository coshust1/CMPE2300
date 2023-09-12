/////////////////////////////////////////////////////////
///Caleb Oshust
///Sept 11, 2023
///CMPE 2300
///ICA1 Balls
///
///Generate instances of ball class and move them in renderer
///
//////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ICA1
{
    public partial class Form1 : Form
    {
        // Declare drawer object for drawing, a random object for generating random numbers, and a list to store balls.
        CDrawer drawer = new CDrawer(800, 800);
        Random random = new Random();
        List<CBall> list = new List<CBall>();

        public Form1()
        {
            // Initialize the form components.
            InitializeComponent();
            // Disable continuous update of the drawer to improve performance.
            drawer.ContinuousUpdate = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Declare variables to hold the x and y components of the direction.
            int x = 0;
            int y = 0;

            // Generate random values for x and y until they are both non-zero and not equal.
            while (x == 0 || y == 0 || x == y)
            {
                x = random.Next(-5, 6);
                y = random.Next(-5, 6);
            }

            // Create a new CBall object with a random color and the generated direction, and add it to the list.
            list.Add(new CBall(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)), new Point(x, y)));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create a new CBall object with a random color and the default direction, and add it to the list.
            list.Add(new CBall(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256))));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Clear the drawer.
            drawer.Clear();
            // Move and render each ball in the list.
            foreach (var item in list)
            {
                item.Move();
                item.Renderer(drawer);
            }
        }
    }

}
