using Microsoft.EntityFrameworkCore;
using DB.Context;
using Services.Contracts;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

var MyCors = "MyCors";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyCors,
                      builder =>
                      {
                          builder.WithHeaders("*");
                          builder.WithOrigins("*");
                          builder.WithMethods("*");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(optios =>
    optios.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Add ProductService
builder.Services.AddScoped<IProductService, ProductService>();
// Add CompanyService 
builder.Services.AddScoped<ICompanyService, CompanyService>();
// mapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseCors(MyCors);

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

public partial class Program { }
