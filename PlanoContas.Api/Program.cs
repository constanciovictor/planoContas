using PlanoContas.Api.Configurations;
using PlanoContas.Domain.Interfaces.Repositories.DataConector;
using PlanoContas.Infra.SqlDataBase;

var builder = WebApplication.CreateBuilder(args);

// Configurar a conexão com o banco de dados
string connectionString = builder.Configuration.GetConnectionString("dbDefault")!;

// Registrar o SqlConnector como IDbConnector com a connectionString
builder.Services.AddScoped<IDbConnector>(db => new SqlConnector(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.ConfigureServices();

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
