using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    public class GestionMonstre : Monstre
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode pour ajouter un monstre
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="nom">nom du monstre</param>
        /// <param name="x">position en x</param>
        /// <param name="y">position en y</param>
        /// <param name="MondeId">ID du monde</param>
        /// <param name="ImageId">Id de l'image associé</param>
        public void AjouterMonstre(string nom, int x, int y, int MondeId, int ImageId)
        {
            Random random = new Random();

            int niveau = random.Next(1, 100);
            int vie = random.Next(20, 100);
            float statDmgMin = random.Next(10, 20);
            float statDmgMax = random.Next(30, 60);
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Monstre monstre = new Monstre()
                    {
                        Nom = nom,
                        X = x,
                        Y = y,
                        StatPv = vie,
                        StatDmgMin = statDmgMin,
                        StatDmgMax = statDmgMax,
                        MondeId = MondeId,
                        ImageId = ImageId,
                        Niveau = niveau
                    };
                    context.Monstres.Add(monstre);
                    context.SaveChanges();
                }
            }
            catch {}
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode pour supprimer un monstre
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">id du monstre</param>
        public void SupprimerMonstre(int id)
        {

            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                try
                {
                    Monstre monstre = context.Monstres.Where(x => x.Id == id).First();
                    context.Monstres.Remove(monstre);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur avec le ID");
                }

            }
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode pour modifier un monstre
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">id du monstre</param>
        /// <param name="nom">nom du monstre</param>
        /// <param name="niveau">niveau du monstre</param>
        /// <param name="x">position en x du monstre</param>
        /// <param name="y">position en y du monstre</param>
        /// <param name="vie">points de vie</param>
        /// <param name="dmgmax">dégat maximum</param>
        /// <param name="dmgmin">dégat minimum</param>
        /// <param name="mondeId">Id du monde</param>
        /// <param name="imageId">Id dee l'image</param>
        public void ModifierMonstre(int id, string nom, int niveau, int x, int y, int vie, float dmgmax, float dmgmin, int mondeId, int imageId)
        {
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                try
                {
                    Monstre monstre = context.Monstres.Where(x => x.Id == id).First();

                    monstre.Nom = nom;
                    monstre.Niveau = niveau;
                    monstre.X = x;
                    monstre.Y = y;
                    monstre.StatPv = vie;
                    monstre.StatDmgMax = dmgmax;
                    monstre.StatDmgMin = dmgmin;
                    monstre.MondeId = mondeId;
                    monstre.ImageId = imageId;

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur avec le ID");
                }
            }
        }
    }
}
