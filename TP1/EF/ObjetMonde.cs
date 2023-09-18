using System;
using System.Collections.Generic;
namespace TP1.EF;
/// <summary>
/// Auteurs: Michael Meilleur, Gabriel Bruneau, Théo Duford
/// Description: Classe permettant l'implémentaiton d'un objet du monde
/// Date: 2023-02-21
/// </summary>
public partial class ObjetMonde
{
    public int Id { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public string Description { get; set; } = null!;

    public int TypeObjet { get; set; }

    public int MondeId { get; set; }

    public virtual Monde Monde { get; set; } = null!;


}
