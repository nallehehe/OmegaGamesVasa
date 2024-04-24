using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OmegaGamesAPI.Services;
using OmegaGamesClient.Components;
using OmegaGamesClient.Components.Account;
using OmegaGamesClient.Data;
using OmegaGamesClient.Services;
using System.Net.Http.Headers;
using System.Text;
using OmegaGamesApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("OmegaGamesVasaAzure") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

//TODO: �ndra URI s� att det inte kollar mot local host utan mot Azure
builder.Services.AddHttpClient("OmegaGamesAPI", client => {
    client.BaseAddress = new Uri(builder.Configuration["OmegaGamesAPIBaseAdress"]);
    }).ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new HttpClientHandler();
        if (builder.Environment.IsDevelopment())
        {
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        }
        return handler;
    });

builder.Services.AddHttpClient("EmailLogicAppClient", client => client.BaseAddress = new Uri(builder.Configuration["EmailLogicAppAddress"]));
builder.Services.AddHttpClient("KlarnaPlayground", c => {
    c.BaseAddress = new Uri(builder.Configuration["KlarnaPlayground"]);
    c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
        Convert.ToBase64String(Encoding.UTF8.GetBytes($"{builder.Configuration["KlarnaAPICredentials:Username"]}:{builder.Configuration["KlarnaAPICredentials:Password"]}")));
    });

builder.Services.AddScoped<IProductService<ProductDTO>, ProductService>();
builder.Services.AddScoped<IOrderRepository<OrderDTO>, OrderService>();
builder.Services.AddScoped<IEventService<EventDTO>, EventService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ICheckoutService, KlarnaCheckoutService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
