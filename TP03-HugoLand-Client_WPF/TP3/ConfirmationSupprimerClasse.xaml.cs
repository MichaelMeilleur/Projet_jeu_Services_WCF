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
    /// Interaction logic for ConfirmationSupprimerClasse.xaml
    /// </summary>
    public partial class ConfirmationSupprimerClasse : Window
    {
        ConnexionClient service = new ConnexionClient();

        public ConfirmationSupprimerClasse()
        {
            InitializeComponent();
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            ModifierClasse page = new ModifierClasse();
            page.Show();
            this.Close();
        }

        private void btnConfirmer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                service.SupprimerClasse(Constantes.ID_classe);

                MessageBox.Show("Suppression réussite!");

                ModifierClasse page = new ModifierClasse();
                page.Show();
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Erreur lors de la suppression!");
            }
        }
    }
}
