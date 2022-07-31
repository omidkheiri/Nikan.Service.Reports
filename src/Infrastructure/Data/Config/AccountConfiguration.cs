using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Nikan.Services.Reports.Core.AccountAggregate;

namespace Nikan.Services.Reports.Infrastructure.Data.Config;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
  public void Configure(EntityTypeBuilder<Account> builder)
  {

    builder.HasKey(g => g.Id);
    builder.HasAlternateKey(g => g.AccountNumber);
    builder.HasAlternateKey(g => g.AccountId);
    builder.Property(p => p.Title).HasMaxLength(200).IsRequired();
    builder.Property(p => p.Phone).HasMaxLength(20).IsRequired();
    builder.Property(p => p.EmailAddress).HasMaxLength(200).IsRequired();
    builder.Property(p => p.PostalAddress).HasMaxLength(200);
    builder.Property(p => p.DateCreated);
    builder.Property(p => p.DateModified);
    builder.Property(p => p.CreatedBy);
    builder.Property(p => p.CompanyId);
    builder.HasIndex(p => p.CompanyId);
    builder.HasIndex(p => p.Title).IsUnique();
    builder.HasIndex(p => p.Phone).IsUnique();
    builder.HasIndex(p => p.EmailAddress).IsUnique();

  }
}
