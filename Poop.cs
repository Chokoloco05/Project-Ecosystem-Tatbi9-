using Avalonia;
using Avalonia.Media;
namespace Tatbi9
{
    public class Poop : SimulationObject
    {
        bool exist = true;
        public Poop(double x, double y, Simulation simulation, float radius) : base(typeof(Poop), Colors.SaddleBrown, x, y, 0, 0, "", simulation, radius, "")
        {
        }
        public override void Update()
        {
        }

        public override void Render(DrawingContext context)
        {
            if (exist)
            {
                // Draw poop
                var brush = new SolidColorBrush(Color);
                context.DrawGeometry(brush, null, new EllipseGeometry(new Rect(X - 11, Y - 7, 22, 14)));
            }
        }
    }
}