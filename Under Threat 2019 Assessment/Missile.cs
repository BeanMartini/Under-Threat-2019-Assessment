using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Under_Threat_2019_Assessment
{
    class Missile
    {
        // declare fields to use in the class
        public int x, y, width, height;//variables for the rectangle

        Image[] images = new Image[6];//set space for an array called images of 6 images

        public Rectangle missileRec;//variable for a rectangle to place our image in
        public int score;
        Animation animate;//create an object called animate
        //Create a constructor (initialises the values of the fields)
        public Missile(int spacing)
        {
            x = -80;
            y = spacing;
            width = 45;
            height = 20;
            for (int i = 1; i <= 5; i++)
            {
                images[i] = Image.FromFile(Application.StartupPath + @"\missile" + i.ToString() + ".gif");
            }
            //pass the images array to the Animation class's constructor
            animate = new Animation(images);
            missileRec = new Rectangle(x, y, width, height);
        }

        // Methods for the Missile class
        public void drawMissile(Graphics g)
        {
            missileRec = new Rectangle(x, y, width, height);
            //instead of just drawing the missile we use the GetNextImage() method to animate the missile
            g.DrawImage(animate.GetNextImage(), missileRec);
        }

        public void moveMissile()
        {
            missileRec.Location = new Point(x, y);

            if (missileRec.Location.X > 600)
            {
                score += 1;// add 1 to score when a missile reaches the right of panel
                x = -50;
                missileRec.Location = new Point(x, y);
            }

        }
    }
}