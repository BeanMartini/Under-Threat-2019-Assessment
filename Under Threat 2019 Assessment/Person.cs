using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Under_Threat_2019_Assessment
{
    class Person
    {
        // declare fields to use in the class

        public int x, y, width, height;//variables for the rectangle

        Image[] images = new Image[8];//set space for an array called images of 4 images

        public Rectangle personRec;//variable for a rectangle to place our image in

        Animation animate;//create an object called animate

        //Create a constructor (initialises the values of the fields)
        public Person()
        {
            x = 500;
            y = 380;
            width = 65;
            height = 65;

            for (int i = 1; i <= 7; i++)
            {
                images[i] = Image.FromFile(Application.StartupPath + @"\person" + i.ToString() + ".gif");
            }
            //pass the images array to the Animation class's constructor
            animate = new Animation(images);

            personRec = new Rectangle(x, y, width, height);
        }

        //methods
        public void drawPerson(Graphics g)
        {

            //instead of just drawing the person we use the GetNextImage() method to animate the person
            g.DrawImage(animate.GetNextImage(), personRec);
        }

        public void movePerson(string move)
        {
            personRec.Location = new Point(x, y);

            if (move == "right")
            {
                if (personRec.Location.X > 559) // is person hitting the right side
                {

                    x = 560;
                    personRec.Location = new Point(x, y);
                }
                else
                    x += 8;
                personRec.Location = new Point(x, y);
            }

            personRec.Location = new Point(x, y);

            if (move == "left")
            {
                if (personRec.Location.X < 1) // is person hitting the left side
                {

                    x = 0;
                    personRec.Location = new Point(x, y);
                }
                else
                    x -= 8;
                personRec.Location = new Point(x, y);
            }

            personRec.Location = new Point(x, y);

            if (move == "up")
            {
                if (personRec.Location.Y < 2) // is person hitting the top side
                {

                    y = 1;
                    personRec.Location = new Point(x, y);
                }
                else
                    y -= 8;
                personRec.Location = new Point(x, y);
            }

            if (move == "down")
            {
                if (personRec.Location.Y > 408) // is person hitting the bottom side
                {

                    y = 409;
                    personRec.Location = new Point(x, y);
                }
                else
                    y += 8;
                personRec.Location = new Point(x, y);
            }
        }

    }
}
