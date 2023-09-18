using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe permettant de tester un Item
    /// Date: 2023-02-21
    /// </summary>
    public class ItemTestUnitaire
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester tout d'un Item
        /// Date: 2023-02-21
        /// </summary>
        public void TesterItem()
        {
            TesterAjouterItem();
            TesterSupprimerItem();
            TesterModifierItem();

            // Afficher la liste d'items
            List<Item> liste = new List<Item>();
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                liste = context.Items.ToList();

            }

            foreach (Item item in liste)
            {
                Console.WriteLine("Description: " + item.Description + " MondeID: " + item.MondeId);
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester l'ajout d'un item
        /// Date: 2023-02-21
        /// </summary>
        private void TesterAjouterItem()
        {
            var item = new GestionItem();

            item.AjouterItem("Baguette", "item de test", 16, 16, 4, 1);

        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la suppression d'un item
        /// Date: 2023-02-21
        /// </summary>
        private void TesterSupprimerItem()
        {
            var item = new GestionItem();

            item.SupprimerItem(1, 1);

            Console.WriteLine("Item supprimé et ajouter a l'inventaire du Héro");
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la modification d'un item
        /// Date: 2023-02-21
        /// </summary>
        private void TesterModifierItem()
        {
            var item = new GestionItem();

            item.ModifierItem(1, 1, "Description modifiée", 0, 0, 1, 1);

        }
    }
}
