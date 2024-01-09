using Microsoft.EntityFrameworkCore;
using Serilog;
using Trip_project.Data;
using Trip_project.Interfaces;
using Trip_project.Reposotory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TripdbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("Con")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Automapperprofil));
builder.Services.AddScoped(typeof(IGenericInterface<>),typeof(GenericReposClass<>));
builder.Services.AddScoped<Iuser, UserRepos>();
builder.Services.AddScoped<IPost, PostRepos>();

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
