using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Models;

public class OperacaoCompraVenda
{
    public int OperacaoID { get; set; }
    public short OperacaoQuantidade { get; set; }
    public DateOnly OperacaoData { get; set; }
    public Livro OperacaoLivro { get; set; }
    public int LivroID { get; set; }
    
}

public class OperacaoCompraVendaConfiguration : IEntityTypeConfiguration<OperacaoCompraVenda>
{
    public void Configure(EntityTypeBuilder<OperacaoCompraVenda> builder)
    {
        builder.HasKey(p => p.OperacaoID);

        builder.HasIndex(p => p.OperacaoData);

        builder.HasOne<Livro>(p => p.OperacaoLivro)
            .WithMany(p => p.LivroOperacoes);
    }
}