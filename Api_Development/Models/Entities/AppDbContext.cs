using System;
using System.Collections.Generic;
using Api_Development.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api_Development.Models.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }
    public virtual DbSet<Dificuldade> Dificuldades { get; set; }
    public virtual DbSet<Regiao> Regioes { get; set; }
    public virtual DbSet<Caminhada> Caminhadas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar Primary Key da Caminhada


        base.OnModelCreating(modelBuilder);
        //Seed Data for Difficulty
        modelBuilder.Entity<Dificuldade>().HasData(
            new Dificuldade()
            {
                DificuldadeId = Guid.Parse("d1bfbf8e-9c3a-4c5e-9a1b-1a2b3c4d5e6f"),
                Nome = "Fácil"
            },
            new Dificuldade()
            {
                DificuldadeId = Guid.Parse("e2c1a9f7-8b4d-4f6e-9b2c-2b3c4d5e6f70"),
                Nome = "Médio"
            },
            new Dificuldade()
            {
                DificuldadeId = Guid.Parse("f3d2b8c6-7a5e-4a7f-9c3d-3c4d5e6f7a8b"),
                Nome = "Difícil"
            }
        );
        //Seed Data for Region
        modelBuilder.Entity<Regiao>().HasData(
                       new Regiao()
            {
                RegiaoId = Guid.Parse("a1b2c3d4-e5f6-4a8b-9c0d-1e2f3a4b5c6d"),
                Nome = "Norte",
                Codigo = "Nor",
                ImagemRegiaoUrl = "https://example.com/images/north.jpg"
            },
            new Regiao()
            {
                RegiaoId = Guid.Parse("b2c3d4e5-f6a7-4b9c-0d1e-2f3a4b5c6d7e"),
                Nome = "Sul",
                Codigo = "Sul",
                ImagemRegiaoUrl = "https://example.com/images/south.jpg"
            },
            new Regiao()
            {
                RegiaoId = Guid.Parse("c3d4e5f6-a7b8-4c0d-1e2f-3a4b5c6d7e8f"),
                Nome = "Oeste",
                Codigo = "Oes",
                ImagemRegiaoUrl = "https://example.com/images/East.jpg"
            },
            new Regiao()
            {
                RegiaoId = Guid.Parse("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"),
                Nome = "Este",
                Codigo = "Est",
                ImagemRegiaoUrl = "https://example.com/images/West.jpg"
            }
        );
    }


}
