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

namespace TP3
{
    /// <summary>
    /// Interaction logic for CreationClasse.xaml
    /// </summary>
    public partial class CreationClasse : Window
    {
        List<int> MondeIDs = new List<int>();

        ConnexionClient service = new ConnexionClient();

        public CreationClasse()
        {
            InitializeComponent();
            MondeIDs = service.ListerMonde().Select(m => m.Id).ToList();

            cbMonde.ItemsSource = MondeIDs;
        }

        private void btnCréer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                service.CreeClasse(txtNom.Text,txtDescription.Text,int.Parse(txtForce.Text),int.Parse(txtDexterity.Text),int.Parse(txtIntegrite.Text),int.Parse(txtVitalite.Text), int.Parse(cbMonde.SelectedItem.ToString()));
                MessageBox.Show("Classe ajoutée!");

                PageAcceuil page = new PageAcceuil();
                page.Show();
                this.Close();

            }
            catch
            {
                MessageBox.Show("Erreur lors de le création d'une classe!");
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
