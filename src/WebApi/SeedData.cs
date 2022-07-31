//using Microsoft.EntityFrameworkCore;
//using Nikan.Services.Reports.Infrastructure.Data;
//using System;
//using System.Linq;
//using Microsoft.Extensions.DependencyInjection;
//using Nikan.Services.Reports.Core.AccountAggregate;
//using Nikan.Services.Reports.SharedKernel.Interfaces;

//namespace Nikan.Services.Reports.WebApi
//{
//  public static class SeedData
//  {

//    public static readonly Account TestAccount = new Account(Guid.Parse("00000000-1111-1111-0000-111111111111"),
//      "حساب مشتریان شخصی", "-", "-", "-", Guid.NewGuid());


//    public static void Initialize(IServiceProvider serviceProvider)
//    {
//      using (var dbContext = new AppDbContext(
//          serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
//      {


//        PopulateTestData(dbContext);


//      }
//    }
//    public static void PopulateTestData(AppDbContext dbContext)
//    {
//      foreach (var item in dbContext.Contacts)
//      {
//        dbContext.Remove(item);
//      }
//      foreach (var item in dbContext.Accounts)
//      {
//        dbContext.Remove(item);
//      }

//      dbContext.SaveChanges();

//      TestAccount.AddContact(Guid.NewGuid(),
//        Guid.Parse("00000000-1111-1111-0000-111111111111"),
//      "اطلاعات تماس",
//      "-",
//      "-",
//      "-",
//      Guid.NewGuid());
//      dbContext.Accounts.Add(TestAccount);


//      dbContext.SaveChanges();




//    }
//  }
//}


