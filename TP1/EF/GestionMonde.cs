using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe epermettant de gérer un monde 
    /// Date: 2023-02-21
    /// </summary>
    public class GestionMonde : Monde
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode pour ajouter un monde.
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="description">desciptio du monde</param>
        /// <param name="limiteX">limite max en x</param>
        /// <param name="limiteY">limite max en y</param>
        public void AjouterMonde(string description, int limiteX, int limiteY)
        {
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                Monde monde = new Monde()
                {
                    Description = description,
                    LimiteX = limiteX,
                    LimiteY = limiteY
                };
                context.Mondes.Add(monde);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode pour supprimer un monde
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">id du monde</param>
        public void SupprimerMonde(int id)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Monde monde = context.Mondes.Where(x => x.Id == id).First();
                    context.Mondes.Remove(monde);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur avec le ID");
            }
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode pour modifier un monde
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">id du monde </param>
        /// <param name="description">description</param>
        /// <param name="limiteX">limite max en x</param>
        /// <param name="limiteY">limite max en y</param>
        public void ModifierMonde(int id, string description, int limiteX, int limiteY)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Monde monde = context.Mondes.Where(x => x.Id == id).First();

                    monde.Description = description;
                    monde.LimiteX = limiteX;
                    monde.LimiteY = limiteY;

                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur avec le ID");
            }
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode qui retourne une liste des monde de la BD
        /// Date: 2023-02-21
        /// </summary>
        /// <returns>Liste des mondes dans la BD</returns>
        public List<Monde> ListerMondes()
        {
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                var data = context.Mondes.ToList();

                return data;
            }
        }
        //Retourner un Monde depuis un monde_id
        public Monde GetMonde(int id)
        {
            try
            {
                Monde monde;
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    monde = context.Mondes.Where(x => x.Id == id).First();
                }
                return monde;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur avec le ID");
                return null;
            }

        }
    }
}
