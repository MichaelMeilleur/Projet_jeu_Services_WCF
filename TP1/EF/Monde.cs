using System;
using System.Collections.Generic;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TP1.EF;
/// <summary>
/// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
/// Description: Classe permettant l'implémentation d'un monde
/// Date: 2023-02-21
/// </summary>
public partial class Monde
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int LimiteX { get; set; }

    public int LimiteY { get; set; }

    public virtual ICollection<Classe> Classes { get; } = new List<Classe>();

    public virtual ICollection<Hero> Heroes { get; } = new List<Hero>();

    public virtual ICollection<Item> Items { get; } = new List<Item>();

    public virtual ICollection<Monstre> Monstres { get; } = new List<Monstre>();

    public virtual ICollection<ObjetMonde> ObjetMondes { get; } = new List<ObjetMonde>();
  
}
