using Api.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IStorage>(
    new SqliteStorage(
        builder.Configuration.GetConnectionString("SqliteConnectionString")));
builder.Services.AddCors(options =>
    options.AddPolicy("CorsPolicy", policy =>
        policy.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins(builder.Configuration["ClientHost"])));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();