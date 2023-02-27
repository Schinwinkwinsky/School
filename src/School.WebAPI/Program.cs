using MediatR;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using School.Data;
using School.Domain;
using School.Domain.Entities;
using School.WebAPI.Middlewares;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<KnowledgeArea>("KnowledgeAreas");
modelBuilder.EntitySet<Subject>("Subjects");
modelBuilder.EntitySet<Person>("People");
modelBuilder.EntitySet<Teacher>("Teachers");
modelBuilder.ComplexType<Address>();
modelBuilder.ComplexType<Phone>();
modelBuilder.ComplexType<Email>();

builder.Services.AddControllers()
    .AddOData(options => options.Count().Expand().Filter().OrderBy().Select().SetMaxTop(100).AddRouteComponents("odata", modelBuilder.GetEdmModel()))
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb")));

builder.Services.AddMediatR(Assembly.Load("School.Application"));

builder.Services.AddAutoMapper(Assembly.Load("School.Application"));

builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(opt => opt.OperationFilter<EnableQueryFilter>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
