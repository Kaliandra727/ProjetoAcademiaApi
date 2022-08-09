using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjetoAcademia.EF.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Adicionado pelo programador 29/07/22
string conStr = builder.Configuration.GetConnectionString("ProjetoAcademia");
// Adicionado pelo programador 29/07/22
builder.Services.AddDbContext<ProjetoAcademiaContext>(options => options.UseSqlServer(conStr));

builder.Services.AddEndpointsApiExplorer();
//Alterado pelo programador 29/07/22
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo()
        {
            Version = "v1",
            Title = "Projeto Academia - PSG - Capacitação 2022-04",
            Description = "API REST utilizada para desenvolvimento do modelo de aplicações, " +
            "baseado em boas praticas e no modelo de maturidade de Richardson.",
            TermsOfService = new Uri("http://www.psgtecnologia.com.br"),
            License = new OpenApiLicense()
            {
                Name = "PSG Tecnologia - Todos os direitos reservados.",
                Url = new Uri("http://www.psgtecnologia.com.br")
            }

        });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }

);

// Habilitando Cors 29/07/22 16:50h.
builder.Services.AddCors();

var app = builder.Build();

//Habilitando cors em todos os recursos API 29/07/22 16:50h.
app.UseCors(c=>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

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
