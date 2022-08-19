using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Nikan.Services.Reports.Core.AccountAggregate;
using Nikan.Services.Reports.Core.ContactAggregate;

namespace Nikan.Services.Reports.Infrastructure.Data.Config;

public class ConatctConfiguration : IEntityTypeConfiguration<Contact>
{
  public void Configure(EntityTypeBuilder<Contact> builder)
  {

    builder.HasKey(g => g.Id);
    builder.HasAlternateKey(q=>q.ContactId);
    builder.HasAlternateKey(q => q.ContactNumber);
    builder.Property(i => i.CompanyId);
    builder.Property(i => i.ContactId);
    builder.Property(i => i.ContactNumber);
    builder.Property(i => i.Name).IsRequired();
    builder.Property(i => i.LastName).IsRequired();
    builder.Property(i => i.Phone).IsRequired();
    builder.Property(i => i.EmailAddress);
    builder.Property(i => i.BirthDate);
    builder.Property(i => i.DateCreated);
    builder.Property(i => i.DateModified);
    builder.Property(i => i.CreatedById);
    builder.Property(i => i.AccountNumber);
    builder.Property(i => i.AccountTitle);
    builder.Property(i => i.CreatedBy);
    builder.Property(i => i.AccountId);
    builder.HasIndex(i => i.EmailAddress).IsUnique();
    builder.HasIndex(i => i.Phone).IsUnique();
    builder.HasIndex(i => i.Name);
    builder.HasIndex(i => i.LastName);


  }
}
