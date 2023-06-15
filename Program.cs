using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NAGP2023KubernatesAssignment.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

var base64Bytes = Convert.FromBase64String(builder.Configuration["db-password"]);
var password = System.Text.Encoding.UTF8.GetString(base64Bytes);

// Add services to the container.
SqlConnection conn = new SqlConnection(new SqlConnectionStringBuilder() { DataSource = builder.Configuration["db-host"], InitialCatalog = builder.Configuration["db-name"], 
    UserID = builder.Configuration["db-user"], Password = password}.ConnectionString);
builder.Services.AddDbContext<CoreDbContext>(op => op.UseSqlServer(conn));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();


