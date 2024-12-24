using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using UserManagement.Contexts;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Repositories;
using UserManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example:Breare <token>"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
});
#region AuthenticationFilter
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Keys:TokenKey"] ?? "")),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuer = false
        };
    });
#endregion
#region Contexts
builder.Services.AddDbContext<UserAuthContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));
});
#endregion
#region Repositories
builder.Services.AddScoped<IRepository<string, User>, UserRepository>();
builder.Services.AddScoped<IRepository<int, Doctor>, DoctorRepository>();
builder.Services.AddScoped<IRepository<int, Patient>, PatientRepository>();
#endregion
#region Servicess
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
#endregion
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
