using System.Data;
using Demo.Api;
using Npgsql;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddScoped<IProductDAO, ProductDAO>();

builder.Services
     .AddScoped<IDbConnection>(sp =>
        new NpgsqlConnection(sp.GetRequiredService<IConfiguration>().GetConnectionString("Default")));

var app = builder.Build();

app.MapProductsEndpoints();

app.Run();
