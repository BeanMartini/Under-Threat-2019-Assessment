using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Under_Threat_2019_Assessment
{
    public partial class frmThreat : Form
    {
        Graphics g; //declare a graphics object called g

        // declare space for an array of 7 objects called missile 
        Missile[] missile = new Missile[7];

        Person person = new Person();

        public frmThreat()
        {
            InitializeComponent();

            for (int i = 0; i < 7; i++)
            {
                int y = 5 + (i * 65);
                missile[i] = new Missile(y);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;

            for (int i = 0; i < 7; i++)
            {
                //call the Missile class's drawMissile method to draw the images
                missile[i].drawMissile(g);
            }


            person.drawPerson(g);
        }
    }
}
