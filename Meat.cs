using Avalonia;
using Avalonia.Media;
namespace Tatbi9
{
    public class Meat : SimulationObject
    {
        bool exist = true;
        int addPoop = 1;
        public Meat(double x, double y, double health, Simulation simulation, float radius) : base(typeof(Meat), Colors.IndianRed, x, y, 10, 0, "", simulation, radius, "")
        { }
        public override void Update()
        {
            //the meat loses Energy over time
            if (exist)
            {
                Health -= 0.01;
            }
            // If health is empty, remove meat and add poop instead
            if (Health <= -10)
            {
                exist = false;
                foreach (SimulationObject item in get_simulation().Objects)
                {
                    if (item.X == X & item.Y == Y)
                    {
                        if (item.GetType() == typeof(Meat) && exist == false)
                        {
                            get_simulation().Remove(item);
                        }
                    }
                }
                if (addPoop == 1)
                {
                    get_simulation().Add(new Poop(X, Y, get_simulation(), Radius));
                    addPoop = 0;
                }
            }
        }
        public override void Render(DrawingContext context)
        {
            if (exist)
            {
                // Draw Meat
                var brush = new SolidColorBrush(Color);
                context.DrawGeometry(brush, null, new EllipseGeometry(new Rect(X - 7, Y - 7, 14, 14)));

                //Health bar shadow
                var penA = new Pen(Brushes.DarkGray, 3);
                context.DrawLine(penA, new Point(X - 10, Y - 15), new Point(X + 10, Y - 15));
                //Health bar
                var penB = new Pen(Brushes.DarkGreen, 3);
                context.DrawLine(penB, new Point(X - 10, Y - 15), new Point(X + Health, Y - 15));
            }
        }
    }
}