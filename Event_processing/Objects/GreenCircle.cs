using System.Drawing.Drawing2D;

namespace Event_processing.Objects
{
    class GreenCircle : BaseObject
    {
        public int Timer = 80;
        public Action<GreenCircle> OnTimeout;
        public static Random rnd = new Random();

        public GreenCircle(float x, float y, float angle) : base(x, y, angle)
        {
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.GreenYellow), -15, -15, 30, 30);

            g.DrawString(
                $"{Timer}",
                new Font("Verdana", 8),
                new SolidBrush(Color.Green),
                10, 10
            );
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

        public void Update()
        {
            Timer--;
            if (Timer <= 0)
            {
                Timer = 80;
                OnTimeout?.Invoke(this);
            }
        }
    }
}
