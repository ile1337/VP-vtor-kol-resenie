using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPvezbanjezaIspitPart6
{
    [Serializable]
    public class HuntingBall : AbstractBall
    {
        public readonly Color[] colors = new Color[2]
        {
            Color.Red,
            Color.Yellow
           // Color.Black
        };
        public HuntingBall(Point c):base(c)
        {
            color = colors[random.Next(colors.Length)];
        }
        public override void FallDown()
        {
            throw new NotImplementedException();
        }

        public override void MoveToPoint(Point p)
        {
            Center = new Point(p.X, Center.Y);
        }
    }
}
