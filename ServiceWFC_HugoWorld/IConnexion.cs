using ServiceWFC_HugoWorld.DTO;
using TP1.EF;

namespace ServiceWFC_HugoWorld
{
    /// <summary>
    /// Service qui implémente une vérification de connexion
    /// </summary>

    [ServiceContract]
    public interface IConnexion
    {
        [OperationContract]
        bool Login(string username, string password);

        [OperationContract]
        void CreerHero(int str, int dex, int intel, int vit, int classeId, string nomHero,int mondeid,int joueurid);

        [OperationContract]
        ICollection<Classe> ListerClassePourMonde(int mondeID);

        [OperationContract]
        void CreeClasse(string nom, string description, int statStr, int statDex, int statInt, int statVit, int mondeId);

        [OperationContract]
        int TrouverID(string username);

        [OperationContract]
        Monde TrouverObjetMonde(int monde_id);

        [OperationContract]
        int VerifierSiAdmin(string username);

        [OperationContract]
        ICollection<Monde> ListerMonde();

        [OperationContract]
        ICollection<Classe> ListerClasses();

        [OperationContract]
        ICollection<Hero> ListerHeros(int id);

        [OperationContract]
        void SupprimerHero(int id);

        [OperationContract]
        void SupprimerClasse(int id);

        [OperationContract]
        void ModifierClasse(int id, string nom, string description, int force, int dex, int intel, int vitalite, int mondeid);

        [OperationContract]
        List<ObjetMonde>? ListerObjetPourMonde(int id);

        [OperationContract]
        Hero RetournerHero(int id);

        [OperationContract]
        void ModifierStatutHero(int id);

        [OperationContract]
        void ModifierPositionHeroMonde(int _hero_id, int _x, int _y);

        [OperationContract]
        List<Item> ListerItemsPourMonde(int monde_id);
        [OperationContract]
        void ModifierInventaireHero(int idmonde, int itemid, int heroid, int x, int y);
        [OperationContract]
        List<Item> ListerInventaireHero(int _heroid);
        [OperationContract]
        List<Hero> ListerHeroConnecter(int mondeid);

    }
}
