using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int boruHizi = 5;
        int gravity = 10;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappybird.Top += gravity;
            boruAlt.Left -= boruHizi;
            boruUst.Left -= boruHizi;
            scorelabel.Text = "Score: " + score;
            if (boruAlt.Left < -70)
            {
                boruAlt.Left = 400;
                score++;
            }
            if (boruUst.Left < -70)
            {
                boruUst.Left = 400;
                score++;
            }
            if (flappybird.Bounds.IntersectsWith(boruAlt.Bounds) || flappybird.Bounds.IntersectsWith(boruUst.Bounds) || flappybird.Bounds.IntersectsWith(zemin.Bounds))
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gravity = 10;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scorelabel.Text = "Game Over!";
        }
    }
}
