using pokemonder.Services;
//using pokemonder.Controllers; // Your Controllers namespace - Not strictly needed in Program.cs

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // Important for controllers

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPokemonService, PokemonService>();
/* Also possible to use AddTransient or AddSingleton
builder.Services.AddTransient<IPokemonService, PokemonService>();
builder.Services.AddSingleton<IPokemonService, PokemonService>();
 */

// If you are using Entity Framework Core, uncomment the following:
// builder.Services.AddDbContext<YourDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); // If you have authentication/authorization

app.MapControllers(); // Important for controllers

app.Run();