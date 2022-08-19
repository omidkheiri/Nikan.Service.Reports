using AutoMapper;
using MediatR;
using contact = Nikan.Services.Reports.Core.ContactAggregate;
using Nikan.Services.Reports.Core.ConttactAggregate.Commands;
using Nikan.Services.Reports.Infrastructure.Data;
using Nikan.Services.Reports.Core.ContactAggregate;

namespace Nikan.Services.Reports.WebApi.Adaptors.AccountAdaptor.Service.Commands;

public class AddContactCommandHandler : IRequestHandler<AddContactCommand, Contact>
{
  private readonly AppDbContext _appDbContext;
  private readonly IMapper _mapper;
  public AddContactCommandHandler(AppDbContext appDbContext, IMapper mapper) : base()
  {
    _appDbContext = appDbContext;
    _mapper = mapper;
  }
  async Task<Contact> IRequestHandler<AddContactCommand, Contact>.Handle(AddContactCommand request, CancellationToken cancellationToken)
  {

    var contact = _mapper.Map<Contact>(request);
    try
    {

      _appDbContext.Conatcts.Add(contact);
      await _appDbContext.SaveChangesAsync();
      return contact;
    }
    catch (Exception ex)
    {
      var e = ex;
      throw;
    }



  }
}
