using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe servant a faire la gestion d'un héro
    /// Date: 2023-02-21
    /// </summary>
    public class GestionHero : Hero
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de créer et ajouter un Hero a la bd
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="joueurId">ID du compte de joueur</param>
        /// <param name="niveau">Niveau du héro</param>
        /// <param name="exp">point d'expérience</param>
        /// <param name="x">position en x</param>
        /// <param name="y">position en y</param>
        /// <param name="str">points de force</param>
        /// <param name="dex">points de d'extérité</param>
        /// <param name="intel">points d'intelligence</param>
        /// <param name="vit">points de vitalitées</param>
        /// <param name="classeId">ID de la classe du héro</param>
        /// <param name="nomHero">Nom donnée au héro</param>
        public void CreerHero(int str, int dex, int intel, int vit, int classeId, string nomHero, int mondeid, int joueurId)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Hero hero = new Hero()
                    {
                        Niveau = 0,
                        Experience = 0,
                        X = 2,
                        Y = 2,
                        StatStr = str,
                        StatDex = dex,
                        StatInt = intel,
                        StatVitalite = vit,
                        ClasseId = classeId,
                        NomHero = nomHero,
                        EstConnecte = false,
                        MondeId = mondeid,
                        CompteJoueurId = joueurId
                    };
                    context.Heros.Add(hero);
                    context.SaveChanges();
                }

            }
            catch
            {
                Console.WriteLine("Erreur lors de l'ajout d'un héro");
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Modifie un héro dans la bd
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">id du héro a modifier</param>
        /// <param name="joueurId">id du compte du joueur</param>
        /// <param name="niveau">niveau du héro</param>
        /// <param name="exp">point d'expérience du héro</param>
        /// <param name="x">position en x</param>
        /// <param name="y">position en y</param>
        /// <param name="str">points de force</param>
        /// <param name="dex">points de dextérité</param>
        /// <param name="intel">points d'intelligence</param>
        /// <param name="vit">points de vitalite</param>
        /// <param name="classeId">id de la classe du héro</param>
        /// <param name="nomHero">Nom donnée au héro</param>
        public void ModifierHero(int id, int joueurId, int niveau, long exp, int x, int y, int str, int dex, int intel, int vit, int classeId, string nomHero)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Hero hero = context.Heros.Where(x => x.Id == id).First();

                    hero.NomHero = nomHero;
                    hero.StatStr = str;
                    hero.StatDex = dex;
                    hero.StatInt = intel;
                    hero.StatVitalite = vit;
                    hero.X = x;
                    hero.Y = y;
                    hero.Niveau = niveau;
                    hero.CompteJoueurId = joueurId;
                    hero.Experience = exp;
                    hero.ClasseId = classeId;

                }

            }
            catch
            {
                Console.WriteLine("Erreur lors de la modification d'un item");
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de supprimer un héro
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">id du héro a supprimer</param>
        public void SupprimerHero(int id)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Hero hero = context.Heros.Where(x => x.Id == id).First();
                    context.Heros.Remove(hero);
                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur supprimer un hero");
            }

        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Retourne la position en X et Y
        /// Date: 2023-04-21
        /// </summary>
        public Hero RetournerHero(int id)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Hero hero = context.Heros.Where(x => x.Id == id).First();
                    return hero;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de modifier le status de connexion d'un héro
        /// Date: 2023-005-07
        /// </summary>
        /// <param name="id">id du héro</param>
        public void ModifierStatusConnexion(int id)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Hero hero = context.Heros.Where(x => x.Id == id).First();

                    if (hero.EstConnecte == true)
                    {
                        hero.EstConnecte = false;
                        context.SaveChanges();
                    }
                    else
                    {
                        hero.EstConnecte = true;
                        context.SaveChanges();
                    }

                }
            }
            catch
            {
                Console.WriteLine("Erreur dans le changement du statut d'un héro!");
            }
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de modifier la position du dans le monde pour un joueur
        /// Date: 2023-02-21
        /// </summary>
        /// 
        public void ModifierPositionHeroMonde(int _hero_id, int _x, int _y)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Hero hero = context.Heros.Where(x => x.Id == _hero_id).First();
                    hero.X = _x;
                    hero.Y = _y;
                    context.SaveChanges();
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de lister tout les héros d'un joueur
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">Id du compte de joueur</param>
        /// <returns></returns>
        public ICollection<Hero> ListerHeroJoueur(int id)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {

                    ICollection<Hero> heros = context.Heros.Where(x => x.CompteJoueurId == id).ToList();
                    return heros;
                }
            }
            catch
            {
                Console.WriteLine("Erreur avec la liste des héros");
                return null;
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de modifier le contenu de l'inventaire d'un joueur
        /// Date: 2023-05-17
        /// </summary>
        /// <param name="id">Id du compte de joueur</param>
        /// <returns></returns>

        public void ModifierInventaireHero(int idmonde, int itemid, int heroid, int x, int y)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    Item item = context.Items.FirstOrDefault(i => i.Id == itemid && i.MondeId == idmonde && i.X == x && i.Y == y);
                    if (item.IdHero == null)
                    {
                        item.IdHero = heroid;
                    }
                    else
                    {
                        item.IdHero = null;
                    }
                    context.SaveChanges();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de retrouver le contenu de l'inventaire d'un joueur
        /// Date: 2023-05-17
        /// </summary>
        /// <param name="id">Id du compte de joueur</param>
        /// <returns></returns>

        public List<Item> ListerInventaireHero(int _heroid)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    return context.Items.Where(x => x.IdHero == _heroid).ToList();
                }
            }
            catch
            {
            }
            return new List<Item>();
        }

        /// <summary>
        /// Retourne une liste d'héros
        /// </summary>
        /// <param name="_heroid"></param>
        /// <returns></returns>
        public List<Hero> ListerHeroConnecter(int mondeID)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    return context.Heros.Where(x => x.MondeId == mondeID && x.EstConnecte == true).ToList();
                }
            }
            catch
            {
            }
            return new List<Hero>();
        }
    }
}

