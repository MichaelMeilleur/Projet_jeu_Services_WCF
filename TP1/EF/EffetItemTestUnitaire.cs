using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe permettant de tester un Item
    /// Date: 2023-02-21
    /// </summary>
    internal class EffetItemTestUnitaire
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester tous d'un effet sur un item
        /// Date: 2023-02-21
        /// </summary>
        public void TesterEffetItem() 
        {
            TesterAjouterEffet();
            TesterSupprimerEffet();
            TesterModifierEffet();

            // Afficher la liste d'effets
            List<EffetItem> liste = new List<EffetItem>();
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                liste = context.EffetItems.ToList();

            }

            foreach (EffetItem item in liste)
            {
                Console.WriteLine("ItemID: " + item.ItemId + " Type: " + item.TypeEffet + "Valeur: " + item.ValeurEffet);
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester l'ajout d'un Item
        /// Date: 2023-02-21
        /// </summary>
        public void TesterAjouterEffet() 
        {
            var effet = new GestionEffetItem();

            effet.AjouterEffet(7, 1, 1);
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Métthode permettant de tester la suppression d'un Item
        /// Date: 2023-02-21
        /// </summary>
        public void TesterSupprimerEffet()
        {
            var effet = new GestionEffetItem();

            effet.SupprimerEffet(25,2);
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la Modification d'un item
        /// Date: 2023-02-21
        /// </summary>
        public void TesterModifierEffet()
        {
            var effet = new GestionEffetItem();

            effet.ModifierEffet(25,2,2,2);
        }

    }
}
