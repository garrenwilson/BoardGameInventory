using System.Runtime.CompilerServices;
using BoardGameInventory.Api.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var games = new List<Game>
{
    new(1, "Wingspan", 1, 5),
    new(2, "Codenames", 2, 8),
    new(3, "Ticket to Ride", 2, 5)
};

app.MapGet("/games", () => games);

app.MapGet("/games/{id:int}", (int id) =>
{
    Game? game = games.FirstOrDefault(game => game.Id == id);

    return game is null
        ? Results.NotFound()
        : Results.Ok(game);
});

app.MapPost("/games", (CreateGameRequest request) =>
{
    int nextId = games.Max(game => game.Id) + 1;
    Game game = new(nextId, request.Title, request.MinimumPlayers, request.MaximumPlayers);

    games.Add(game);

    return Results.Created($"/games/{game.Id}", game);
});

app.MapPut("/games/{id:int}", (int id, UpdateGameRequest request) =>
{
    var index = games.FindIndex(game => game.Id == id);
    if (index < 0) return Results.NotFound();

    games[index] = new(id, request.Title, request.MinimumPlayers, request.MaximumPlayers);

    return Results.Ok(games[index]);
});

app.MapDelete("/games/{id:int}", (int id) =>
{
    var index = games.FindIndex(game => game.Id == id);
    if (index < 0) return Results.NotFound();

    games.RemoveAt(index);

    return Results.NoContent();
});

app.Run();