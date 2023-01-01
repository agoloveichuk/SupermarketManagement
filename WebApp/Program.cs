using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Plugins.DataStore;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using System.Net.NetworkInformation;
using UseCases.CashierConsoleUseCase;
using UseCases.CategoriesUseCase;
using UseCases.DaraStorePluginInterfaces;
using UseCases.ProductsUseCase;
using UseCases.TransactionsUseCase;
using UseCases.UseCaseInterfaces.CashierConsoleUseCaseInterface;
using UseCases.UseCaseInterfaces.CategoryUseCaseInterface;
using UseCases.UseCaseInterfaces.ProductUseCaseInterface;
using UseCases.UseCaseInterfaces.TransactionUseCaseInterface;
using WebApp.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AccountContextConnection") ?? throw new InvalidOperationException("Connection string 'AccountContextConnection' not found.");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<MarketContext>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
});

builder.Services.AddDbContext<AccountContext>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:AccountContextConnection");
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AccountContext>();

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
    option.AddPolicy("CashierOnly", p => p.RequireClaim("Position", "Cashier"));
});
// Dependency Injection for In-Memory Data Store a
//builder.Services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
//builder.Services.AddScoped<IProductRepository, ProductInMemoryRepository>();
//builder.Services.AddScoped<ITransactionRepository, TransactionMemoryRepository>();

// Dependency Injection for ef core Data Store for SQL
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// Dependency Injection for Use Cases and Repositories 
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IGetProductByIdUseCase, GetProductByIdUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IViewProductsByCategoryId, ViewProductsByCategoryId>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();
builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
builder.Services.AddTransient<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>();
builder.Services.AddTransient<IGetTransactionsUseCase, GetTransactionsUseCase>();

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();
app.UseAuthorization();

app.Run();
