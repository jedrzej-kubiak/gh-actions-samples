var app = WebApplication.Create(args);

var builder = WebApplication.CreateBuilder();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

app = builder.Build();

app.Logger.LogInformation("The app started");

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/oops");
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapGet("/hello", () => "Hello World");
app.MapGet("/env", () => app.Environment.EnvironmentName.ToString());
app.MapGet("/oops", () => "Oops! An error happened.");

app.Run();