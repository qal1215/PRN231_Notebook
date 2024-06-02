using Lab3.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab3.API.CustomExtensions;

public static class DbExteensions
{
    public static async Task<IApplicationBuilder> UseMigrationAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<Lab3Prn231Context>();
        await context.Database.MigrateAsync();

        return app;
    }
}
