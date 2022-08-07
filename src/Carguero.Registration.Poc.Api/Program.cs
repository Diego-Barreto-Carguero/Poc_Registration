using Carguero.Registration.Poc.Api.Configurations;
using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Core.DomainObjects;
using Carguero.Registration.Poc.Domain.Utils.Extensions;
using Carguero.Registration.Poc.Infrastructure.Data.Contexts;
using Carguero.Registration.Poc.Infrastructure.Data.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidateModelStateConfiguration));
})
    .AddFluentValidation(sg =>
    {
        sg.RegisterValidatorsFromAssembly(Assembly.Load("Carguero.Registration.Poc.Domain"));
    })
    .AddNewtonsoftJson(o =>
    {
        o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRepository();
builder.Services.AddService();
builder.Services.AddSwagger();
builder.Services.AddConfigureHealthCheck();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<INotifier, Notifier>();

var connectionString = builder.Configuration.GetConnectionString("API");

builder.Services.AddDbContext<RegistrationContext>(option =>
{
    option.UseSqlServer(connectionString, mig => mig.MigrationsAssembly("Carguero.Registration.Poc.Infrastructure.Data"));
    option.UseLazyLoadingProxies(false);
});

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Contents")),
    RequestPath = "/Contents"
});

app.ConfigureHealthCheck();
app.UseHttpsRedirection();
app.UseSwaggerPage();
app.UseReDocPage();
app.UseAuthorization();
app.MapControllers();
app.Run();