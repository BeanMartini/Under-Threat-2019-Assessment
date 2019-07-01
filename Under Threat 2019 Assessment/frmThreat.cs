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
        Missile missile1 = new Missile(); //create the object, missile1
        Person person = new Person();

        public frmThreat()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            //call the Missile class's DrawPlanet method to draw the image missile1 
            missile1.drawMissile(g);

            person.drawPerson(g);
        }
    }
}
