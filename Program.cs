var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
    {
        System.Console.WriteLine("GET / called at " + DateTime.Now);
        return "Hello from Minimal API";
    }
);

app.MapPost("/logParam", (string message) =>
    {

        System.Console.WriteLine($"POST /log: {message} ");
        return Results.Ok(new { Success = true, message = "Logged" });
    }
);

app.MapPost("/logJson", (LogRequest request) =>
    {
        if (string.IsNullOrEmpty(request.Message))
        {
            return Results.BadRequest("Message is required");
        }
        System.Console.WriteLine($"JSON: {request.Source ?? "Unknown"}:{request.Message}");
        return Results.Ok(new { Success = true, Received = request});
    }
);

app.Run();
