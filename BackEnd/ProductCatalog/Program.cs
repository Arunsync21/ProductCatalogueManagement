using BusinessLogic_Layer;
using Entity_Layer.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var productCatalog = builder.Configuration.GetConnectionString("ConnectionStrings");
builder.Services.AddDbContext<ProductCatalogContext>(options => options.UseSqlServer(productCatalog));

builder.Services.AddScoped<ICategoryLogic, CategoryLogic>();
builder.Services.AddScoped<IProductTypeLogic, ProductTypeLogic>();
builder.Services.AddScoped<IFeatureLogic, FeatureLogic>();
builder.Services.AddScoped<IProductLogic, ProductLogic>();
builder.Services.AddScoped<IFeatureValueLogic, FeatureValueLogic>();

builder.Services.AddCors(c => c.AddPolicy("corspolicy", build =>
{
	build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("corspolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
