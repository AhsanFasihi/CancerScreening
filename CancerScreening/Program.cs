
using Microsoft.AspNetCore.Identity;
using CancerScreening.Persistence;
using CancerScreening.Persistence.Identity;
using Microsoft.EntityFrameworkCore;
using CancerScreening.Application.Mapping;
using CancerScreening.Application.Interfaces;
using CancerScreening.Application.Services;
using CancerScreening.Domain.Interfaces;
using CancerScreening.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// MVC
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ICancerAssessmentService, CancerAssessmentService>();
builder.Services.AddScoped<ICancerAssessmentRepository, CancerAssessmentRepository>();
builder.Services.AddScoped<ICancerQuestionRepository, CancerQuestionRepository>();



var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


