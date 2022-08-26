using BaitGate.Models.EFContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using BaitGate.Controllers;
using BaitGate.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
MySqlConnectionStringBuilder mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder()
{
    Server = "10.7.6.18",
    UserID = "baiterek_admin",
    Password = "FuVjCfTJbH4tPtwW6zJP",
    Database = "BAITEREK_GW",
    ConnectionTimeout = 60,
    MaximumPoolSize = 100
};
var connectionString = mySqlConnectionStringBuilder.ConnectionString;
builder.Services.AddDbContext<SEDContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)), contextLifetime: ServiceLifetime.Scoped);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standart Authorization header using the bearer scheme { bearer token }",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false

        };
    });
builder.Services.AddScoped<IClientServices, ClientServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
