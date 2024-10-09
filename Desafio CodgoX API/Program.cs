var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/sum", (string? a, string? b) =>
{
    
    if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b))
    {
        return Results.BadRequest(new { error = "Os parâmetros de consulta 'a' e 'b' são obrigatórios." });
    }
    if (!double.TryParse(a, out double numA) || !double.TryParse(b, out double numB))
    {
        return Results.BadRequest(new { error ="'a' e 'b' devem ser números válidos."});
    }
    var result = numA + numB;
    result = Math.Round(result,2);
    return Results.Ok(new { result });
});

app.Run();


