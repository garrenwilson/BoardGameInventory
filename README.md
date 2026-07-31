# BoardGameInventory

A small ASP.NET Core practice project for learning backend CRUD development before building the larger TableMate product. The current milestone is a working, in-memory board-game inventory API.

## Current capabilities

- Create a game
- List all games
- Get one game by ID
- Update a game
- Delete a game
- Return appropriate HTTP results for successful requests and missing IDs

The API currently stores data in memory, so the inventory resets whenever the application restarts. PostgreSQL persistence is the next milestone.

## Technology

- C# and .NET 10
- ASP.NET Core minimal API
- Postman for manual API testing
- Git and GitHub
- Docker Engine and Docker Compose in WSL Ubuntu, ready for the future PostgreSQL setup

## Run locally

### Prerequisites

- .NET 10 SDK

### Start the API

From the repository root:

```powershell
dotnet run --project src/BoardGameInventory.Api
```

The terminal prints the local address, for example:

```text
Now listening on: http://localhost:5246
```

Use the address shown by your own terminal; the port can change between runs.

## API endpoints

| Method | Route | Description | Success |
| --- | --- | --- | --- |
| `GET` | `/games` | List the inventory | `200 OK` |
| `GET` | `/games/{id}` | Get one game | `200 OK` or `404 Not Found` |
| `POST` | `/games` | Create a game | `201 Created` |
| `PUT` | `/games/{id}` | Replace a game's editable fields | `200 OK` or `404 Not Found` |
| `DELETE` | `/games/{id}` | Delete a game | `204 No Content` or `404 Not Found` |

### Create a game

```http
POST /games
Content-Type: application/json

{
  "title": "Azul",
  "minimumPlayers": 2,
  "maximumPlayers": 4
}
```

The API assigns the game ID and returns the created game in the response.

### Update a game

```http
PUT /games/1
Content-Type: application/json

{
  "title": "Wingspan",
  "minimumPlayers": 1,
  "maximumPlayers": 5
}
```

## Project structure

```text
src/BoardGameInventory.Api/
  Models/                 API request and response shapes
  Program.cs              Endpoint definitions and temporary in-memory data
```

## Learning roadmap

1. Add PostgreSQL in Docker Compose.
2. Persist games with EF Core and an initial migration.
3. Add validation and automated API tests.
4. Add categories, filtering, API documentation, CI, and—later—a small React UI.

## Status

This is a guided learning repository. The focus is building and understanding each layer deliberately, not prematurely expanding the application with authentication, external game imports, or real-time collaboration.
