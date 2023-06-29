
using System.Text;
using IGAPI;
using IGAPI.Repositories;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services;
using IGAPI.Services.interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// TODO: SUSCEPTIBLE TO CHANGE IN DEPLOYMENT
//builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Adding generic repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

builder.Services.AddScoped<ILookUpService,LookUpService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // TODO: SET TO TRUE WHEN HTTPS
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_TOKEN")))
        };
    });

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name:"ngOrigins", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



var app = builder.Build();


// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<DataContext>();
    
    // Here is the migration executed
    //dbContext.Database.EnsureDeleted();
    
    dbContext.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName.Equals("local"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ngOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();