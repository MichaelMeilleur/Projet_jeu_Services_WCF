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
    /// Interaction logic for ConfirmationSupprimerHero.xaml
    /// </summary>
    public partial class ConfirmationSupprimerHero : Window
    {
        ConnexionClient service = new ConnexionClient();

        public ConfirmationSupprimerHero()
        {
            InitializeComponent();
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            SupprimerHero page = new SupprimerHero();
            page.Show();
            this.Close();
        }

        private void btnOui_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                service.SupprimerHero(Constantes.ID_hero);

                MessageBox.Show("Héro supprimé!");

                SupprimerHero hero = new SupprimerHero();
                hero.Show();
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Erreur lors de la suppression d'un héro");
            }

        }
    }
}
