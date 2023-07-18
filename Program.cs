using CMSChallenge.Infrastructure.Context;
using CMSChallenge.Infrastructure.Interfaces;
using CMSChallenge.Infrastructure.Repository;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

Batteries.Init();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ArticlesContext>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddControllersWithViews();

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
