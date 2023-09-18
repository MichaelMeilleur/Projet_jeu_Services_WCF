using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe Permettant de faire la gestion d'un compte de joueur
    /// Date: 2023-02-21
    /// </summary>
    public class GestionCompteJoueur : CompteJoueur
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Methode permettant d'ajouter un Compte de Joueur
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="nomuser">Nom de l'utilisateur</param>
        /// <param name="courriel">courriel de l'utilisateur</param>
        /// <param name="prenom">prenom du joueur</param>
        /// <param name="nom">nom du joueur</param>
        /// <param name="typeuser">type de l'utilisateur</param>
        /// <param name="mdp">mot de passe du joueur</param>
        /// <param name="message">message associé au joueur</param>
        public void AjouterJoueur(string nomuser, string courriel, string prenom, string nom, int typeuser, string mdp, string message)
        {
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                context.Database.ExecuteSqlRaw("EXEC CreerCompteJoueur @pNomUtilisateur,@pCourriel,@pPrenom,@pNom,@pTypeUtilisateur,@pMotDePasse,@Message",
                   new SqlParameter("@pNomUtilisateur", nomuser),
                   new SqlParameter("@pCourriel", courriel),
                   new SqlParameter("@pPrenom", prenom),
                   new SqlParameter("@pNom", nom),
                   new SqlParameter("@pTypeUtilisateur", typeuser),
                   new SqlParameter("@pMotDePasse", mdp),
                   new SqlParameter("@Message", message)
                   );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Trouve le id pour un username passé en paramètre.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int TrouverID(string username)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    CompteJoueur joueur = context.CompteJoueurs.Where(x => x.NomJoueur == username).First();
                    return joueur.Id;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Trouve le id pour un username passé en paramètre.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int VerifierSiAdmin(string username)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    CompteJoueur joueur = context.CompteJoueurs.Where(x => x.NomJoueur == username).First();
                    return joueur.TypeUtilisateur;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de supprimer un Compte de joueur
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">id du joueur</param>
        public void SupprimerJoueur(int id)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    CompteJoueur joueur = context.CompteJoueurs.Where(x => x.Id == id).First();
                    context.CompteJoueurs.Remove(joueur);
                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur pour supprimer un joueur!");
            }
        }

        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de Modifier les informations d'un compte joueur
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nomjoueur"></param>
        /// <param name="courriel"></param>
        /// <param name="prenom"></param>
        /// <param name="nom"></param>
        /// <param name="type"></param>
        public void ModifierJoueur(int id, string nomjoueur, string courriel, string prenom, string nom, int type)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    CompteJoueur joueur = context.CompteJoueurs.Where(x => x.Id == id).First();

                    joueur.NomJoueur = nomjoueur;
                    joueur.Courriel = courriel;
                    joueur.Prenom = prenom;
                    joueur.Nom = nom;
                    joueur.TypeUtilisateur = type;

                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur pour modifier un joueur!");
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de valider la connection d'un joueur.
        /// Date: 2023-02-21
        /// </summary>
        public bool ValiderConnectionJoueur(string user, string mdp)
        {
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {

                var messageParam = new SqlParameter("@message", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };


                SqlParameter param1 = new SqlParameter("@pNomJoueur", user);
                SqlParameter param2 = new SqlParameter("@pMotDePasse", mdp);

                var result = context.Database.ExecuteSqlRaw("EXEC Connexion @pNomJoueur, @pMotDePasse,@Message OUTPUT ",
                     param1, param2, messageParam);


                var message = messageParam.Value as string;

                if (message == "SUCCESS")
                    return true;
                else
                    return false;
            }
        }
    }
}
