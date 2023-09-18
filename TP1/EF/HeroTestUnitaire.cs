using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe permettant de tester un héro
    /// Date: 2023-02-21
    /// </summary>
    public class HeroTestUnitaire
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester tout d'un héro
        /// Date: 2023-02-21
        /// </summary>
        public void TesterHero()
        {
            TesterCreerHero();
            TesterListerHero();
            TesterModifierHero();
            TesterSupprimerHero();

            // Afficher la liste d'héros
            List<Hero> liste = new List<Hero>();
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                liste = context.Heros.ToList();

            }

            foreach (Hero item in liste)
            {
                Console.WriteLine("Nom: " + item.NomHero + " MondeID: " + item.MondeId);
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permmettant de tester la création d'un héro
        /// Date: 2023-02-21
        /// </summary>
        private void TesterCreerHero()
        {
            var hero = new GestionHero();

           //hero.CreerHero(1, 1, 1, 1, 1021, "Hero Test", 1083);
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la modification d'un héro
        /// Date: 2023-02-21
        /// </summary>
        private void TesterModifierHero()
        {
            var hero = new GestionHero();

            hero.ModifierHero(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, "Hero Test");
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la suppression d'un héro
        /// Date: 2023-02-21
        /// </summary>
        private void TesterSupprimerHero()
        {
            var hero = new GestionHero();
            hero.SupprimerHero(1);
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester le retour d'un liste de héro
        /// Date: 2023-02-21
        /// </summary>
        private void TesterListerHero()
        {
            List<Hero> liste = new List<Hero>();
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                liste = context.Heros.ToList();
            }

            foreach (Hero hero in liste)
            {
                Console.WriteLine($"id Hero: {hero.Id}, Nom: {hero.NomHero}, lvl: {hero.Niveau}, Exp: {hero.Experience}, X: {hero.X}, Y: {hero.Y}, STR: {hero.StatStr}, DEX: {hero.StatDex}, INT: {hero.StatInt}, ID Joueur: {hero.CompteJoueurId}");
            }


        }

    }
}
