using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe permettant de tester un objet du monde
    /// Date: 2023-02-21
    /// </summary>
    public class ObjetMondeTestUnitaire
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettatn de tester tout d'un objet monde
        /// Date: 2023-02-21
        /// </summary>
        public void TesterObjetMonde()
        {
            TesterAjouterMonde();
            TesterSupprimerMonde();
            TesterModifierMonde();

            // Afficher la liste d'objet
            List<ObjetMonde> liste = new List<ObjetMonde>();
            using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
            {
                liste = context.ObjetMondes.ToList();

            }

            foreach (ObjetMonde item in liste)
            {
                Console.WriteLine("Description: " + item.Description + " MondeID: " + item.MondeId);
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester l'ajout d'un objet monde
        /// Date: 2023-02-21
        /// </summary>
        public void TesterAjouterMonde()
        {
            var objmonde = new GestionObjetMonde();

            objmonde.AjouterObjetMonde(5,1, 32, 32, "Test Unitaire");

            
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la suppression d'un objetMonde
        /// Date: 2023-02-21
        /// </summary>
        public void TesterSupprimerMonde()
        {
            var objmonde = new GestionObjetMonde();

            objmonde.SupprimerObjetMonde(5,3);

            Console.WriteLine("Objet supprimé");
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de tester la modification d'un objet Monde
        /// Date: 2023-02-21
        /// </summary>
        public void TesterModifierMonde()
        {
            var objmonde = new GestionObjetMonde();

            objmonde.ModifierObjetMonde(5, 1,1, "Test modification", 16, 16);
        }
    }
}
