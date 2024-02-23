using GamesDataAccess;
using GamesDataAccess.Criterias;
using GamesDataAccess.DbItems;
using Microsoft.Data.SqlClient;

/*
string dbFile = @"..\..\Data\test.db";
string dbFilePath = Path.GetDirectoryName(dbFile)!;
if (!Directory.Exists(dbFilePath))
{
    Directory.CreateDirectory(dbFilePath);
}*/

var connectionString = new SqlConnectionStringBuilder
{
    DataSource = "kkritstgdb.kyklos.local,1433",
    Password = "sAt3cxy;9euoq4c",
    UserID = "learner",
    Encrypt = false,
    InitialCatalog = "SQL_Adv_Course"
}.ToString();

//string connStr = $@"Data Source={dbFile}; Version=3;Foreign Keys=True";

GamesDao gamesDao =
    new GamesDao
    (
        connectionFactory: () => new SqlConnection(connectionString),
        strConcatOperator: "+",
        parameterPrefix: "@",
        typeBoolean: "bit"
    );

gamesDao.DropAllTables();

gamesDao.CreateAllNonExistingTables();

DataPopulator dataPopulator = new DataPopulator(gamesDao);

dataPopulator.AddSomeData();

PrintLine("All games");

GameDbItem[] games = gamesDao.GetAllGames();

foreach (var game in games)
{
    Console.WriteLine(game);
}

PrintLine("All stores");

StoreDbItem[] stores = gamesDao.GetAllStores();

foreach (var store in stores)
{
    Console.WriteLine(store);
}

PrintLine("All platforms");

PlatformDbItem[] platforms = gamesDao.GetAllPlatforms();

foreach (var platform in platforms)
{
    Console.WriteLine(platform);
}

PrintLine("Owned games");

var ownedGames = 
    gamesDao
    .GetOwnedGamesByCriteria
    (
        new GamesCriteria 
        { 
            PurchaseDateFrom = new DateOnly(2022, 1, 1),
            StoreName = "me",
            StoreDescription = "resto",
            PlatformName = "Play",
            GameName = "la",
            GameTags = "adv"
        }
    );

foreach (var tx in ownedGames)
{
    Console.WriteLine(tx);
}

PrintLine("End");

void PrintLine(string? title = null)
{
    const int maxLen = 100;

    if ((title?.Length ?? 0) > maxLen)
    {
        Console.WriteLine(title);
        return;
    }
    
    int halfLen = (maxLen - (title?.Length ?? 0)) / 2;
    string halfLine = new string('-', halfLen);
    Console.WriteLine($"{halfLine} {title ?? ""} {halfLine}");
}