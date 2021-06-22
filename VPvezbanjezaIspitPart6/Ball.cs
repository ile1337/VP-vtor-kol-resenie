using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPvezbanjezaIspitPart6
{
    [Serializable]
    public class Ball : AbstractBall
    {
        public readonly Color[] colors = new Color[4]
        {
            Color.Red,
            Color.Yellow,
            Color.Blue,
            Color.Black
        };
        public Ball(int x) : base(new Point(x, 50))
        {
            color = colors[random.Next(colors.Length)];
        }
        public override void FallDown()
        {
            Point center = Center;
            int x = center.X;
            center = Center;
            int y = center.Y+10;
            Center = new Point(x, y);
        }

        public override void MoveToPoint(Point p)
        {
            throw new NotImplementedException();
        }
    }
}
