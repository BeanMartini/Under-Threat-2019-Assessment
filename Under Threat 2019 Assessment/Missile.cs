﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Under_Threat_2019_Assessment
{
    class Missile
    {
        // declare fields to use in the class
        public int x, y, width, height;//variables for the rectangle
        public Image missileImage;//variable for the missile's image

        public Rectangle missileRec;//variable for a rectangle to place our image in
        public int score;
        //Create a constructor (initialises the values of the fields)
        public Missile()
        {
            x = 10;
            y = 10;
            width = 60;
            height = 60;
            missileImage = Image.FromFile("missile1.png");
            missileRec = new Rectangle(x, y, width, height);
        }

        // Methods for the Missile class
        public void drawMissile(Graphics g)
        {
            g.DrawImage(missileImage, missileRec);
        }
    }
}
