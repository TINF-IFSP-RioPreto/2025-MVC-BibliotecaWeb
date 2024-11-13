using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Models;

public class Autor
{
    public int AutorID { get; set; }
    public string AutorNome { get; set; }
    public DateOnly? AutorDataNascimento { get; set; }
    public string? AutorEmail { get; set; }
    public ICollection<AutorLivro> LivrosDoAutor { get; set; }
}

public class AutorConfiguration : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.HasKey(p => p.AutorID);
        builder.HasIndex(p => p.AutorNome);
        builder.Property(p => p.AutorNome).HasMaxLength(80).IsRequired();
        builder.Property(p => p.AutorEmail).HasMaxLength(80);
        builder.Property(p => p.AutorDataNascimento).HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));
    }
}
