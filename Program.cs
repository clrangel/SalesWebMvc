﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMvcContext"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SalesWebMvcContext")),
    builder => builder.MigrationsAssembly("SalesWebMvc")));



// Add services to the container.
builder.Services.AddControllersWithViews();

//Service adicionada por conta da aula 263
builder.Services.AddScoped<SellerService, SellerService>();
//Service adicionada por conta da aula 266
builder.Services.AddScoped<DepartmentService, DepartmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
