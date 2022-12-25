using ModuloAPI.Context;
using Microsoft.EntityFrameworkCore;
using ModuloAPI.services;
using ModuloAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// servi�o de conex�o com o banco de dados
builder.Services.AddDbContext<ContactContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));
//Inje��o de dependencia
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
