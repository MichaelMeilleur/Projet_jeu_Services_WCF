using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe permettant la gestion d'un item
    /// Date: 2023-02-21
    /// </summary>
    public class GestionItem : Item
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant d'ajouter un item a la bd
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="nom">nom de l'item</param>
        /// <param name="description">description de l'item</param>
        /// <param name="posX">position en x</param>
        /// <param name="posY">position en y</param>
        /// <param name="mondeId">ID du monde</param>
        /// <param name="imageId">ID de l'image associé à l'item</param>
        public void AjouterItem(string nom, string description, int posX, int posY, int mondeId, int imageId)
        {
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                try
                {
                    Item item = new Item
                    {
                        Nom = nom,
                        Description = description,
                        X = posX,
                        Y = posY,
                        IdHero = null,
                        MondeId = mondeId,
                        ImageId = imageId
                    };
                    context.Items.Add(item);
                    context.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("Erreur lors de l'ajout d'un item");
                }
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de Modifier un Item dans la bd
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">id de l'item</param>
        /// <param name="heroId">Id du hero</param>
        /// <param name="description">description du hero</param>
        /// <param name="posX">position en x</param>
        /// <param name="posY">position en y</param>
        /// <param name="mondeId">ID du monde</param>
        /// <param name="imageId">Id de l'image associé</param>
        public void ModifierItem(int id, int heroId, string description, int posX, int posY, int mondeId, int imageId)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Item item = context.Items.Where(x => x.Id == id).First();

                    item.InventaireHeroes.Add(new InventaireHero()
                    {
                        IdHero = heroId,
                        ItemId = id,
                        Item = item
                    });

                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur lors de la modification d'un item");
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de supprimer un item du plan de jeu et l'ajouter a l'inventaire du héro
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">id de l'item</param>
        /// <param name="idHero">Id du hero</param>
        public void SupprimerItem(int id, int idHero)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Item item = context.Items.Where(x => x.Id == id).First();
                    item.X = 0;
                    item.Y = 0;
                    item.IdHero = idHero;

                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur lors de la suppression d'un item");
            }


        }

        public List<Item> ListerItemPourMonde(int monde_id) 
        {
            List<Item> lstItem = new List<Item>();
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    lstItem = context.Items.Where(x => x.MondeId == monde_id).ToList();
                }
                return lstItem;
            }
            catch
            {
                Console.WriteLine("Erreur");
                return lstItem;
            }
        }
    }
}
