using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServiceCollection(builder.Configuration);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();