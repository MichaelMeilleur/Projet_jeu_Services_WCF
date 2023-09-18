using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace TP1.EF;

/// <summary>
/// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
/// Description: Classe pour l'implémentation d'un monstre
/// Date: 2023-02-21
/// </summary>

public partial class Monstre
{
    public int Id { get; set; }

    /// <summary>
    /// Le nom du monstre
    /// </summary>
    public string Nom { get; set; } = null!;

    /// <summary>
    /// Le niveau du monstre
    /// </summary>
    public int Niveau { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    /// <summary>
    /// Le nombre de vie de base du monstre
    /// </summary>
    public int StatPv { get; set; }

    /// <summary>
    /// Le nombre de dégats minimum du monstre
    /// </summary>
    public float StatDmgMin { get; set; }

    /// <summary>
    /// Le nombre de dégats maximum du monstre
    /// </summary>
    public float StatDmgMax { get; set; }

    public int MondeId { get; set; }

    public int? ImageId { get; set; }

    public virtual Monde Monde { get; set; } = null!;

    
}
