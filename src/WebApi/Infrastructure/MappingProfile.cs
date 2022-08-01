using AutoMapper;
using Nikan.Services.Reports.Core.AccountAggregate;
using Nikan.Services.Reports.Core.AccountAggregate.Commands;

namespace Nikan.Services.Reports.WebApi.Infrastructure;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<AddAccountCommand, Account>();
  }
}
