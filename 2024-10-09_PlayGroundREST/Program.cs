using PlayGroundLib;

var builder = WebApplication.CreateBuilder(args);

// Service Containers
// Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                              });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSingleton<PlayGroundsRepository>(new PlayGroundsRepository());

//  Build
var app = builder.Build();

// HTTP Request Pipeline.
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
