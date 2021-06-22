using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPvezbanjezaIspitPart6
{
    [Serializable]
    public class Scene
    {
        [NonSerialized()]
        public Random random = new Random();
        public List<Ball> balls { get; set; }
        public HuntingBall huntingBall { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int lifes { get; set; }
        public int hits { get; set; }
        public Scene(int w, int h)
        {
            Width = w;
            Height = h;
            balls = new List<Ball>();
            huntingBall = new HuntingBall(new System.Drawing.Point(this.Width / 2, Height - 80));
            lifes = 3;
            hits = 0;
            random = new Random();
        }
        public void draw(Graphics g)
        {
            huntingBall.Draw(g);
            foreach(AbstractBall ball in balls)
            {
                ball.Draw(g);
            }
        }
        public void addBall()
        {
            balls.Add(new Ball(random.Next(Width - 10)));
        }
        public void moveHuntingBall(Point p)
        {
            huntingBall.MoveToPoint(p);
        }
        public void moveDownBalls()
        {
            foreach(AbstractBall ball in balls)
            {
                ball.FallDown();
            }
        }
        public void checkCollisions()
        {
            for (int i = balls.Count - 1; i >= 0; --i)
            {
                if (balls[i].Collides(huntingBall))
                {
                    if(balls[i].color == Color.Black)
                    {
                        ++lifes;
                        balls.RemoveAt(i);
                    }else if(balls[i].color == huntingBall.color)
                    {
                        hits++;
                        balls.RemoveAt(i);
                    }
                }
            }
        }
       public void deleteMissingBalls()
        {
            for(int i = balls.Count - 1; i>=0; --i)
            {
                if(balls[i].Center.Y + 30 > Height)
                {
                    if(balls[i].color == huntingBall.color)
                    {
                        --lifes;
                        balls.RemoveAt(i);
                    }
                }
            }
        }
    }
}
