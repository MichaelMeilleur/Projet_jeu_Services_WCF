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
using ServiceConnexion;
using TP3.DAL;

namespace TP3
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnConnecter_Click(object sender, RoutedEventArgs e)
        {
            ConnexionClient service = new ConnexionClient();
            bool connexion;

            try
            {
                connexion = service.Login(txtUsername.Text, txtPassword.Text);

                if (connexion)
                {
                    Constantes._UserName = txtUsername.Text;
                    PageAcceuil page = new PageAcceuil();
                    page.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la connection!");
                }
            }
            catch
            {
                MessageBox.Show("Erreur lors de la connection!");
            }

        }
    }
}
