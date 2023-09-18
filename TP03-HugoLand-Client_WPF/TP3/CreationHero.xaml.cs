using ServiceConnexion;
using System;
using System.Collections.Generic;
using System.IO.Ports;
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
    /// Interaction logic for CreationHero.xaml
    /// </summary>
    public partial class CreationHero : Window
    {
        public int ForBase { get; set; } = 0;
        public int IntBase { get; set; } = 0;
        public int VitBase { get; set; } = 0;
        public int DexBase { get; set; } = 0;

        public int ForClasse { get; set; } = 0;
        public int IntClasse { get; set; } = 0;
        public int VitClasse { get; set; } = 0;
        public int DexClasse { get; set; } = 0;

        List<int> MondeIDs = new List<int>();
        List<Classe> Classes = new List<Classe>();

        ConnexionClient service = new ConnexionClient();

        public CreationHero()
        {
            InitializeComponent();
            MondeIDs = service.ListerMonde().Select(m => m.Id).ToList();

            cbxMondeID.ItemsSource = MondeIDs;

            GenererStats();
            AfficherStats();

            if (MondeIDs.Count > 0)
                cbxMondeID.IsEnabled = true;
            else
                cbxMondeID.IsEnabled = false;
        }

        private void btnCreationJoueur_Click(object sender, RoutedEventArgs e)
        {
            int idjoueur = service.TrouverID(Constantes._UserName);

            try
            {
                if (cbxClasseID.SelectedItem == null || cbxMondeID.SelectedItem == null || txtNomHero.Text == "")
                    throw new Exception();

                service.CreerHero(int.Parse(lblForce.Content.ToString()), int.Parse(lblDexterite.Content.ToString()), int.Parse(lblIntelligence.Content.ToString()), int.Parse(lblVitalite.Content.ToString()), int.Parse(cbxClasseID.SelectedItem.ToString()), txtNomHero.Text, int.Parse(cbxMondeID.SelectedItem.ToString()),idjoueur);
                MessageBox.Show("Héro ajouté!");

                PageAcceuil page = new PageAcceuil();
                page.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Erreur lors de le création d'un héro!");
            }
        }

        private void GenererStats()
        {
            Random rnd = new Random();

            ForBase = rnd.Next(5, 21);
            IntBase = rnd.Next(5, 21);
            DexBase = rnd.Next(5, 21);
            VitBase = rnd.Next(2, 11);
        }
        private void AfficherStats()
        {
            lblForce.Content = ForBase + ForClasse;
            lblDexterite.Content = DexBase + DexClasse;
            lblIntelligence.Content = IntBase + IntClasse;
            lblVitalite.Content = VitBase + VitClasse;
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            PageAcceuil page = new PageAcceuil();

            page.Show();
            this.Close();
        }

        private void cbxMondeID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idSelected = int.Parse(cbxMondeID.SelectedItem.ToString());
            Classes = service.ListerClassePourMonde(idSelected).ToList();

            cbxClasseID.ItemsSource = Classes.Select(x => x.Id);

            if (Classes.Count > 0)
                cbxClasseID.IsEnabled = true;
            else
                cbxClasseID.IsEnabled = false;
        }

        private void btnRegenererStats_Click(object sender, RoutedEventArgs e)
        {
            GenererStats();
            AfficherStats();
        }

        private void cbxClasseID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Classe selectedClass = Classes.Where(x => x.Id == int.Parse(cbxClasseID.SelectedItem.ToString())).FirstOrDefault();

            ForClasse = selectedClass.StatBaseStr;
            IntClasse = selectedClass.StatBaseInt;
            VitClasse = selectedClass.StatBaseVitalite;
            DexClasse = selectedClass.StatBaseDex;

            AfficherStats();
        }
    }
}
