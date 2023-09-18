using ServiceConnexion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ModifierClasse.xaml
    /// </summary>
    public partial class ModifierClasse : Window
    {
        private CollectionViewSource? _classeViewSource = null;
        private List<Classe>? _classes = null;
        ConnexionClient service = new ConnexionClient();

        public ModifierClasse()
        {
            InitializeComponent();
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            PageAcceuil page = new PageAcceuil();

            page.Show();
            this.Close();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (txtID.Text != "")
            {
                Constantes.ID_classe = int.Parse(txtID.Text);

                ConfirmationSupprimerClasse page = new ConfirmationSupprimerClasse();
                page.Show();
                this.Close();
            }
            else
                MessageBox.Show("Veuillez sélectionner une classe!");
        }

        private void btnSauvegarder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                service.ModifierClasse(int.Parse(txtID.Text), txtNomClasse.Text, txtDescription.Text, int.Parse(txtForce.Text), int.Parse(txtDex.Text), int.Parse(txtIntelligence.Text), int.Parse(txtVitalite.Text), int.Parse(txtIDMonde.Text));
                MessageBox.Show("Modifications sauvegardés!");
            }
            catch
            {
                MessageBox.Show("Erreur lors de la sauvegarde!");
            }
        }

        private void btnDernière_Click(object sender, RoutedEventArgs e)
        {
            if (_classeViewSource != null)
                _classeViewSource.View.MoveCurrentToLast();
        }

        private void btnSuivante_Click(object sender, RoutedEventArgs e)
        {
            if (_classeViewSource != null)
                _classeViewSource.View.MoveCurrentToNext();
        }

        private void btnPrécédente_Click(object sender, RoutedEventArgs e)
        {
            if (_classeViewSource != null)
                _classeViewSource.View.MoveCurrentToPrevious();
        }

        private void btnPremier_Click(object sender, RoutedEventArgs e)
        {
            if (_classeViewSource != null)
                _classeViewSource.View.MoveCurrentToFirst();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtID.IsEnabled = false;
            txtIDMonde.IsEnabled = false;

            _classeViewSource = (CollectionViewSource)this.FindResource("classeViewSource");
            _classes = service.ListerClasses();

            _classeViewSource.Source = _classes;
            _classeViewSource.View.MoveCurrentToFirst();
        }
    }
}
