using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe servant à la gestion d'une classe d'un personnage
    /// Date: 2023-02-21
    /// </summary>
    public class GestionClasse : Classe
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant d'ajouter une classe
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="nom">nom de la classe</param>
        /// <param name="description">description de la classe</param>
        /// <param name="statStr">points de force</param>
        /// <param name="statDex">points de dextérité</param>
        /// <param name="statInt">points d'intelligence</param>
        /// <param name="statVit">points de vitalité</param>
        /// <param name="mondeId">Id du monde</param>
        public void AjouterClasse(string nom, string description, int statStr, int statDex, int statInt, int statVit, int mondeId)
        {
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                try
                {
                    Classe classe = new Classe()
                    {
                        NomClasse = nom,
                        Description = description,
                        StatBaseStr = statStr,
                        StatBaseDex = statDex,
                        StatBaseInt = statInt,
                        StatBaseVitalite = statVit,
                        MondeId = mondeId
                    };
                    context.Classes.Add(classe);
                    context.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("Erreur lors de l'ajout d'une classe");
                }
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méhode permettant de Modifier une classe
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">id de la classe</param>
        /// <param name="nom">nom de la classe</param>
        /// <param name="description">description de la classe</param>
        /// <param name="statStr">points de force</param>
        /// <param name="statDex">points de dextérité</param>
        /// <param name="statInt">points d'intelligence</param>
        /// <param name="statVit">points de vitalité</param>
        /// <param name="mondeId">id du monde</param>
        public void ModifierClasse(int id, string nom, string description, int statStr, int statDex, int statInt, int statVit, int mondeId)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Classe classe = context.Classes.Where(x => x.Id == id).First();

                    classe.NomClasse = nom;
                    classe.Description = description;
                    classe.StatBaseStr = statStr;
                    classe.StatBaseDex = statDex;
                    classe.StatBaseInt = statInt;
                    classe.MondeId = mondeId;
                    classe.StatBaseVitalite = statVit;

                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur lors de la modification d'une classe");
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de supprimer la classe
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">id de la classe</param>
        public void SupprimerClasse(int id)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Classe classe = context.Classes.Where(x => x.Id == id).First();
                    context.Classes.Remove(classe);
                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur lors de la supression d'une classe");
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de retourner une classe d'un héro
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="heroId">id du héro</param>
        /// <returns></returns>
        public Classe TrouverClasseHero(int heroId)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Hero hero = context.Heros.Where(x => x.Id == heroId).First();
                    return hero.Classe;
                }
            }
            catch
            {
                Console.WriteLine("Erreur lors de la recherche d'une classe");
                return null;
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de retourner toutes les classes pour un Monde
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="mondeId">id du monde</param>
        /// <returns></returns>
        public ICollection<Classe> ListerClassePourMonde(int mondeId)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    ICollection<Classe> classes = context.Classes.Where(x => x.MondeId == mondeId).ToList();
                    return classes;
                }
            }
            catch
            {
                Console.WriteLine("Erreur avec la liste des classe");
                return null;
            }
        }

        /// <summary>
        /// Auteurs: Michael Meilleur
        /// Description: Méthode qui retourne une liste des classes
        /// Date: 2023-04-20
        /// </summary>
        /// <returns>Liste des classes dans la BD</returns>
        public List<Classe> ListerClasses()
        {
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                var data = context.Classes.ToList();

                return data;
            }
        }
    }
}
