using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TP1.EF;

/// <summary>
/// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
/// Description: Classe permettant l'implémentation d'un compte de joueur
/// Date: 2023-02-21
/// </summary>
public partial class CompteJoueur
{
    public int Id { get; set; }

    /// <summary>
    /// Le nom d&apos;utilisateur pour se connecter
    /// </summary>
    public string NomJoueur { get; set; } = null!;

    /// <summary>
    /// Son adresse email
    /// </summary>
    public string Courriel { get; set; } = null!;

    /// <summary>
    /// Son prénom
    /// </summary>
    public string Prenom { get; set; } = null!;

    /// <summary>
    /// Son nom de famille
    /// </summary>
    public string Nom { get; set; } = null!;

    /// <summary>
    /// Le type de l&apos;utilisateur (admin, régulier)
    /// </summary>
    public int TypeUtilisateur { get; set; }

    public byte[] MotDePasseHash { get; set; } = null!;

    public Guid Salt { get; set; }

    public virtual ICollection<Hero> Heroes { get; } = new List<Hero>();

}
