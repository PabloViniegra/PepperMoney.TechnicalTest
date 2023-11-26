using Microsoft.OpenApi.Models;
using PepperMoney.TechnicalTest.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBooksRepository, BooksRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BooksApi",
        Version = "v1",
        Description = "A Technical Test for PepperMoney by Pablo Viniegra Picazo",
        Contact = new OpenApiContact
        {
            Name = "Pablo Viniegra Picazo",
            Email = "pablovpmadrid@gmail.com",
            Url = new Uri("https://github.com/PabloViniegra"),
        }
    });
});


var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                     "BooksApi v1"));


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
