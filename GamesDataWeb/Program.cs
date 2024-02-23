using GamesDataAccess;
using Microsoft.Data.SqlClient;
using System.Data.SQLite;

var builder = WebApplication.CreateBuilder(args);
var dbName = builder.Configuration.GetValue<string>("Database")!;
var connectionString = builder.Configuration.GetConnectionString(dbName);

GamesDao dao;

switch (dbName)
{
    case "SqlServer":
        dao = new GamesDao
        (
            connectionFactory: () => new SqlConnection(connectionString),
            strConcatOperator: "+",
            parameterPrefix: "@",
            typeBoolean: "bit"
        );

        break;

    case "SQLite" or "TempDb":
        var connectionStringInspector = new SQLiteConnectionStringBuilder(connectionString);
        var file = connectionStringInspector.DataSource;
        var folder = Path.GetDirectoryName(file)!;

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        dao = new GamesDao
        (
            connectionFactory: () => new SQLiteConnection(connectionString),
            strConcatOperator: "||",
            parameterPrefix: ":",
            typeBoolean: "int"
        );
        break;

    default:
        throw new NotImplementedException("No implementation for the configured database.");
}

if (dbName == "TempDb")
    dao.DropAllTables();

dao.CreateAllNonExistingTables();

// Add services to the container.
builder.Services.AddSingleton(dao);
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();