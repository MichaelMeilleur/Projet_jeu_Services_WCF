using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe permettant de tester un monstre
    /// Date: 2023-02-21
    /// </summary>
    public class MonstreTestUnitaire
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester tout d'un monstre
        /// Date: 2023-02-21
        /// </summary>
        public void TesterMonstre() 
        {
            TesterAjouterMonstre();
            TesterSupprimerMonstre();
            TesterModifierMonstre();

            // Afficher la listre de monstre
            List<Monstre> liste = new List<Monstre>();
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                liste = context.Monstres.ToList();

            }

            foreach (Monstre monstre in liste)
            {
                Console.WriteLine("Nom: " + monstre.Nom + " Niveau: " + monstre.Niveau);
            }
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Tester la méthode AjouterMonstre
        /// Date: 2023-02-21
        /// </summary>
        public void TesterAjouterMonstre() 
        {
            var monstre = new GestionMonstre();

            monstre.AjouterMonstre("Loup garou du campus", 12, 12, 5, 1);
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Tester la méthode supprimer monstre
        /// Date: 2023-02-21
        /// </summary>
        public void TesterSupprimerMonstre()
        {
            var monstre = new GestionMonstre();

            monstre.SupprimerMonstre(4);

            Console.WriteLine("Monstre supprimé");
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Tester la méthode modifier monstre
        /// Date: 2023-02-21
        /// </summary>
        public void TesterModifierMonstre()
        {
            var monstre = new GestionMonstre();

            monstre.ModifierMonstre(6, "Poule", 2, 2, 3, 10, 10, 5, 5, 1);
        }
    }
}
