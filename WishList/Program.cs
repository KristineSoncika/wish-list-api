using Microsoft.EntityFrameworkCore;
using WishList.Core.Entities;
using WishList.Core.Services;
using WishList.Core.Validations;
using WishList.Data;
using WishList.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WishListDbContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("WishListConnection")));
builder.Services.AddScoped<IWishListDbContext, WishListDbContext>();
builder.Services.AddScoped<IEntityService<Item>, EntityService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IItemValidator, ItemNameValidator>();
builder.Services.AddScoped<IItemValidator, ItemDescriptionValidator>();

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