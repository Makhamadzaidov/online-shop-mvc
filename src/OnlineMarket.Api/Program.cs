using Microsoft.EntityFrameworkCore;
using OnlineMarket.Data.DbContexts;
using OnlineMarket.Service.Interfaces;
using OnlineMarket.Service.Mappers;
using OnlineMarket.Service.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineStoreDb")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
