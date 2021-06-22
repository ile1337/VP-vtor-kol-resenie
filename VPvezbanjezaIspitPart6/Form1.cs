using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPvezbanjezaIspitPart6
{
    public partial class Form1 : Form
    {
        public Scene scene { get; set; }
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
            scene = new Scene(Width,Height);
            DoubleBuffered = true;
            updateStatusBar();
            Invalidate();
        }
        private void updateStatusBar()
        {
            tsslBallsCaught.Text = scene.hits.ToString();
            tsslLifesLeft.Text = scene.lifes.ToString();
        }


        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            scene.Width = Width;
            scene.Height = Height;
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            scene.Width = Width;
            scene.Height = Height;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scene.addBall();
            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            scene.moveDownBalls();
            scene.deleteMissingBalls();
            scene.checkCollisions();
            updateStatusBar();
            Invalidate();
            if(scene.lifes != 0)
            {
                return;
            }
            timer1.Stop();
            timer2.Stop();
            if(MessageBox.Show("GAME OVER","Want to start a new game?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                scene = new Scene(Width,Height);
                timer1.Start();
                timer2.Start();
                Invalidate();
            }
            else
            {
                this.Close();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.draw(e.Graphics);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            scene.moveHuntingBall(e.Location);
            scene.checkCollisions();
            updateStatusBar();
            Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                save(sfd.FileName);
            }
            timer1.Start();
            timer2.Start();

        }
        private void save(string s)
        {

            using (FileStream fs = new FileStream(s, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs,scene);
            }
        }
        private void open(string s)
        {
          
                using (FileStream fs = new FileStream(s, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    scene = (Scene)formatter.Deserialize(fs);
                    scene.random = new Random();
                }      
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            timer1.Stop();
            timer2.Stop();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                open(ofd.FileName);
            }
            timer1.Start();
            timer2.Start();
            Invalidate();
        }
    }
}
