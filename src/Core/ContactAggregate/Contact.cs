using Ardalis.GuardClauses;
using Nikan.Services.Reports.SharedKernel;

namespace Nikan.Services.Reports.Core.ContactAggregate;

public class Contact : EntityBase
{

  protected Contact()
  {

  }
  public Contact(Guid companyId,
    int accountNumber,
    int contactNumber,
    string name, string lastName,
    string phone,
    string emailAddress,
    string accountTitle,
    DateTimeOffset dateCreated,
    DateTimeOffset dateModified,
    string createdBy,
    Guid accountId, DateTimeOffset? birthDate, Guid contactId) : base()
  {
    CompanyId = companyId;
    AccountNumber = accountNumber;
    ContactNumber = contactNumber;
    Name = name;
    LastName = lastName;
    Phone = phone;
    EmailAddress = emailAddress;
    AccountTitle = accountTitle;
    DateCreated = dateCreated;
    DateModified = dateModified;
    CreatedBy = createdBy;
    
    AccountId = accountId;
    if(birthDate != null)
    BirthDate = birthDate.Value;
    ContactId = contactId;
  }

  public Guid CompanyId { get; private set; }
  public Guid ContactId { get; private set; }
  public Guid AccountId { get; private set; }
  public int AccountNumber { get; private set; }
  public int ContactNumber { get; private set; }
  public string Name { get; private set; }
  public string AccountTitle { get; private set; }
  public string LastName { get; private set; }
  public string Phone { get; private set; }
  public string EmailAddress { get; private set; }
  public DateTimeOffset BirthDate { get; private set; }
  public DateTimeOffset DateCreated { get; private set; }
  public DateTimeOffset DateModified { get; private set; }
  public Guid CreatedById { get; private set; }
  public string CreatedBy { get; private set; }
  







}
