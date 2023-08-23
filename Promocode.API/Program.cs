using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;
using Promocode.DomainServices.Implementation;
using Promocode.DomainServices.Interfaces;
using Promocode.DomainServices.Repository;
using Promocode.Infrastructure.Repositories.CouchbaseRepository.Implementation;
using Promocode.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Promocode.Application")));

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

builder.Services.AddCouchbase(config.GetSection("Couchbase"));
builder.Services.AddScoped<IPromocodeDomainService, PromocodeDomainService>();
builder.Services.AddSingleton<ICouchbaseRepository, CouchbaseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();