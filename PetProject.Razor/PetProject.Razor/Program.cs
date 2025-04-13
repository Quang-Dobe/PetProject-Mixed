using Microsoft.EntityFrameworkCore;
using PetProject.Razor.Components;
using PetProject.Razor.Domain.Repositories;
using PetProject.Razor.Persistence;
using PetProject.Razor.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IDealerRepository, DealerRepository>();
builder.Services.AddDbContext<IfsDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
