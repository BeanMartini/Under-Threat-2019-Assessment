using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Under_Threat_2019_Assessment
{
    class Person
    {
        // declare fields to use in the class

        public int x, y, width, height;//variables for the rectangle
        public Image person;//variable for the person's image

        public Rectangle personRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public Person()
        {
            x = 500;
            y = 380;
            width = 40;
            height = 40;
            person = Image.FromFile("person1.png");
            personRec = new Rectangle(x, y, width, height);
        }

        //methods
        public void drawPerson(Graphics g)
        {

            g.DrawImage(person, personRec);
        }

        public void movePerson(string move)
        {
            personRec.Location = new Point(x, y);

            if (move == "right")
            {

                x += 5;
                personRec.Location = new Point(x, y);
            }

            personRec.Location = new Point(x, y);

            if (move == "left")
            {

                x -= 5;
                personRec.Location = new Point(x, y);
            }

            personRec.Location = new Point(x, y);

            if (move == "up")
            {

                y -= 5;
                personRec.Location = new Point(x, y);
            }

            if (move == "down")
            {

                y += 5;
                personRec.Location = new Point(x, y);
            }
        }

    }
}
