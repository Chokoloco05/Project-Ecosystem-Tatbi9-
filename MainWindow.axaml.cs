using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Tatbi9
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Afficher le menu au démarrage
            ShowMenu();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        // Méthode pour afficher la vue Menu
        private void ShowMenu()
        {
            var menuView = new Menu(); // Utilisez la classe Menu qui correspond à Menu.axaml
            MainContent.Content = menuView; // Charger la vue Menu dans le ContentControl

            // Abonnement à l'événement du menu pour démarrer la simulation
            menuView.StartSimulationClicked += StartSimulation;
        }

        // Méthode pour afficher la vue Simu
        private void ShowSimu()
        {
            var simuView = new Simu(); // Utilisez la classe Simu qui correspond à Simu.axaml
            MainContent.Content = simuView; // Charger la vue Simu dans le ContentControl
        }

        // Gestionnaire d'événements pour démarrer la simulation depuis le Menu
        private void StartSimulation(object sender, EventArgs e)
        {
            ShowSimu(); // Afficher la vue de simulation
        }
    }
}
