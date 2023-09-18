using System;
using System.Collections.Generic;

namespace TP1.EF;
/// <summary>
/// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
/// Description: Classee permettant l'implémenttation d'un héro
/// Date: 2023-02-21
/// </summary>
public partial class Hero
{
    /// <summary>
    /// Le nom du joueur (unique et 16 lettres max)
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Le compte auquel le joueur est lié
    /// </summary>
    public int CompteJoueurId { get; set; }

    /// <summary>
    /// Le niveau du joueur
    /// </summary>
    public int Niveau { get; set; }

    /// <summary>
    /// Le nombre de points d&apos;expérience du joueur
    /// </summary>
    public long Experience { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    /// <summary>
    /// Ses points de force
    /// </summary>
    public int StatStr { get; set; }

    /// <summary>
    /// Ses points de dextérité
    /// </summary>
    public int StatDex { get; set; }

    /// <summary>
    /// Ses points d&apos;intelligence
    /// </summary>
    public int StatInt { get; set; }

    /// <summary>
    /// Ses points d&apos;endurance
    /// </summary>
    public int StatVitalite { get; set; }

    public int MondeId { get; set; }

    public int ClasseId { get; set; }

    public string NomHero { get; set; } = null!;

    public bool EstConnecte { get; set; }

    public virtual Classe Classe { get; set; } = null!;

    public virtual CompteJoueur CompteJoueur { get; set; } = null!;

    public virtual ICollection<InventaireHero> InventaireHeroes { get; } = new List<InventaireHero>();

    public virtual ICollection<Item> Items { get; } = new List<Item>();

    public virtual Monde Monde { get; set; } = null!;
    
}
