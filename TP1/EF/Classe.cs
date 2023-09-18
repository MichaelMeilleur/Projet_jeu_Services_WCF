using System;
using System.Collections.Generic;

namespace TP1.EF;
/// <summary>
/// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
/// Description: Classe permettant l'implémentation d'une classe de personnages
/// Date: 2023-02-21
/// </summary>
public partial class Classe
{
    public int Id { get; set; }

    /// <summary>
    /// Le type du héro
    /// </summary>
    public string NomClasse { get; set; } = null!;

    /// <summary>
    /// La description de la classe
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Le ratio appliqué aux dommages physiques (court et longue distance
    /// </summary>
    public int StatBaseStr { get; set; }

    /// <summary>
    /// Le ratio appliqué à la chance de toucher et la chance de coup critique
    /// </summary>
    public int StatBaseDex { get; set; }

    /// <summary>
    /// Le ratio appliqué aux dommages magiques et mana maximum
    /// </summary>
    public int StatBaseInt { get; set; }

    /// <summary>
    /// Le ratio appliqué à la défense et à la vie maximum
    /// </summary>
    public int StatBaseVitalite { get; set; }

    public int MondeId { get; set; }

    public virtual ICollection<Hero> Heroes { get; } = new List<Hero>();

    public virtual Monde Monde { get; set; } = null!;



}
