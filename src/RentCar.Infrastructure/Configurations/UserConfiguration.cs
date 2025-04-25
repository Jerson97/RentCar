using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCar.Domain.Abstractions;
using RentCar.Domain.Users;

namespace RentCar.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Nombre)
            .HasMaxLength(200)
            .HasConversion(nombre => nombre!.Values, value => new Nombre(value));

        builder.Property(user => user.Apellido)
        .HasMaxLength(200)
        .HasConversion(apellido => apellido!.Values, value => new Apellido(value));

        builder.Property(user => user.Email)
        .HasMaxLength(400)
        .HasConversion(email => email!.Value, value => new Email(value));

        builder.HasIndex(user => user.Email).IsUnique();
    }
}