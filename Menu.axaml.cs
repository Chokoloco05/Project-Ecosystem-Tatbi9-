using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace Tatbi9
{
    public partial class Menu : UserControl // Modifier ici pour que Menu soit un UserControl
    {
        // 1. Déclaration de l'événement
        public event EventHandler StartSimulationClicked;

        public Menu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        // 2. Quand on clique sur le bouton Start, on va appeler l'événement pour changer la vue dans MainWindow
        private void OnStartClicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // Déclenche l'événement StartSimulationClicked pour que MainWindow puisse réagir
            StartSimulationClicked?.Invoke(this, EventArgs.Empty);
        }

        // Quand on clique sur le bouton Quit, on ferme l'application
        private void OnQuitClicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
            {
                desktopLifetime.Shutdown();
            }
        }
    }
}
