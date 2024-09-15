using Microsoft.AspNetCore.OData.Routing;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Odata_BookStore.Models;
using Odata_BookStore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookLists"));
builder.Services.AddControllers()
    .AddOData(options => options
        .Select()
        .Filter()
        .Count()
        .OrderBy()
        .Expand()
        .SetMaxTop(100)
        .AddRouteComponents("odata", GetEdmModel()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseODataBatching();

// Custom Middleware to examine the OData routing
app.Use(async (context, next) =>
{
    var endpoint = context.GetEndpoint();
    if (endpoint == null)
    {
        await next(context);
        return;
    }

    var metadata = endpoint.Metadata.GetMetadata<IODataRoutingMetadata>();
    if (metadata != null)
    {
        var templates = metadata.Template.GetTemplates();

    }

    await next(context);
});

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

static IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();
    odataBuilder.EntitySet<Book>("Books");
    odataBuilder.EntitySet<Press>("Presses");
    return odataBuilder.GetEdmModel();
}
