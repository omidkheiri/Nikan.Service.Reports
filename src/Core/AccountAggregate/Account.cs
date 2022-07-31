using Ardalis.GuardClauses;
using Nikan.Services.Reports.SharedKernel;

namespace Nikan.Services.Reports.Core.AccountAggregate;

public class Account : EntityBase
{
  public Account(Guid companyId,
    int accountNumber,
    string title,
    string phone,
    string emailAddress,
    string? postalAddress,
    DateTimeOffset dateCreated,
    DateTimeOffset dateModified,
    string createdBy,
    bool isCustomer,
    bool isSupplier,
    Guid accountId)
  {
    CompanyId = companyId;
    AccountNumber = accountNumber;
    Title = title;
    Phone = phone;
    EmailAddress = emailAddress;
    PostalAddress = postalAddress;
    DateCreated = dateCreated;
    DateModified = dateModified;
    CreatedBy = createdBy;
    IsCustomer = isCustomer;
    IsSupplier = isSupplier;
    AccountId = accountId;
  }

  public Guid CompanyId { get; private set; }
  public Guid AccountId { get; private set; }
  public int AccountNumber { get; private set; }
  public string Title { get; private set; } = string.Empty;
  public string Phone { get; private set; } = string.Empty;
  public string EmailAddress { get; private set; } = string.Empty;
  public string? PostalAddress { get; private set; } = string.Empty;
  public DateTimeOffset DateCreated { get; private set; }
  public DateTimeOffset DateModified { get; private set; }
  public string CreatedBy { get; private set; }
  public bool IsCustomer { get; private set; }
  public bool IsSupplier { get; private set; }








}
