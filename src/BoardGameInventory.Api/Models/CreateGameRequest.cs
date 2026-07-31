namespace BoardGameInventory.Api.Models;

public record CreateGameRequest(
    string Title,
    int MinimumPlayers,
    int MaximumPlayers);