using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<ICrewsService, CrewsService>();
builder.Services.AddScoped<ICrewMembersService, CrewMembersService>();

try {
  String? jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
  String? jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");

  if(string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer))
    throw new ArgumentException(String.Format("JWT environment variables misconfigured\nJWT_KEY: {0}\nJWT_ISSUER: {1}\n", jwtKey, jwtIssuer));

  builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters{
      ValidateIssuer = true,    
      ValidateAudience = true,    
      ValidateLifetime = true,    
      ValidateIssuerSigningKey = true,    
      ValidIssuer = jwtIssuer,
      ValidAudience = jwtIssuer,    
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
  });
} catch(Exception e) {
  Console.WriteLine(e.Message);
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
