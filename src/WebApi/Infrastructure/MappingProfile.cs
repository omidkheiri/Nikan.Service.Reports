using AutoMapper;
using Nikan.Services.Reports.Core.AccountAggregate;
using Nikan.Services.Reports.Core.AccountAggregate.Commands;
using Nikan.Services.Reports.Core.ContactAggregate;
using Nikan.Services.Reports.Core.ConttactAggregate.Commands;

namespace Nikan.Services.Reports.WebApi.Infrastructure;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<AddAccountCommand, Account>();
    CreateMap<AddContactCommand, Contact>();
  }
}
