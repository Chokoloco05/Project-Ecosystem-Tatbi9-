

using System;
using Avalonia.Media;
namespace Tatbi9
{
    public class Carnivore : Animal
    {
        public Carnivore(Type classe, Color color, double x, double y, double health, double energy, float visionRadius, float actionRadius, string gender, Simulation simulation, float radius) : base(typeof(Carnivore), color, x, y, health, energy, 100, 30, gender, "", simulation, radius)
        { }
        public override void Update()
        { }
        public override void Render(DrawingContext context)
        { }
    }
}