using MagnesiaBilgisayar.Application.Services;
using MagnesiaPcShop.Entities;
using MagnesiaPcShop.Infrastructure.Data;
using MagnesiaPcShop.Infrastructure.Repositories;
using MagnesiaPcShop.Mvc.Extensions;
using MagnesiaPcShop.Services;
using MagnesiaPcShop.Services.Mappings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.AddInjections();

builder.Services.AddSession(opt =>
{
	opt.IdleTimeout = TimeSpan.FromMinutes(10);
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(opt =>
				{
					opt.LoginPath = "/Users/Login";
					opt.AccessDeniedPath = "/Users/AccessDenied";
					opt.ReturnUrlParameter = "returnUrl";
				});

builder.Services.AddMemoryCache();
builder.Services.AddResponseCaching(opt=>
{
	opt.SizeLimit = 10000;
});

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

app.UseResponseCaching();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
