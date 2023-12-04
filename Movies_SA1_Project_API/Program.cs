using Microsoft.EntityFrameworkCore;
using Movies_SA1_Project_API.Data;
using Movies_SA1_Project_API.Implementations;
using Movies_SA1_Project_API.Services;


// Create a new web application builder.
var builder = WebApplication.CreateBuilder(args);


// Configure the services to be added to the dependency injection container.

// Connection to interact with database.
builder.Services.AddDbContext<DataContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
    }
    );

// Add services for user, movie, and review operations.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IReviewService, ReviewService>();



// Configure Cross-Origin Resource Sharing (CORS) policies.
builder.Services.AddCors(
        options =>
        {
            options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    }
                );
        }
    );


// Add controllers, Swagger documentation, and API explorer endpoints.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Build the application.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();


app.MapControllers();

app.UseCors();

app.Run();
