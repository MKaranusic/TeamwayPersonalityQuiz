using Microsoft.EntityFrameworkCore;
using TeamwayPersonalityQuiz.DataAccess;
using TeamwayPersonalityQuiz.DataAccess.Repositories;
using TeamwayPersonalityQuiz.DataAccess.Repositories.Interfaces;
using TeamwayPersonalityQuiz.Services;
using TeamwayPersonalityQuiz.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("TestDb"));
builder.Services.AddScoped<ApiContext>();

builder.Services.AddTransient<IQuestionService, QuestionService>();
builder.Services.AddTransient<IResultService, ResultService>();

builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
builder.Services.AddTransient<IPersonalityRepository, PersonalityRepository>();

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

app.Run();
