using AutoMapper;
using Business.AutoMapper;
using Business.Repositories.Concrete;
using Business.Repositories.InterfaceRepo;
using Data.Context;
using Data.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new Mapping());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedPhoneNumber = false;
    x.SignIn.RequireConfirmedAccount = false;
    x.SignIn.RequireConfirmedEmail = false;
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 1;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireLowercase = false;
})
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
