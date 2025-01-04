using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace Tatbi9
{
    public partial class Simu : Window
    {
        private DispatcherTimer timer;
        private Simulation simulation;
        private bool isRunning = true;
        private Random random = new Random();
        private string[] genders = { "M", "F" };
        private Type[] Classes = { typeof(Carnivore), typeof(Herbivore) };
        private int Hitbox = 1;
        private SimulationObject Item;
        private int Count;
        private const int SimuSpeed = 16; // ~60 FPS (16ms par tick)

        public Simu()
        {
            InitializeComponent();

            // Initialise la simulation
            simulation = new Simulation();

            // Ajoute la simulation à la fenêtre
            var graphics = this.FindControl<Canvas>("graphics");
            if (graphics != null)
            {
                graphics.Children.Add(simulation);
            }

            // Configure le timer
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(SimuSpeed)
            };
            timer.Tick += OnTimeEvent;
            timer.Start();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnTimeEvent(object sender, EventArgs e)
        {
            // Met à jour la simulation
            simulation.Update();

            // Redessine le graphique
            simulation.InvalidateVisual();
        }

        private void PauseClicked(object sender, EventArgs e)
        {
            isRunning = !isRunning;

            var PauseBtn = this.FindControl<Button>("PauseBtn");
            if (isRunning)
            {
                timer.Start();
                if (PauseBtn != null) PauseBtn.Content = "Pause";
            }
            else
            {
                timer.Stop();
                if (PauseBtn != null) PauseBtn.Content = "Start";
            }
        }

        private void CountClicked(object sender, EventArgs e)
        {
            Count = 0;

            // Compte les organismes vivants
            foreach (SimulationObject item in simulation.Objects)
            {
                if (item.GetType() == typeof(Plant) || item.GetType() == typeof(Animal))
                {
                    Count += 1;
                }
            }

            // Met à jour le texte du bouton CountBtn
            var CountBtn = this.FindControl<Button>("CountBtn");
            if (CountBtn != null)
            {
                CountBtn.Content = $"Living beings: {Count}";
            }
        }

        private void AddAnimalClicked(object sender, EventArgs e)
        {
            // Ajoute un nouvel animal
            simulation.Add(new Animal(
                Classes[random.Next(Classes.Length)],
                Avalonia.Media.Colors.Red,
                random.Next(100, 1400),
                random.Next(100, 550),
                10, 10, 100, 30,
                genders[random.Next(genders.Length)],
                "No", simulation, random.Next(1, 10)));
        }

        private void AddPlantClicked(object sender, EventArgs e)
        {
            // Ajoute une nouvelle plante
            simulation.Add(new Plant(
                random.Next(100, 1400),
                random.Next(100, 550),
                10, 10, 160, 50,
                simulation, random.Next(1, 10)));
        }

        private void ShowHitboxes(object sender, EventArgs e)
        {
            var Showbtn = this.FindControl<Button>("Showbtn");

            // Alterne entre afficher/masquer les hitboxes
            Hitbox = 1 - Hitbox; // Inverse la valeur de Hitbox (0 -> 1, 1 -> 0)
            foreach (SimulationObject item in simulation.Objects)
            {
                item.Radius = Hitbox;
            }

            if (Showbtn != null)
            {
                Showbtn.Content = Hitbox == 1 ? "Hide Hitbox" : "Show Hitbox";
            }
        }
    }
}
