using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TP1.EF;

public partial class _4dbEquipe22023Context : DbContext
{
    public _4dbEquipe22023Context()
    {
    }

    public _4dbEquipe22023Context(DbContextOptions<_4dbEquipe22023Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Classe> Classes { get; set; }

    public virtual DbSet<CompteJoueur> CompteJoueurs { get; set; }

    public virtual DbSet<EffetItem> EffetItems { get; set; }

    public virtual DbSet<Hero> Heros { get; set; }

    public virtual DbSet<InventaireHero> InventaireHeroes { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Monde> Mondes { get; set; }

    public virtual DbSet<Monstre> Monstres { get; set; }

    public virtual DbSet<ObjetMonde> ObjetMondes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=172.16.20.230; Initial Catalog=4DB-Equipe2-2023;TrustServerCertificate=True; Persist Security Info=True;User ID=Equipe2;Password=56JHq8", x => x.UseNetTopologySuite());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Classe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC079377D3AE");

            entity.ToTable("Classe");

            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasComment("La description de la classe");
            entity.Property(e => e.NomClasse)
                .HasMaxLength(50)
                .HasComment("Le type du héro");
            entity.Property(e => e.StatBaseDex).HasComment("Le ratio appliqué à la chance de toucher et la chance de coup critique");
            entity.Property(e => e.StatBaseInt).HasComment("Le ratio appliqué aux dommages magiques et mana maximum");
            entity.Property(e => e.StatBaseStr).HasComment("Le ratio appliqué aux dommages physiques (court et longue distance");
            entity.Property(e => e.StatBaseVitalite).HasComment("Le ratio appliqué à la défense et à la vie maximum");

            entity.HasOne(d => d.Monde).WithMany(p => p.Classes)
                .HasForeignKey(d => d.MondeId)
                .HasConstraintName("FK_Classe_Monde");
        });

        modelBuilder.Entity<CompteJoueur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserAcco__3214EC07D4F4D988");

            entity.ToTable("CompteJoueur");

            entity.Property(e => e.Courriel)
                .HasMaxLength(255)
                .HasComment("Son adresse email");
            entity.Property(e => e.MotDePasseHash)
                .HasMaxLength(64)
                .IsFixedLength();
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasComment("Son nom de famille");
            entity.Property(e => e.NomJoueur)
                .HasMaxLength(50)
                .HasComment("Le nom d'utilisateur pour se connecter");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .HasComment("Son prénom");
            entity.Property(e => e.TypeUtilisateur).HasComment("Le type de l'utilisateur (admin, régulier)");
        });

        modelBuilder.Entity<EffetItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recovery__727E83EB3C021980");

            entity.ToTable("EffetItem");

            entity.Property(e => e.ItemId).HasComment("Quel item de base");
            entity.Property(e => e.TypeEffet).HasComment("Spécifie le type du recouvrement (vie/mana)");
            entity.Property(e => e.ValeurEffet).HasComment("Le nombre de points de vie/mana recouvert");

            entity.HasOne(d => d.Item).WithMany(p => p.EffetItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_EffetItem_Item");
        });

        modelBuilder.Entity<Hero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__737584F70DD9A911");

            entity.Property(e => e.Id).HasComment("Le nom du joueur (unique et 16 lettres max)");
            entity.Property(e => e.CompteJoueurId).HasComment("Le compte auquel le joueur est lié");
            entity.Property(e => e.Experience).HasComment("Le nombre de points d'expérience du joueur");
            entity.Property(e => e.Niveau).HasComment("Le niveau du joueur");
            entity.Property(e => e.NomHero).HasMaxLength(50);
            entity.Property(e => e.StatDex).HasComment("Ses points de dextérité");
            entity.Property(e => e.StatInt).HasComment("Ses points d'intelligence");
            entity.Property(e => e.StatStr).HasComment("Ses points de force");
            entity.Property(e => e.StatVitalite).HasComment("Ses points d'endurance");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");

            entity.HasOne(d => d.Classe).WithMany(p => p.Heroes)
                .HasForeignKey(d => d.ClasseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hero_Classe");

            entity.HasOne(d => d.CompteJoueur).WithMany(p => p.Heroes)
                .HasForeignKey(d => d.CompteJoueurId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IsPartOfAccount");

            entity.HasOne(d => d.Monde).WithMany(p => p.Heroes)
                .HasForeignKey(d => d.MondeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hero_Monde");
        });

        modelBuilder.Entity<InventaireHero>(entity =>
        {
            entity.HasKey(e => e.IdInventaireHero).HasName("Inventaire_PK");

            entity.ToTable("InventaireHero");

            entity.Property(e => e.IdInventaireHero).ValueGeneratedNever();
            entity.Property(e => e.IdHero)
                .ValueGeneratedOnAdd()
                .HasComment("Le joueur");

            entity.HasOne(d => d.IdHeroNavigation).WithMany(p => p.InventaireHeroes)
                .HasForeignKey(d => d.IdHero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BelongsToHero");

            entity.HasOne(d => d.Item).WithMany(p => p.InventaireHeroes)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BelongsToItem");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");

            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasComment("Sa description");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasComment("Nom de l'item");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");

            entity.HasOne(d => d.IdHeroNavigation).WithMany(p => p.Items)
                .HasForeignKey(d => d.IdHero)
                .HasConstraintName("FK_Item_Heros");

            entity.HasOne(d => d.Monde).WithMany(p => p.Items)
                .HasForeignKey(d => d.MondeId)
                .HasConstraintName("FK_Item_Monde");
        });

        modelBuilder.Entity<Monde>(entity =>
        {
            entity.ToTable("Monde");
        });

        modelBuilder.Entity<Monstre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Monster__3214EC07E74B9D43");

            entity.ToTable("Monstre");

            entity.Property(e => e.Niveau).HasComment("Le niveau du monstre");
            entity.Property(e => e.Nom).HasComment("Le nom du monstre");
            entity.Property(e => e.StatDmgMax).HasComment("Le nombre de dégats maximum du monstre");
            entity.Property(e => e.StatDmgMin).HasComment("Le nombre de dégats minimum du monstre");
            entity.Property(e => e.StatPv)
                .HasComment("Le nombre de vie de base du monstre")
                .HasColumnName("StatPV");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");

            entity.HasOne(d => d.Monde).WithMany(p => p.Monstres)
                .HasForeignKey(d => d.MondeId)
                .HasConstraintName("FK_Monstre_Monde");
        });

        modelBuilder.Entity<ObjetMonde>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ObjetCarte");

            entity.ToTable("ObjetMonde");

            entity.Property(e => e.Description).HasDefaultValueSql("('tuile')");
            entity.Property(e => e.MondeId).HasDefaultValueSql("((-1))");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");

            entity.HasOne(d => d.Monde).WithMany(p => p.ObjetMondes)
                .HasForeignKey(d => d.MondeId)
                .HasConstraintName("FK_ObjetMonde_Monde");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
