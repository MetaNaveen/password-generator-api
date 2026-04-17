using Scalar.AspNetCore;

var debug = true;
var builder = WebApplication.CreateBuilder (args);
builder.Services.AddControllers ();
builder.Services.AddEndpointsApiExplorer ();
builder.Services.AddOpenApi ();
var app = builder.Build ();

// Configure the HTTP request pipeline.
if (debug || app.Environment.IsDevelopment ()) {
   app.MapOpenApi ();
   app.MapScalarApiReference ();
}

app.UseHttpsRedirection ();
app.UseAuthorization ();
app.MapControllers ();

app.Run ();
