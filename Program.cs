var builder = WebApplication.CreateBuilder(args);

// Configurações API
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilita arquivos estáticos
app.UseStaticFiles(); 

// Serve o arquivo index.html na raiz
app.MapGet("/", () => Results.File(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html")));

// Configura o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Criptografia para o HTTPS (CGPT)

// Registra as rotas das controllers
app.MapControllers(); 

app.Run();
