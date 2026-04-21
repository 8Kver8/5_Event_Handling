using System.Drawing.Drawing2D;

namespace Event_processing.Objects
{
    class Pickup : BaseObject
    {
        private Random rnd = new Random();

        public Pickup(float x, float y, float angle) : base(x, y, angle)
        {
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.GreenYellow), -15, -15, 30, 30);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }

        public void RandomizePosition(int maxWidth, int maxHeight)
        {
            X = rnd.Next(30, maxWidth - 30);
            Y = rnd.Next(30, maxHeight - 30);
        }
    }
}
