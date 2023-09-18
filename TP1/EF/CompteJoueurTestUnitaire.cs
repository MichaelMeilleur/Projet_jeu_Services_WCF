using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe permettant de tester un compte de joueur
    /// Date: 2023-02-21
    /// </summary>
    internal class CompteJoueurTestUnitaire
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester tout d'un compte de joueur
        /// Date: 2023-02-21
        /// </summary>
        public void TesterCompte() 
        {
            TesterAjouterJoueur();
            TesterSupprimerJoueur();
            TesterModifierJoueur();

            // Afficher la liste de joueur
            List<CompteJoueur> liste = new List<CompteJoueur>();
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                liste = context.CompteJoueurs.ToList();

            }

            foreach (CompteJoueur item in liste)
            {
                Console.WriteLine("ID: " + item.Id +" Nom: " + item.Nom + " Prenom: " + item.Prenom);
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester l'Ajout d'un compte joueur
        /// Date: 2023-02-21
        /// </summary>
        public void TesterAjouterJoueur() 
        {
            var joueur = new GestionCompteJoueur();

            //joueur.AjouterJoueur("Jean", "jean@gmail.com","Jean", "pierre", 2,"jean2","Test de user");
           
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la suppression d'un compte joueur
        /// Date: 2023-02-21
        /// </summary>
        public void TesterSupprimerJoueur()
        {
            var joueur = new GestionCompteJoueur();

            joueur.SupprimerJoueur(1);
            Console.WriteLine("Joueur supprimer");
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la modification d'un compte joueur
        /// Date: 2023-02-21
        /// </summary>
        public void TesterModifierJoueur()
        {
            var joueur = new GestionCompteJoueur();

            joueur.ModifierJoueur(1,"Jesus1321", "jesus@gmail.com", "Arthur", "Ouellet",1);

        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la validation de la connection d'un joueur
        /// Date: 2023-02-21
        /// </summary>
        public void TesterValiderConnectionJoueur()
        {
            var joueur = new GestionCompteJoueur();

            //joueur.ValiderConnectionJoueur();
        }
    }
}
