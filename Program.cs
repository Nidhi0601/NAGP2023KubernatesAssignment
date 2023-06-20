using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NAGP2023KubernatesAssignment.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

//string password = string.Empty;
//try
//{
//    Console.WriteLine($"Password: {builder.Configuration["db_password"]}");
//    var base64Bytes = Convert.FromBase64String(builder.Configuration["db_password"]);
//    password = System.Text.Encoding.UTF8.GetString(base64Bytes).Trim();
//    Console.WriteLine(password);
//}
//catch (Exception ex)
//{
//    Console.WriteLine("Error: Invalid Base64 string format. " + ex.Message);
//}


// Add services to the container.
string connectionString = new SqlConnectionStringBuilder()
{
    DataSource = builder.Configuration["db_host"],
    InitialCatalog = builder.Configuration["db_name"],
    UserID = builder.Configuration["db_user"],
    Password = builder.Configuration["db_password"]
}.ConnectionString;
Console.WriteLine(connectionString);
SqlConnection conn = new SqlConnection(connectionString);
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


