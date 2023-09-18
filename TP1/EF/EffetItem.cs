using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace TP1.EF;

/// <summary>
/// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
/// Description: Classe pour l'implémentation d'un effet sur un item
/// Date: 2023-02-21
/// </summary>

public partial class EffetItem
{
    public int Id { get; set; }

    /// <summary>
    /// Quel item de base
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// Le nombre de points de vie/mana recouvert
    /// </summary>
    public int ValeurEffet { get; set; }

    /// <summary>
    /// Spécifie le type du recouvrement (vie/mana)
    /// </summary>
    public int TypeEffet { get; set; }

    public virtual Item Item { get; set; } = null!;

    /// <summary>
    /// Méthode pour ajouter un effet sur un item
    /// </summary>
    /// <param name="itemid"></param>
    /// <param name="valeurEffet"></param>
    /// <param name="typeEffet"></param>
    
}
