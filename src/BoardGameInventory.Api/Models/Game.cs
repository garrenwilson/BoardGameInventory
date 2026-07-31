namespace BoardGameInventory.Api.Models;

public record Game(
    int Id,
    string Title,
    int MinimumPlayers,
    int MaximumPlayers);