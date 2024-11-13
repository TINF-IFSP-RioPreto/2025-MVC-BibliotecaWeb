using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using AutorConfiguration = Biblioteca.Models.AutorConfiguration;

namespace Biblioteca;

public class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options)
    {
        // Injeção por construtor
    }
    
    public DbSet<Autor> Autores { get; set; }
    public DbSet<AutorLivro> AutoresLivros { get; set; }
    public DbSet<Editora> Editoras { get; set; }
    public DbSet<Livro> Livros { get; set; }
    public DbSet<OperacaoCompraVenda> OperacoesCompraVenda { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AutorConfiguration());
        modelBuilder.ApplyConfiguration(new AutorLivroConfiguration());
        modelBuilder.ApplyConfiguration(new EditoraConfiguration());
        modelBuilder.ApplyConfiguration(new LivroConfiguration());
        modelBuilder.ApplyConfiguration(new OperacaoCompraVendaConfiguration());
    }
}