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

            // Afficher le menu au d�marrage
            ShowMenu();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        // M�thode pour afficher la vue Menu
        private void ShowMenu()
        {
            var menuView = new Menu(); // Utilisez la classe Menu qui correspond � Menu.axaml
            MainContent.Content = menuView; // Charger la vue Menu dans le ContentControl

            // Abonnement � l'�v�nement du menu pour d�marrer la simulation
            menuView.StartSimulationClicked += StartSimulation;
        }

        // M�thode pour afficher la vue Simu
        private void ShowSimu()
        {
            var simuView = new Simu(); // Utilisez la classe Simu qui correspond � Simu.axaml
            MainContent.Content = simuView; // Charger la vue Simu dans le ContentControl
        }

        // Gestionnaire d'�v�nements pour d�marrer la simulation depuis le Menu
        private void StartSimulation(object sender, EventArgs e)
        {
            ShowSimu(); // Afficher la vue de simulation
        }
    }
}
