using Cliente.BancoDeDadosEF.Repositorio;
using Cliente.Core.AspNetCoreWebApi;
using Cliente.WebAPI;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddDbContext<ContextoDoBancoDeDados>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal"),
                builder => builder.EnableRetryOnFailure()));

builder.Services.IncluirTodasAsDependencias();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware(typeof(MiddlewareDeErros));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
