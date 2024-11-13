﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Models;

public class Editora
{
    public int EditoraID { get; set; }
    public string EditoraNome { get; set; }
    public string? EditoraLogradouro { get; set; }
    public ushort? EditoraNumero { get; set; }
    public string? EditoraComplemento { get; set; }
    public string EditoraCidade { get; set; }
    public string EditoraUF { get; set; }
    public string EditoraPais { get; set; }
    public string? EditoraCEP { get; set; }
    public string? EditoraTelefone { get; set; }

    public ICollection<Livro> EditoraLivros { get; set; }
}

public class EditoraConfiguration : IEntityTypeConfiguration<Editora>
{
    public void Configure(EntityTypeBuilder<Editora> builder)
    {
        builder.HasKey(p => p.EditoraID);

        builder.HasIndex(p => p.EditoraNome);

        builder.Property(p => p.EditoraNome).HasMaxLength(80).IsRequired();
        builder.Property(p => p.EditoraLogradouro).HasMaxLength(80);
        builder.Property(p => p.EditoraComplemento).HasMaxLength(80);
        builder.Property(p => p.EditoraCidade).HasMaxLength(60).IsRequired();
        builder.Property(p => p.EditoraUF).HasMaxLength(2).IsRequired();
        builder.Property(p => p.EditoraPais).HasMaxLength(40).IsRequired();
        builder.Property(p => p.EditoraCEP).HasMaxLength(12);
        builder.Property(p => p.EditoraTelefone).HasMaxLength(15);

        builder.HasMany<Livro>(p => p.EditoraLivros).WithOne(p => p.LivroEditora);
    }
}