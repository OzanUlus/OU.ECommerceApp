using ECommerce.Catalog.Services.AboutServices;
using ECommerce.Catalog.Services.BrandsServices;
using ECommerce.Catalog.Services.CategoryServices;
using ECommerce.Catalog.Services.ContactServices;
using ECommerce.Catalog.Services.FeatureServices;
using ECommerce.Catalog.Services.FeatureSliderServices;
using ECommerce.Catalog.Services.ProductDetailServices;
using ECommerce.Catalog.Services.ProductImageServices;
using ECommerce.Catalog.Services.ProductServices;
using ECommerce.Catalog.Services.SpecialDiscountServices;
using ECommerce.Catalog.Services.SpecialOfferServices;
using ECommerce.Catalog.Services.StatisticServices;
using ECommerce.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => 
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<IProductDetailService, ProductDetailManager>();
builder.Services.AddScoped<IProductImageService, ProductImageManager>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderManager>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferManager>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<ISpecialDiscountService, SpecialDiscountManager>();
builder.Services.AddScoped<IBrandService, BrandManager>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IStatisticService, StatisticService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp => 
{
  return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
