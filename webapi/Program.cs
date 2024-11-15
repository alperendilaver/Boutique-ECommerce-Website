using Application.Interfaces;
using Persistance.Context;
using Persistance.Repositories;
using MediatR;
using Application.Services;
using Persistance.Repositories.ProductRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Application.Features.Handlers.IdentityHandlers;
using Persistance.Repositories.UserRepositories;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<NazOzturkContext>();


builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<NazOzturkContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<CheckAuthHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=>

{
    options.Cookie.Name = "Admin"; 
    options.LoginPath="/Users/Login";
});//cookie kullanacağımızı uygulamaya söyledik
builder.Services.ConfigureApplicationCookie(options=>{
    options.LoginPath="/Users/Login";
});
builder.Services.AddCors(options =>{
    options.AddPolicy("AllowNextJSApp", builder =>{
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

builder.Services.AddApplicationService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS middleware'ini buraya ekleyin
app.UseCors("AllowNextJSApp");

app.UseRouting();

app.UseAuthentication(

); // Authentication middleware'ini Authorization'dan önce ekleyin
app.UseAuthorization();

app.MapControllers();

app.Run();
