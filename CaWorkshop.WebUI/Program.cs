using CaWorkshop.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add WebUI Services
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();

//builder.Services
//    .AddValidatorsFromAssemblyContaining<IApplicationDbContext>()
//    .AddFluentValidationAutoValidation();

builder.Services.AddRazorPages();

builder.Services.AddOpenApiDocument(configure =>
{
    configure.Title = "CaWorkshop API";
});

var app = builder.Build();

#if DEBUG
    // Initialise and seed the database on start-up
    using (var scope = app.Services.CreateScope())
    {
        try
        {
            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
            initialiser.Initialise();
            initialiser.Seed();
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            logger.LogError(ex, "An error occurred during database initialisation.");

            throw;
        }
    }
#endif

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseOpenApi();// generates and serves the OpenAPI Spec (swagger.json)
app.UseSwaggerUi3(); // generate the Swagger UI for the spec above

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html");;

app.Run();
