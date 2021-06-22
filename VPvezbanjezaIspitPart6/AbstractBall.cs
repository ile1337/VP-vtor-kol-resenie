using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPvezbanjezaIspitPart6
{
    [Serializable]
    public abstract class AbstractBall
   {
        [NonSerialized()]
        public readonly Random random = new Random();
        public Point Center { get; set; }
        public Color color { get; set; }
        public int Radius { get; set; }

        protected AbstractBall(Point center)
        {
            Center = center;
            this.Radius = 20;
        }

        public void Draw(Graphics g)
        {
            Brush b1 = new SolidBrush(color);
            Graphics graphics = g;
            Brush b2 = b1;
            Point center = Center;
            int x = center.X - Radius;
            center = Center;
            int y = center.Y - Radius;
            int width = Radius * 2;
            int height = Radius * 2;
            graphics.FillEllipse(b2, x, y, width, height);
            b1.Dispose();
        }
        public bool Collides(AbstractBall other)
        {
            Point center = Center;
            int x1 = center.X;
            center = other.Center;
            int x2 = center.X;
            double num1 = Math.Pow(x1 - x2, 2);
            center = Center;
            int y1 = center.Y;
            center = other.Center;
            int y2 = center.Y;
            double num2 = Math.Pow(y1 - y2, 2);
            return num1 + num2 < Math.Pow(Radius + other.Radius, 2);
        }
        public abstract void FallDown();
        public abstract void MoveToPoint(Point p);
    }
}
