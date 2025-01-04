using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Tatbi9
{
    public class Simulation : Control
    {
        private List<SimulationObject> objects;
        private Random random = new Random();

        public List<SimulationObject> Objects => new List<SimulationObject>(objects);

        public Simulation()
        {
            objects = new List<SimulationObject>();

            // Ajout d'objets par défaut à la simulation
            Add(new Animal(typeof(Carnivore), Colors.Red, random.Next(100, 1300), random.Next(100, 550), 10, 10, 100, 30, "M", "No", this, 0));
            Add(new Animal(typeof(Carnivore), Colors.Red, random.Next(100, 1300), random.Next(100, 550), 10, 10, 100, 30, "F", "No", this, 0));
            Add(new Animal(typeof(Herbivore), Colors.Red, random.Next(100, 1300), random.Next(100, 550), 10, 10, 100, 30, "M", "No", this, 0));
            Add(new Animal(typeof(Herbivore), Colors.Red, random.Next(100, 1300), random.Next(100, 550), 10, 10, 100, 30, "M", "No", this, 0));
            Add(new Animal(typeof(Herbivore), Colors.Red, random.Next(100, 1300), random.Next(100, 550), 10, 10, 100, 30, "F", "No", this, 0));
            Add(new Animal(typeof(Herbivore), Colors.Red, random.Next(100, 1300), random.Next(100, 550), 10, 10, 100, 30, "F", "No", this, 0));
            Add(new Plant(random.Next(100, 1300), random.Next(100, 550), 10, 10, 160, 50, this, 0));
            Add(new Plant(random.Next(100, 1300), random.Next(100, 550), 10, 10, 160, 50, this, 0));
            Add(new Plant(random.Next(100, 1300), random.Next(100, 550), 10, 10, 160, 50, this, 0));
            Add(new Plant(random.Next(100, 1300), random.Next(100, 550), 10, 10, 160, 50, this, 0));
            Add(new Plant(random.Next(100, 1300), random.Next(100, 550), 10, 10, 160, 50, this, 0));
            Add(new Plant(random.Next(100, 1300), random.Next(100, 550), 10, 10, 160, 50, this, 0));
        }

        public void Update()
        {
            // Met à jour chaque objet dans la simulation
            foreach (SimulationObject obj in Objects)
            {
                obj.Update();
            }

            // Redessine le contrôle
            InvalidateVisual();
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            // Dessine chaque objet de la simulation
            foreach (SimulationObject obj in objects)
            {
                obj.Render(context);
            }

            // Dessiner des limites de zone en fonction de la valeur du rayon
            var penO = new Pen(Brushes.White);

            context.DrawLine(penO, new Point(0, 0), new Point(1400, 0));
            context.DrawLine(penO, new Point(0, 650), new Point(1400, 650));
            context.DrawLine(penO, new Point(0, 0), new Point(0, 650));
            context.DrawLine(penO, new Point(1400, 0), new Point(1400, 650));
        }

        public void Add(SimulationObject obj)
        {
            // Ajoute un objet à la simulation
            objects.Add(obj);
        }

        public void Remove(SimulationObject obj)
        {
            // Retire un objet de la simulation
            objects.Remove(obj);
        }
    }
}
