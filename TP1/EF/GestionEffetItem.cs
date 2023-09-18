using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe permettant la gestion des effets des items
    /// Date: 2023-02-21
    /// </summary>
    public class GestionEffetItem : EffetItem
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Ajouter un effet dans la bd
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="itemid">id de l'item</param>
        /// <param name="valeurEffet">valeur de l'effet</param>
        /// <param name="typeEffet">type de l'effet a ajouter</param>
        public void AjouterEffet(int itemid, int valeurEffet, int typeEffet)
        {
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                try
                {
                    EffetItem effet = new EffetItem()
                    {
                        ItemId = itemid,
                        ValeurEffet = valeurEffet,
                        TypeEffet = typeEffet
                    };
                    context.EffetItems.Add(effet);
                    context.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("Erreur lors de l'ajout d'un effet");
                }
            }
        }

        /// <summary>
        /// Méthode pour supprimer un effet
        /// </summary>
        /// <param name="effetId">ID de l'effet</param>
        /// <param name="itemId">ID de l'item</param>
        public void SupprimerEffet(int effetId, int itemId)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    EffetItem effetItem = context.EffetItems.Where(x => x.Id == effetId && x.ItemId == itemId).First();
                    context.EffetItems.Remove(effetItem);
                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur lors de la suppression d'un effet");
            }
        }

        /// <summary>
        /// Méthode pour modifier un effet
        /// </summary>
        /// <param name="effetId">ID de l'effet</param>
        /// <param name="itemId">ID de l'item</param>
        /// <param name="valeurEffet">valeur de l'effet</param>
        /// <param name="typeEffet">type de l'effet</param>
        public void ModifierEffet(int effetId, int itemId, int valeurEffet, int typeEffet)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    EffetItem effetItem = context.EffetItems.Where(x => x.Id == effetId && x.ItemId == itemId).First();

                    effetItem.ValeurEffet = valeurEffet;
                    effetItem.TypeEffet = typeEffet;
                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur pour modifier un effet");
            }
        }
    }
}
