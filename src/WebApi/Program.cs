using System.Reflection;
using Ardalis.ListStartupServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Nikan.Service.CRM.Profiles.WebApi.MiddleWares;
using Nikan.Services.Reports.Core;
using Nikan.Services.Reports.Infrastructure;
using Nikan.Services.Reports.Infrastructure.Data;
using Nikan.Services.Reports.Infrastructure.Options;
using Nikan.Services.Reports.WebApi.Adaptors.AccountAdaptor.Service;
using Nikan.Services.Reports.WebApi.Adaptors.ContactAdaptor.Service;
using Nikan.Services.Reports.WebApi.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var basicDataServiceConfiguration = builder.Configuration.GetSection(nameof(BasicDataService)).Get<BasicDataService>();
builder.Services.AddSingleton(basicDataServiceConfiguration);



builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddCors(options =>
{
  options.AddPolicy("CorsPolicy",
      builder => builder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
});
builder.Services.AddDbContext(connectionString);
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddGrpc();

var config = new MapperConfiguration(cfg =>
{
  cfg.AddProfile(new MappingProfile());

});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nikan Services CRM Profiles", Version = "v1" });
  c.EnableAnnotations();
});

// add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
builder.Services.Configure<ServiceConfig>(config =>
{
  config.Services = new List<ServiceDescriptor>(builder.Services);

  // optional - default path to view services is /listallservices - recommended to choose your own path
  config.Path = "/listservices";
});


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{


  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(
    new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware();
}
else
{
  app.UseExceptionHandler("/swagger");
  app.UseHsts();

}

app.UseRouting();

app.UseHttpsRedirection();


// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nikan Services CRM Profiles V1"));

app.UseEndpoints(endpoints =>
{
  endpoints.MapDefaultControllerRoute();
  endpoints.MapGrpcService<GRPCAccountService>();
  endpoints.MapGrpcService<GRPCContactService>();
  
});

// Seed Database
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  try
  {
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    context.Database.EnsureCreated();
    //  SeedData.Initialize(services);
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
  }
}
app.UseCors("CorsPolicy");
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<RequestResponseLogging>();
app.Run();
