using Microsoft.VisualBasic;
using ServiceConnexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP3.DAL;

namespace TP3
{
    /// <summary>
    /// Interaction logic for JouerHeros.xaml
    /// </summary>
    public partial class JouerHeros : Window
    {
        ConnexionClient service = new ConnexionClient();

        public JouerHeros()
        {
            InitializeComponent();

            int id = service.TrouverID(Constantes._UserName);

            dgHeros.ItemsSource = service.ListerHeros(id).ToList();
        }

        private void btnJouer_Click(object sender, RoutedEventArgs e)
        {
            if (dgHeros.SelectedCells.Count > 0)
            {
                Hero heroSelectionner = (Hero)dgHeros.SelectedItem;
                Constantes.Hero = heroSelectionner;
                if (heroSelectionner.EstConnecte == false)
                {
                    Constantes.ID_hero = heroSelectionner.Id;
                    Constantes.ID_monde = heroSelectionner.MondeId;
                    service.ModifierStatutHero(Constantes.ID_hero);
                    //Ici fetch l'objet du monde pour passer en paramètre à MainWindow
                    Constantes.monde = service.TrouverObjetMonde(Constantes.ID_monde);
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Cet héro est déjà connecté!");
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un héro!");
            }
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            PageAcceuil page = new PageAcceuil();
            page.Show();
            this.Close();
        }
    }
}
