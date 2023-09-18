using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.EF
{
    /// <summary>
    /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
    /// Description: Classe permettant la gestion d'un objet dans le monde
    /// Date: 2023-02-21
    /// </summary>
    public class GestionObjetMonde
    {
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant d'ajouter un objet du monde
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="mondeid">Id du monde</param>
        /// <param name="typeobjet">typer de l'objet</param>
        /// <param name="x">position en x</param>
        /// <param name="y">position en y</param>
        /// <param name="description">description de l'objet</param>
        public void AjouterObjetMonde(int mondeid, int typeobjet, int x, int y, string description)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    ObjetMonde objmonde = new ObjetMonde()
                    {
                        Description = description, //Description de l'objet à ajouter
                        TypeObjet = typeobjet, //Exemple: Rocher, fleur etc
                        X = x, //Position en x dans le monde
                        Y = y, //Position en y dans le monde
                        MondeId = mondeid //Monde où ajouter l'objet
                    };

                    context.ObjetMondes.Add(objmonde);
                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur pour ajouter un objetmonde!");
            }


        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de supprimer un objet dans le monde
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="mondeid">ID du monde</param>
        /// <param name="objid">Id de l'objet</param>
        public void SupprimerObjetMonde(int mondeid, int objid)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    ObjetMonde objmonde = context.ObjetMondes.Where(x => x.MondeId == mondeid && x.Id == objid).First();
                    context.ObjetMondes.Remove(objmonde);
                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur pour supprimer un objetmonde!");
            }
        }
        /// <summary>
        /// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
        /// Description: Méthode permettant de modifier un objet du monde
        /// Date: 2023-02-21
        /// </summary>
        /// <param name="id">id de l'objet</param>
        /// <param name="mondeid">id du monde</param>
        /// <param name="typeobjet">type de l'objet</param>
        /// <param name="description">description de l'objet</param>
        /// <param name="x">position en x</param>
        /// <param name="y">position en y</param>
        public void ModifierObjetMonde(int id, int mondeid, int typeobjet, string description, int x, int y)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    ObjetMonde objmonde = context.ObjetMondes.Where(x => x.Id == id).First();

                    objmonde.Description = description;
                    objmonde.X = x;
                    objmonde.Y = y;
                    objmonde.TypeObjet = typeobjet;
                    objmonde.MondeId = mondeid;

                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Erreur pour modifier un objetmonde!");
            }
        }

        public List<ObjetMonde>? ListerObjetPourMonde(int id)
        {
            try
            {
                using (_4dbEquipe22023Context context = new _4dbEquipe22023Context())
                {
                    return context.ObjetMondes.Where(x => x.MondeId == id).ToList();

                }

            }
            catch
            {
                Console.WriteLine("Erreur pour lister les objets d'un monde!");
            }

            return null;
        }
    }
}
