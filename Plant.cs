
using System;
using Avalonia;
using Avalonia.Media;

namespace Tatbi9
{
    public class Plant : SimulationObject
    {
        Random random = new Random();

        bool isAlive = true;
        int addPoop = 1;

        float rootRadius;
        float semisRadius;

        int checkPoopTimer = 0;
        int spawnPlantTimer = 0;
        int spawnPlantStock = 0;
        public Plant(double x, double y, double health, double energy, float rootRadius, float semisRadius, Simulation simulation, float radius) : base(typeof(Plant), Colors.Green, x, y, health, energy, "", simulation, radius, "")
        {
            this.rootRadius = rootRadius;
            this.semisRadius = semisRadius;
        }
        public float RootRadius { get { return this.rootRadius; } set { this.rootRadius = value; } }
        public float SemisRadius { get { return this.semisRadius; } set { this.semisRadius = value; } }

        public override void Update()
        {
            if (isAlive)
            {
                // If plant has energy, lower energy bar
                if (Energy <= -10)
                {
                    // If energy bar equal 0, refill it for 5 health point
                    if (Health > -10)
                    {
                        Energy = 10;
                        Health -= 5;
                    }
                }
                else
                {
                    Energy -= 0.02;
                }

                checkPoopTimer++;
                if (checkPoopTimer >= 100)
                {
                    checkPoop();
                    checkPoopTimer = 0;
                }

                spawnPlantTimer++;
                if (spawnPlantTimer >= 2000 && spawnPlantStock >= 2) // Spawn a new plant every 20 seconds if spawn plant stock >= 1
                {
                    newPlant();
                    spawnPlantTimer = random.Next(0, 500);
                    spawnPlantStock -= 2;
                }

                // If health is empty, animal dies
                if (Health <= -10) { isAlive = false; }
            }
            // If Plant is dead; set the energy bar to empty , add a Poop and remove the Plant
            if (isAlive == false)
            {
                Energy = -10;
                if (addPoop == 1)
                {
                    get_simulation().Add(new Poop(X, Y, get_simulation(), Radius));
                    addPoop = 0;
                }
                foreach (SimulationObject item in get_simulation().Objects)
                {
                    if (item.X == X & item.Y == Y)
                    {
                        if (item.GetType() == typeof(Plant) && isAlive == false)
                        {
                            get_simulation().Remove(item);
                        }
                    }
                }
            }
        }

        public override void Render(DrawingContext context)
        {
            if (isAlive)
            {
                //Plant circle
                var brush = new SolidColorBrush(Color);
                context.DrawGeometry(brush, null, new EllipseGeometry(new Rect(X - 10, Y - 10, 20, 20)));

                //Health bar shadow
                var penZ = new Pen(Brushes.DarkGray, 3);
                context.DrawLine(penZ, new Point(X - 10, Y - 20), new Point(X + 10, Y - 20));
                //Energy bar shadow
                var penY = new Pen(Brushes.DarkGray, 3);
                context.DrawLine(penY, new Point(X - 10, Y - 15), new Point(X + 10, Y - 15));

                //Health bar
                var penX = new Pen(Brushes.DarkGreen, 3);
                context.DrawLine(penX, new Point(X - 10, Y - 20), new Point(X + Health, Y - 20));

                //Energy bar
                var penW = new Pen(Brushes.Yellow, 3);
                context.DrawLine(penW, new Point(X - 10, Y - 15), new Point(X + Energy, Y - 15));

                //Zone semis
                var penV = new Pen(Brushes.DarkGreen);
                context.DrawGeometry(null, penV, new EllipseGeometry(new Rect(X - Radius * SemisRadius, Y - Radius * SemisRadius, 2 * Radius * SemisRadius, 2 * Radius * SemisRadius)));

                //Zone root
                var penU = new Pen(Brushes.Brown);
                context.DrawGeometry(null, penU, new EllipseGeometry(new Rect(X - Radius * RootRadius, Y - Radius * RootRadius, 2 * Radius * RootRadius, 2 * Radius * RootRadius)));
            }
        }

        // Method to check if there is poop in root radius. If yes, then remove the poop
        // and refills the plant's energy.
        public void checkPoop()
        {
            foreach (SimulationObject item in get_simulation().Objects)
            {
                if (item.X >= (X - RootRadius) && item.X <= (X + RootRadius))
                {
                    if (item.Y >= (Y - RootRadius) && item.Y <= (Y + RootRadius))
                    {
                        if (item.GetType() == typeof(Poop))
                        {
                            get_simulation().Remove(item);
                            spawnPlantStock += 1;
                            Energy += 20;
                            if (Energy > 10)
                            {
                                Health += 5;
                                Energy = 10;
                                if (Health > 10)
                                {
                                    Health = 10;
                                }
                            }
                        }
                    }
                }
            }
        }
        //method to add a new plant close to it
        public void newPlant()
        {
            get_simulation().Add(new Plant(random.Next((int)(X - SemisRadius), (int)(X + SemisRadius)), random.Next((int)(Y - SemisRadius), (int)(Y + SemisRadius)), 10, 10, 160, 50, get_simulation(), Radius));
        }

    }
}

