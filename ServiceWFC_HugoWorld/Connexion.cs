using CoreWCF;
using System;
using System.Runtime.Serialization;
using TP1.EF;
using TP1;
using ServiceWFC_HugoWorld.DTO;

namespace ServiceWFC_HugoWorld
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Dufort
    /// Description : Implémentation des méthodes en lien avec le service
    /// Date : 2023-04-17
    /// </summary>
    public class Connexion : IConnexion
    {
        bool IConnexion.Login(string username, string password)
        {
            GestionCompteJoueur gestion = new GestionCompteJoueur();

            bool connexion = false;

            connexion = gestion.ValiderConnectionJoueur(username, password);

            return connexion;
        }

        void IConnexion.CreerHero(int str, int dex, int intel, int vit, int classeId, string nomHero, int mondeid, int joueurid)
        {
            GestionHero gestion = new GestionHero();

            gestion.CreerHero(str, dex, intel, vit, classeId, nomHero, mondeid, joueurid);
        }

        int IConnexion.TrouverID(string username)
        {
            GestionCompteJoueur gestion = new GestionCompteJoueur();

            return gestion.TrouverID(username);
        }

        int IConnexion.VerifierSiAdmin(string username)
        {
            GestionCompteJoueur gestion = new GestionCompteJoueur();

            return gestion.VerifierSiAdmin(username);
        }

        ICollection<Hero> IConnexion.ListerHeros(int id)
        {
            GestionHero gestion = new GestionHero();

            return gestion.ListerHeroJoueur(id);
        }

        void IConnexion.CreeClasse(string nom, string description, int statStr, int statDex, int statInt, int statVit, int mondeId)
        {
            GestionClasse gestion = new GestionClasse();

            gestion.AjouterClasse(nom, description, statStr, statDex, statInt, statVit, mondeId);
        }

        ICollection<Classe> IConnexion.ListerClassePourMonde(int mondeID)
        {
            GestionClasse gestion = new GestionClasse();

            return gestion.ListerClassePourMonde(mondeID);
        }

        ICollection<Monde> IConnexion.ListerMonde()
        {
            GestionMonde gestion = new GestionMonde();

            return gestion.ListerMondes();
        }

        ICollection<Classe> IConnexion.ListerClasses()
        {
            GestionClasse gestion = new GestionClasse();

            return gestion.ListerClasses();
        }

        void IConnexion.SupprimerHero(int id)
        {
            GestionHero gestionHero = new GestionHero();

            gestionHero.SupprimerHero(id);
        }

        void IConnexion.SupprimerClasse(int id)
        {
            GestionClasse gestion = new GestionClasse();

            gestion.SupprimerClasse(id);
        }

        void IConnexion.ModifierClasse(int id, string nom, string description, int force, int dex, int intel, int vitalite, int mondeid)
        {
            GestionClasse gestion = new GestionClasse();

            gestion.ModifierClasse(id, nom, description, force, dex, intel, vitalite, mondeid);
        }

        Monde IConnexion.TrouverObjetMonde(int monde_id)
        {
            GestionMonde gestion = new GestionMonde();

            return gestion.GetMonde(monde_id);
        }

        List<ObjetMonde>? IConnexion.ListerObjetPourMonde(int id)
        {
            GestionObjetMonde gestion = new GestionObjetMonde();

            return gestion.ListerObjetPourMonde(id);
        }

        Hero IConnexion.RetournerHero(int id)
        {
            GestionHero gestion = new GestionHero();

            return gestion.RetournerHero(id);
        }

        void IConnexion.ModifierPositionHeroMonde(int _hero_id, int _x, int _y)
        {
            GestionHero gestion = new GestionHero();

            gestion.ModifierPositionHeroMonde(_hero_id, _x, _y);
        }

        void IConnexion.ModifierStatutHero(int id)
        {
            GestionHero gestion = new GestionHero();

            gestion.ModifierStatusConnexion(id);
        }

        List<Item> IConnexion.ListerItemsPourMonde(int monde_id)
        {
            GestionItem gestion = new GestionItem();

            return gestion.ListerItemPourMonde(monde_id);
        }
        void IConnexion.ModifierInventaireHero(int idmonde, int itemid, int heroid, int x, int y)
        {
            GestionHero gestion = new GestionHero();

            gestion.ModifierInventaireHero(idmonde,itemid, heroid,  x, y);
        }
        List<Item> IConnexion.ListerInventaireHero(int _heroid)
        {
            GestionHero gestion = new GestionHero();

            return gestion.ListerInventaireHero(_heroid);
        }
        List<Hero> IConnexion.ListerHeroConnecter(int mondeid)
        {
            GestionHero gestion = new GestionHero();

            return gestion.ListerHeroConnecter(mondeid);
        }
    }
}
