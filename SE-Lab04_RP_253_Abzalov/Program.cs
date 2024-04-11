using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SE_Lab04_RP_253_Abzalov.Data;
using SE_Lab04_RP_253_Abzalov.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SE_Lab04_RP_253_AbzalovContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SE_Lab04_RP_253_AbzalovContext") ?? throw new InvalidOperationException("Connection string 'SE_Lab04_RP_253_AbzalovContext' not found.")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.UseRequestLocalization("en-US", "ru-RU");

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
