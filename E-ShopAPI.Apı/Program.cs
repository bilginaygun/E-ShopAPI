//namespace E_ShopAPI.Apı

//{
//public class Program
//{
//public static void Main(string[] args)
//{
using Microsoft.AspNetCore.Authentication.JwtBearer;
using E_Shop.Business.Abstract;
using E_Shop.Business.Concrete;
using E_Shop.DAL.Abstract.DataManagement;
using E_Shop.DAL.Concrete.EntityFramework.Context;
using E_Shop.DAL.Concrete.EntityFramework.DataManagement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using E_ShopAPI.Apı.Middleware;
using E_Shop.Helper.Globals;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<E_ShopContext>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<ICustomerService,CustomerManager>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<JWTExceptURLList>(builder.Configuration.GetSection(nameof(JWTExceptURLList)));

var app = builder.Build();
app.UseGlobalExceptionMiddleware();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiAuthorizationMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();


