
////var app = builder.Build();

////// Configure request pipeline
////if (app.Environment.IsDevelopment())
////{

////    app.UseDeveloperExceptionPage(); // Detailed error page in Development
////}
////else
////{
////    app.UseExceptionHandler("/Home/Error"); // Error handling for Production
////}


//using API_PROJECT.Repositiers;
//using API_PROJECT.Services;
//using ApiProject.Models;
////using ApiProject.Dal;
//using ApiProject.Models;
////using ApiProject.Service;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models;
//var builder = WebApplication.CreateBuilder(args);
////Add services to the container.
//builder.Services.AddScoped<IDonorRepository, DonorRepository>();
//builder.Services.AddScoped<IDonorService, DonorService>();


//builder.Services.AddDbContext<ProjectDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//);
//builder.Services.AddControllers();
//// Add Swagger services to the container.
//builder.Services.AddEndpointsApiExplorer(); // For exposing endpoints
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Version = "v1",
//        Title = "Chinese sale API",
//        Description = "A simple example ASP.NET Core API to manage Chinese sale",
//        Contact = new OpenApiContact
//        {
//            Name = "Dassi Kastner",
//            Email = "your.email@example.com",
//            Url = new Uri("https://yourwebsite.com"),
//        }
//    });
//});
////builder.Services.AddScoped<IPresentSrevice, PresentService>();
////builder.Services.AddScoped<IPresentDal, PresentDal>();
////builder.Services.AddScoped<IUserRepository, UsersRepository>();
////builder.Services.AddScoped<IUserService, UsersService>();

////builder.Services.AddScoped(typeof(GenericRepository<>));

////builder.Services.AddScoped<ILoggerService, ConsoleLoggerService>();

////builder.Services.AddScoped<FileLoggerService>(provider =>
////    new FileLoggerService("logs.txt")
////);


//var app = builder.Build();
////builder.Services.AddScoped<TasksApi.Services.Logger.LoggerFactory>();
//builder.Services.AddControllers();


//// Add Swagger services to the container.
//builder.Services.AddEndpointsApiExplorer(); // For exposing endpoints
////builder.Services.AddSwaggerGen(c =>
////{
////    c.SwaggerDoc("v1", new OpenApiInfo
////    {
////        Version = "v1",
////        Title = "Project API",
////        Description = "A simple example ASP.NET Core API to manage books",
////        Contact = new OpenApiContact
////        {
////            Name = "Your Name",
////            Email = "your.email@example.com",
////            Url = new Uri("https://yourwebsite.com"),
////        }
////    });
////});

//var app = builder.Build();

//// Configure request pipeline
//if (app.Environment.IsDevelopment())
//{

//    app.UseDeveloperExceptionPage(); // Detailed error page in Development
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error"); // Error handling for Production
//}

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();

//    // Enable middleware to serve generated Swagger as a JSON    endpoint.
//    app.UseSwagger();

//    // Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.)
//    //app.UseSwaggerUI(c =>
//    //{
//    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "project API V1");
//    //    c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
//    //});
//}

//app.UseRouting();


//app.MapControllers(); // Maps attribute-routed controllers

//// Start the app
//app.Run();
using System.Text;
using ApiProject.Repositiers;
using ApiProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using TasksApi.Models;
using Microsoft.IdentityModel.Tokens;
using API_PROJECT.Repositiers;
//using TasksApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IGiftRepository, GiftRepository>();
builder.Services.AddScoped<IGiftService, GiftService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IWinnersRepository, WinnersRepository>();
builder.Services.AddScoped<IWinnersService, WinnersService>();
builder.Services.AddScoped<JwtTokenService, JwtTokenService>();



builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
// Add Swagger services to the container.
builder.Services.AddEndpointsApiExplorer(); // For exposing endpoints
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Chinese sale API",
        Description = "A simple example ASP.NET Core API to manage Chinese sale",
        Contact = new OpenApiContact
        {
            Name = "Leah Waiss",
            Email = "your.email@example.com",
            Url = new Uri("https://yourwebsite.com"),
        }
    });


    //builder.Services.AddCors(options =>
    //{
    //    options.AddPolicy(name: "origins",
    //                          policy =>
    //                          {
    //                              policy.WithOrigins("http://localhost:4200")
    //                              .AllowAnyHeader().
    //                              AllowAnyMethod();
    //                          });
    //});

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter 'Bearer {your_token}'"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "origins",
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader().
                              AllowAnyMethod();
                          });
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
        };
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.)
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
}




app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("origins");
app.UseAuthorization();

app.MapControllers();

app.Run();






