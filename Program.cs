using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ScriptWriterApp.Data;
using ScriptWriterApp.Functions;
using Radzen;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BlazorPro.BlazorSize;
using Microsoft.AspNetCore.Authentication;
//using ScriptWriterApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.Cookie.Name = "GoogleAuth";
        options.LoginPath = "/auth/google-login";
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ID"];
        options.ClientSecret = builder.Configuration["Authentication:Google:Secret"];
        options.Scope.Add("profile");
        options.Events.OnCreatingTicket = context =>
        {
            string pic = context.User.GetProperty("picture").GetString();
            context.Identity.AddClaim(new System.Security.Claims.Claim("picture",pic));

            string username = context.User.GetProperty("name").GetString();
            context.Identity.AddClaim(new System.Security.Claims.Claim("name", username));

            return Task.CompletedTask;
        };
    });

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

builder.Services.AddScoped<ChangeHistoryAccessService>();
builder.Services.AddScoped<PagesDataAccessService>();
builder.Services.AddScoped<FoldersDataAccessService>();
builder.Services.AddScoped<UsersDataAccessService>();

builder.Services.AddScoped<BrowserService>();

builder.Services.AddScoped<IResizeListener, ResizeListener>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
    endpoint.MapBlazorHub();
    endpoint.MapFallbackToPage("/_Host");
});


app.Run();
