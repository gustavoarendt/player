using PlayerControl.Api.ApiDependencies;
using PlayerControl.Api.Filters;
using PlayerControl.Api.Security;
using PlayerControl.Infrastructure.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add(typeof(GlobalExceptionFilter)));
builder.Services.AddMediatorDependency();
builder.Services.AddRepositoryDependency();
builder.Services.AddServiceDependency();
builder.Services.AddRabbitMQDependency(builder.Configuration);
builder.Services.AddKeycloakDependency(builder.Configuration);
builder.Services.AddDocumentDependency();

if (builder.Environment.IsEnvironment("Local"))
    builder.Configuration.AddUserSecrets<Program>();

var connectionString = builder.Configuration.GetConnectionString("DbPgConnection");
builder.Services.AddDatabaseDependency(connectionString);

var app = builder.Build();

app.AddSwaggerUIDependency();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
