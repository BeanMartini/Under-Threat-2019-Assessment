using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
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
        Random xspeed = new Random();

        Person person = new Person();

        bool left, right, up, down;
        string move;

        int score, lives;


        public frmThreat()
        {
            InitializeComponent();

            for (int i = 0; i < 7; i++)
            {
                int y = 5 + (i * 65);
                missile[i] = new Missile(y);
            }

            //code to stop the panel from flickering
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlGame, new object[] { true }); //stops the panel from flickering
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lives = int.Parse(txtLives.Text);// pass lives entered from textbox to lives variable
        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;

            for (int i = 0; i < 7; i++)
            {
                // generate a random number from 5 to 20 and put it in rndmspeed
                int rndmspeed = xspeed.Next(5, 30);
                missile[i].x += rndmspeed;

                //call the Missile class's drawMissile method to draw the images
                missile[i].drawMissile(g);
            }


            person.drawPerson(g);
        }

        private void tmrPerson_Tick(object sender, EventArgs e)
        {
            if (right) // if right arrow key pressed
            {
                move = "right";
                person.movePerson(move);
            }
            if (left) // if left arrow key pressed
            {
                move = "left";
                person.movePerson(move);
            }
            if (up) // if up arrow key pressed
            {
                move = "up";
                person.movePerson(move);
            }
            if (down) // if down arrow key pressed
            {
                move = "down";
                person.movePerson(move);
            }

        }

        private void frmThreat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }
            if (e.KeyData == Keys.Up) { up = true; }
            if (e.KeyData == Keys.Down) { down = true; }
        }

        private void frmThreat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }
            if (e.KeyData == Keys.Up) { up = false; }
            if (e.KeyData == Keys.Down) { down = false; }
        }

        private void tmrMissile_Tick(object sender, EventArgs e)
        {
            score = 0;

            for (int i = 0; i < 7; i++)
            {
                missile[i].moveMissile();

                if (person.personRec.IntersectsWith(missile[i].missileRec))
                {
                    //reset missile[i] back to top of panel
                    missile[i].x = -50; // set  y value of missileRec
                    lives -= 1;// lose a life
                    txtLives.Text = lives.ToString();// display number of lives
                    checkLives();
                }

                score += missile[i].score;// get score from Missile class (in moveMissile method)
                lblScore.Text = score.ToString();// display score
            }
            pnlGame.Invalidate();//makes the paint event fire to redraw the panel
        }

        private void checkLives()
        {
            if (lives == 0)
            {
                tmrMissile.Enabled = false;
                tmrPerson.Enabled = false;
                MessageBox.Show("Game Over");

            }
        }

    }
}
