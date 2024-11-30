

var builder = WebApplication.CreateBuilder(args);


// Configure the HTTP request pipeline.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);
//builder.Services
//    .AddApplicationServices(builder.Configuration)
//    .AddInfrastructureServices(builder.Configuration)
//    .AddApiServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiServices();
app.Run();