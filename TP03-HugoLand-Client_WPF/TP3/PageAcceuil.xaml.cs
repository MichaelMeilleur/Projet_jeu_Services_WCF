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
    /// Interaction logic for PageAcceuil.xaml
    /// </summary>
    public partial class PageAcceuil : Window
    {
        ConnexionClient service = new ConnexionClient();

        public PageAcceuil()
        {
            InitializeComponent();
        }

        private void btnCreationHero_Click(object sender, RoutedEventArgs e)
        {
            CreationHero create = new CreationHero();
            create.Show();
            this.Close();
        }

        private void btnCreationClasse_Click(object sender, RoutedEventArgs e)
        {
            CreationClasse create = new CreationClasse();
            create.Show();
            this.Close();
        }

        private void btnJouer_Click(object sender, RoutedEventArgs e)
        {
            JouerHeros jouer = new JouerHeros();
            jouer.Show();
            this.Close();
        }

        private void btnModifierClasses_Click(object sender, RoutedEventArgs e)
        {
            int role = service.VerifierSiAdmin(Constantes._UserName);

            if (role == 1)
            {
                ModifierClasse modifier = new ModifierClasse();
                modifier.Show();
                this.Close();
            }
            else
                MessageBox.Show("Vous n'êtes pas un admin!");
        }

        private void btnSupprimerHero_Click(object sender, RoutedEventArgs e)
        {
            SupprimerHero supprimer = new SupprimerHero();
            supprimer.Show();
            this.Close();
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
