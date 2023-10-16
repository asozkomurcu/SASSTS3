using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SASSTS.Api.Filters;
using SASSTS.Application.Automappings;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Services.Implementation;
using SASSTS.Application.Validators.AccountsValidators;
using SASSTS.Application.Validators.BillValidators;
using SASSTS.Application.Validators.CategoryValidators;
using SASSTS.Application.Validators.CompanyValidators;
using SASSTS.Application.Validators.CustomerValidators;
using SASSTS.Application.Validators.DepartmentValidators;
using SASSTS.Application.Validators.PriceOfferValidators;
using SASSTS.Application.Validators.ProductValidators;
using SASSTS.Application.Validators.PurchasedProductValidators;
using SASSTS.Application.Validators.PurchaseRequestValidators;
using SASSTS.Application.Validators.WholesalerValidators;
using SASSTS.Domain.Repositories;
using SASSTS.Domain.Services.Abstraction;
using SASSTS.Domain.Services.Implementation;
using SASSTS.Domain.UWork;
using SASSTS.Infrastructure;
using SASSTS.Persistence.Context;
using SASSTS.Persistence.Repositories;
using SASSTS.Persistence.UWork;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Logging
var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

// Add services to the container.

//ActionFilter registiration
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ExceptionHandlerFilter());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JwtTokenWithIdentity", Version = "v1", Description = "JwtTokenWithIdentity test app" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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


builder.Services.AddHttpContextAccessor();

//DbContext Registiration
builder.Services.AddDbContext<SASSTSContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SASSTS"));
});

//Repository Registiraction
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//UnitOfWork Registiration
builder.Services.AddScoped<IUnitWork, UnitWork>();

//Business Service Registiration
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IPriceOfferService, PriceOfferService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPurchasedProductService, PurchasedProductService>();
builder.Services.AddScoped<IPurchaseRequestService, PurchaseRequestService>();
builder.Services.AddScoped<IWholesalerService, WholesalerService>();
builder.Services.AddScoped<ILoggedUserService, LoggedUserService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IMessageService, MessageService>();


//Automapper
builder.Services.AddAutoMapper(typeof(DomainToDto), typeof(ViewModelToDomain));

//FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining(typeof(RegisterValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(LoginValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdateUserValidator));

builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateBillValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(GetBillByIdValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdateBillValidator));

builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCategoryValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(DeleteCategoryValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(GetCategoryByIdValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdateCategoryValidator));

builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCompanyValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(DeleteCompanyValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(GetCompanyByIdValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdateCompanyValidator));

builder.Services.AddValidatorsFromAssemblyContaining(typeof(DeleteCustomerValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(GetCustomerByIdValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdateCustomerValidator));

builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateDepartmentValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(DeleteDepartmentValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(GetDepartmentByIdValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdateDepartmentValidator));

builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreatePriceOfferValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(DeletePriceOfferValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(GetPriceOfferByIdValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdatePriceOfferValidator));

builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateProductValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(DeleteProductValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(GetProductByIdValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdateProductValidator));

builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreatePurchasedProductValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(GetPurchasedProductByIdValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdatePurchasedProductValidator));

builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreatePurchaseRequestValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(DeletePurchaseRequestValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(GetPurchaseRequestByIdValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdatePurchaseRequestValidator));

builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateWholesalerValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(DeleteWholesalerValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(GetWholesalerByIdValidator));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(UpdateWholesalerValidator));

// JWT kimlik doðrulama servisini ekleme
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"], // Tokený oluþturan tarafýn adresi
            ValidAudience = builder.Configuration["Jwt:Audiance"], // Tokenýn kullanýlacaðý hedef adres
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"])) // Gizli anahtar
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
