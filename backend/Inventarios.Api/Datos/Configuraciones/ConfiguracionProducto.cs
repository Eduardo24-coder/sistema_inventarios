using Microsoft.EntityFrameworkCore;
using Inventarios.Api.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventarios.Api.Datos.Configuraciones;

public class ConfiguracionProducto : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Productos", tabla =>
        {
            tabla.HasCheckConstraint(
                "CK_Productos_PrecioVenta",
                "[PrecioVenta] >= 0");

        });

        builder.HasKey(producto => producto.Id);

        builder.Property(producto => producto.Codigo)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasIndex(producto => producto.Codigo)
            .IsUnique();

        builder.Property(producto => producto.Nombre)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(producto => producto.Descripcion)
            .HasMaxLength(500);

        builder.Property(producto => producto.PrecioVenta)
            .IsRequired()
            .HasPrecision(18, 2);


        builder.Property(producto => producto.Activo)
            .IsRequired();





        }
    }
