using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<string> robotCommands = new() { "Left", "Right", "Place", "Move" };

app.MapGet("/", () => "Hello, Robot!");

app.MapGet("/robot-commands", () => Results.Ok(robotCommands));

app.MapGet("/robot-commands/move", () =>
{
    var moveCommands = new List<string> { "Move" };
    return Results.Ok(moveCommands);
});

app.MapGet("/robot-commands/{id:int}", (int id) =>
{
    if (id < 0 || id >= robotCommands.Count)
    {
        return Results.NotFound(new { Message = $"Command with ID {id} not found" });
    }
    return Results.Ok(new { Id = id, Command = robotCommands[id] });
});

app.MapPost("/robot-commands", ([FromBody] RobotCommand newCommand) =>
{
    if (string.IsNullOrWhiteSpace(newCommand.Command))
    {
        return Results.BadRequest("Command cannot be empty");
    }

    robotCommands.Add(newCommand.Command);  // ✅ Add only the string, not the object

    return Results.Created($"/robot-commands/{robotCommands.Count - 1}", new
    {
        Id = robotCommands.Count - 1,
        Command = newCommand.Command  // ✅ Use the correct variable
    });
});

app.MapPut("/robot-commands/{id:int}", (int id, [FromBody] RobotCommand command) =>
{
    if (id < 0 || id >= robotCommands.Count)
    {
        return Results.NotFound(new { Message = $"Command with ID {id} not found" });
    }

    robotCommands[id] = command.Command;  // ✅ Assign only the string, not the object
    return Results.NoContent();
});

app.MapGet("/robot-map", () =>
{

    return Results.Ok(map);
});

app.MapGet("/robot-map/{x:int}-{y:int}", (int x, int y) =>
{
    int mapWidth = 5, mapHeight = 5;
    bool isWithinBounds = x >= 0 && x < mapWidth && y >= 0 && y < mapHeight;
    return Results.Ok(isWithinBounds);
});

app.MapPut("/robot-map", ([FromBody] RobotMap map) =>
{
    if (map.Width <= 0 || map.Height <= 0)
    {
        return Results.BadRequest(new { Message = "Invalid map size" });
    }
    return Results.NoContent();
});

app.Run();

// ✅ Define record correctly
public record RobotCommand(string Command);
public record RobotMap(int Width, int Height);
