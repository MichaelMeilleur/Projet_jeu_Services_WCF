using System;
using System.Collections.Generic;

namespace TP1.EF;

/// <summary>
/// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
/// Description: Classe permettant l'implémentation de l'inventaire du héro
/// Date: 2023-02-21
/// </summary>
public partial class InventaireHero
{
    public int IdInventaireHero { get; set; }

    /// <summary>
    /// Le joueur
    /// </summary>
    public int IdHero { get; set; }

    public int ItemId { get; set; }

    public virtual Hero IdHeroNavigation { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
