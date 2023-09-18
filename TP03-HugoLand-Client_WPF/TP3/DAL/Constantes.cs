using ServiceConnexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3.DAL
{
    /// <summary>
    /// Classe qui contient des constantes utilisées l'application
    /// </summary>
    public static class Constantes
    {
        public static string _UserName { get; set; }
        public static int ID_hero { get; set; }
        public static Hero Hero { get; set; }
        public static int ID_classe { get; set; }
        public static int ID_monde { get; set; }
        public static Monde monde { get; set; }
    }
}
