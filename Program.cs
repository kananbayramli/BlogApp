using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
});


//addscoped her requeste bir obyect yaradir. 
builder.Services.AddScoped<IPostRepository, EfPostRepository>();

var app = builder.Build();

SeedData.TestDatalariDoldur(app);


app.MapDefaultControllerRoute();

app.Run();
