using Microsoft.EntityFrameworkCore;
using Persistence;

namespace PhoneBookAPI.Extensions;

public static class AppExtensions
{
    public static WebApplication ConfigureApp(this WebApplication app)
    {
        app.Development();
        app.HttpsRedirection();
        app.Migrate();
        app.Controllers();

        return app;
    }

    private static void Development(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return;
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    private static void HttpsRedirection(this WebApplication app)
    {
        app.UseHttpsRedirection();
    }

    private static void Migrate(this WebApplication app)
    {
        // Apply last migration on startup (not for production)
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
    }

    private static void Controllers(this WebApplication app)
    {
        app.MapControllers();
    }
}