using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QuotesCreator.AL.Repositories.Abstraction;
using QuotesCreator.AL.Services.Abstraction;
using QuotesCreator.AL.Services.Implementation;
using QuotesCreator.IL.DBContext;
using QuotesCreator.IL.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAddQuoteCreatorRepository, AddQuoteCreatorRepository>();
builder.Services.AddScoped<IDeleteQuoteCreatorRepository, DeleteQuoteCreatorRepository>();
builder.Services.AddScoped<IUpdateQuoteCreatorRepository, UpdateQuoteCreatorRepository>();
builder.Services.AddScoped<ISearchQuoteCreatorRepository, SearchQuoteCreatorRepository>();
builder.Services.AddScoped<IGetQuoteCreatorRepository, GetQuoteCreatorRepository>();
builder.Services.AddScoped<IAddQuoteCreatorService, AddQuoteCreatorService>();
builder.Services.AddScoped<IDeleteQuoteCreatorService, DeleteQuoteCreatorService>();
builder.Services.AddScoped<IUpdateQuoteCreatorService, UpdateQuoteCreatorService>();
builder.Services.AddScoped<ISearchQuoteCreatorService, SearchQuoteCreatorService>();
builder.Services.AddScoped<IGetQuoteCreatorService, GetQuoteCreatorService>();
var configuration = builder.Configuration;
builder.Services.AddDbContext<QuoteCreatorDatabaseContext>(options =>
        options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuoteCreatorAPI", Version = "v1" });

});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7101")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
