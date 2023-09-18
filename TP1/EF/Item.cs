using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace TP1.EF;
/// <summary>
/// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
/// Description: Classe permettant l'implémentation d'un Item
/// Date: 2023-02-21
/// </summary>
public partial class Item
{
    public int Id { get; set; }

    /// <summary>
    /// Nom de l&apos;item
    /// </summary>
    public string Nom { get; set; } = null!;

    /// <summary>
    /// Sa description
    /// </summary>
    public string Description { get; set; } = null!;

    public int? X { get; set; }

    public int? Y { get; set; }

    public int MondeId { get; set; }

    public int? ImageId { get; set; }

    public int? IdHero { get; set; }

    public virtual ICollection<EffetItem> EffetItems { get; } = new List<EffetItem>();

    public virtual Hero? IdHeroNavigation { get; set; }

    public virtual ICollection<InventaireHero> InventaireHeroes { get; } = new List<InventaireHero>();

    public virtual Monde Monde { get; set; } = null!;
    
}
