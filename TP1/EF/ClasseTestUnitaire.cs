using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe servant a faire les tests unitaires pour une classe
    /// Date: 2023-02-21
    /// </summary>
    public class ClasseTestUnitaire
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tout tester pour la classe de classe
        /// Date: 2023-02-21
        /// </summary>
        public void TesterClasse()
        {
            TesterAjouterClasse();
            TesterSupprimerClasse();
            TesterModifierClasse();

            // Afficher la liste des classes
            List<Classe> liste = new List<Classe>();
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                liste = context.Classes.ToList();

            }

            foreach (Classe item in liste)
            {
                Console.WriteLine("Description: " + item.Description + " Nom: " + item.NomClasse);
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester un ajout de classe
        /// Date: 2023-02-21
        /// </summary>
        public void TesterAjouterClasse()
        {
            var classe = new GestionClasse();

            classe.AjouterClasse("Classe Test", "classe de test", 10, 10, 10, 10, 5);
       
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la suppression d'une classe
        /// Date: 2023-02-21
        /// </summary>
        public void TesterSupprimerClasse()
        {
            var classe = new GestionClasse();

            classe.SupprimerClasse(1);

            Console.WriteLine("Classe supprimé");
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la modification d'une classe
        /// Date: 2023-02-21
        /// </summary>
        public void TesterModifierClasse()
        {
            var classe = new GestionClasse();

            classe.ModifierClasse(1, "Classe Modifiée", "classe de test modifiée", 16, 16, 16, 16, 1);
         
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de lister les classes pour un monde
        /// Date: 2023-02-21
        /// </summary>
        public void TesterListerClasse() 
        {
            var classe = new GestionClasse();

            List<Classe> liste = classe.ListerClassePourMonde(1083).ToList();

            foreach (var item in liste)
            {
                Console.WriteLine($"ID: {item.Id}, Classe: {item.NomClasse} - Monde: {item.MondeId}");
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de trouver la classe d'un héro
        /// Date: 2023-02-21
        /// </summary>
        public void TesterTrouverClasseDeHero() 
        {
            var classe = new GestionClasse();

            Console.WriteLine($"Classe: {classe.TrouverClasseHero(1).NomClasse}");
        }
    }
}
