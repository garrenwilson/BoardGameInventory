namespace BoardGameInventory.Api.Models;

public record UpdateGameRequest(
    string Title,
    int MinimumPlayers,
    int MaximumPlayers);