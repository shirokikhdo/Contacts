using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServiceCollection(builder.Configuration);

var app = builder.Build();
app.Services.AddServiceProvider();
app.UseSwagger();
app.UseSwaggerUI();
app.UseConfigMiddleware();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapFallbackToController("Index", "Fallback");
app.UseHttpsRedirection();
app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();