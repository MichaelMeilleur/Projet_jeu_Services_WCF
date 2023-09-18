using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe permettant de tester un monde
    /// Date: 2023-02-21
    /// </summary>
    public class MondeTestUnitaire
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester tout d'un monde
        /// Date: 2023-02-21
        /// </summary>
        public void TesterMonde() 
        {
            TesterAjouterMonde();
            TesterSupprimerMonde();
            TesterModifierMonde();
            TesterLister();
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester l'ajout d'un monde
        /// Date: 2023-02-21
        /// </summary>
        public void TesterAjouterMonde() 
        {
            var monde = new GestionMonde();

            monde.AjouterMonde("Test Unitaire", 32, 32);
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la suppression d'un monde
        /// Date: 2023-02-21
        /// </summary>
        public void TesterSupprimerMonde()
        {
            var monde = new GestionMonde();

            monde.SupprimerMonde(21);

            Console.WriteLine("Monde supprimé");
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la modification d'un monde
        /// Date: 2023-02-21
        /// </summary>
        public void TesterModifierMonde()
        {
            var monde = new GestionMonde();

            monde.ModifierMonde(5,"Test modification", 16, 16);

        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettatn de tester le retour de liste des mondes
        /// Date: 2023-02-21
        /// </summary>
        public void TesterLister()
        {
            var monde = new GestionMonde();
            List<Monde> liste = new List<Monde>();  

            liste = monde.ListerMondes();

            foreach (Monde item in liste)
            {
                Console.WriteLine("ID: " + item.Id + " Description: " + item.Description + " LimiteX: " + item.LimiteX + " LimiteY: " + item.LimiteY);
            }
        }

    }
}
