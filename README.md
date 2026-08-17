# BoardGameInventory

A small ASP.NET Core practice project for learning backend CRUD development before building the larger TableMate product. The current milestone is a working, in-memory board-game inventory API with a local PostgreSQL development environment.

## Current capabilities

- Create a game
- List all games
- Get one game by ID
- Update a game
- Delete a game
- Return appropriate HTTP results for successful requests and missing IDs

The API currently stores game data in memory, so the inventory resets whenever the application restarts. A local PostgreSQL database is now available through Docker Compose, but EF Core persistence is the next milestone.

## Technology

- C# and .NET 10
- ASP.NET Core minimal API
- Postman for manual API testing
- Git and GitHub
- Docker Engine and Docker Compose in WSL Ubuntu
- Docker Desktop for viewing and managing local containers
- PostgreSQL 17 through Docker Compose

## Run locally

### Prerequisites

- .NET 10 SDK
- WSL Ubuntu with Docker Engine and Docker Compose installed

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

### Start PostgreSQL

The API does not use PostgreSQL yet, but the local database environment is ready for the upcoming EF Core persistence milestone.

1. Create your local configuration file once:

   ```bash
   cp .env.example .env
   ```

2. Open `.env` and replace `POSTGRES_PASSWORD` with a local password.
3. Start PostgreSQL.

    ```bash
    docker compose up -d
    ```

4. Confirm the container is healthy.

    ```bash
    docker compose ps
    ```

5. Stop PostgreSQL while keeping its data.

    ```bash
    docker compose down
    ```

### Reset local database data

This permanently deletes the local PostgreSQL data volume:

```bash
docker compose down -v  
```

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
compose.yaml                    Local PostgreSQL container recipe
.env.example                    Safe template for local configuration
src/BoardGameInventory.Api/
  Models/                       API request and response shapes
  Program.cs                    Endpoint definitions and temporary in-memory data
```

## Learning roadmap

1. Persist games with EF Core and an initial migration.
2. Add validation and automated API tests.
3. Add categories, filtering, API documentation, CI, and—later—a small React UI.

## Status

This is a guided learning repository. The focus is building and understanding each layer deliberately, not prematurely expanding the application with authentication, external game imports, or real-time collaboration.
