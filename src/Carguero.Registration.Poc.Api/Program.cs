using Carguero.Registration.Poc.Api.Configurations;
using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Core.DomainObjects;
using Carguero.Registration.Poc.Domain.Utils.Extensions;
using Carguero.Registration.Poc.Infrastructure.Data.Contexts;
using Carguero.Registration.Poc.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRepository();
builder.Services.AddService();
builder.Services.AddSwagger();
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

app.UseHttpsRedirection();
app.UseSwaggerPage();
app.UseReDocPage();
app.UseAuthorization();
app.MapControllers();

app.Run();
