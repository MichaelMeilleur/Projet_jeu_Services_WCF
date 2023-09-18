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
    /// Interaction logic for SupprimerHero.xaml
    /// </summary>
    public partial class SupprimerHero : Window
    {

        ConnexionClient service = new ConnexionClient();

        public SupprimerHero()
        {
            InitializeComponent();

            int id = service.TrouverID(Constantes._UserName);

            dgHero.ItemsSource = service.ListerHeros(id).ToList();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (dgHero.SelectedCells.Count > 0)
            {
                Hero heroSelectionner = (Hero)dgHero.SelectedItem;
                Constantes.ID_hero = heroSelectionner.Id;
                ConfirmationSupprimerHero page = new ConfirmationSupprimerHero();
                page.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un héro!");
            }

        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            PageAcceuil acceuil = new PageAcceuil();
            acceuil.Show();
            this.Close();
        }
    }
}
