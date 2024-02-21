using backend.api.Database;
using backend.api.Database.Seed;
using backend.api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ItemService>();

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(
    "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Database\\items.db"
    )));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGen =>
{
    swaggerGen.SwaggerDoc("v1", new OpenApiInfo { Title = "Items Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Items Api");

        // serve swagger in the root api endpoint
        options.RoutePrefix = string.Empty;
    });

    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

// Seed the database
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var dbContext = services.GetRequiredService<DatabaseContext>();

    // Apply any pending migrations
    dbContext.Database.Migrate();

    // Seed the database
    Seeder.Seed(dbContext);
}

app.MapControllers();

app.Run();