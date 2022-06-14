using GraphQL.Server;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using PictureGallery.Data.Models;
using PictureGallery.GraphQL.Schemas;
using PictureGallery.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//db
builder.Services.AddDbContext<GalleriesContext>(opt=>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//repo and services
builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IPictureRepository, PictureRepository>();

// Add GraphQL
builder.Services.AddScoped<ISchema, GallerySchema>();
builder.Services.AddGraphQL(options => { options.EnableMetrics = true; }).AddSystemTextJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGraphQL<ISchema>();

app.MapControllers();

app.Run();