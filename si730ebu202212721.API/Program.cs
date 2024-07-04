using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730ebu202212721.API.Inventory.Application.Internal.CommandServices;
using si730ebu202212721.API.Inventory.Application.Internal.QueryServices;
using si730ebu202212721.API.Inventory.Domain.Repositories;
using si730ebu202212721.API.Inventory.Domain.Services;
using si730ebu202212721.API.Inventory.Infrastructure.Persistence.EFC.Repositories;
using si730ebu202212721.API.Inventory.Interfaces.ACL;
using si730ebu202212721.API.Inventory.Interfaces.ACL.Services;
using si730ebu202212721.API.Observability.Application.Internal.CommandServices;
using si730ebu202212721.API.Observability.Application.Internal.OutboundServices.ACL;
using si730ebu202212721.API.Observability.Domain.Repositories;
using si730ebu202212721.API.Observability.Domain.Services;
using si730ebu202212721.API.Observability.Infrastructure.Persistence.EFC.Repositories;
using si730ebu202212721.API.Shared.Domain.Repositories;
using si730ebu202212721.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202212721.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using si730ebu202212721.API.Shared.Interfaces.ASP.Configuration;
using si730ebu202212721.API.Shared.Interfaces.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
        {
            if (builder.Environment.IsDevelopment())
            {
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();
            }
            else if (builder.Environment.IsProduction())
            {
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information);
            }
        }
    });


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "IRRIOT",
                Version = "v1",
                Description = "IRRIOT API REST Documentation",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "IRRIOT INC",
                    Email = "contact@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        // using System.Reflection;
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IThingCommandService, ThingCommandService>();
builder.Services.AddScoped<IThingQueryService, ThingQueryService>();
builder.Services.AddScoped<IThingRepository, ThingRepository>();
builder.Services.AddScoped<IThingContextFacade, ThingContextFacade>();

builder.Services.AddScoped<IThingStateRepository, ThingStateRepository>();
builder.Services.AddScoped<IThingStateCommandService, ThingStateCommandService>();
builder.Services.AddScoped<ExternalThingService>();


//Configure Url to lowercase
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.UseAuthorization();


app.Run();
