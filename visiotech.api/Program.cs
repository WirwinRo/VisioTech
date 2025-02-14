using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using visiotech.infrastructure.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DbContext
builder.Services.AddDbContext<VisioTechContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

// Registrar la f�brica de DbContext
builder.Services.AddScoped<DbContextFactory>();

builder.Services.AddAutoMapper(typeof(Program));

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
