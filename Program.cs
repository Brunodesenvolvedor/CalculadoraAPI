var builder = WebApplication.CreateBuilder(args);

// Configurações API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilita arquivos estáticos
app.UseStaticFiles();

// Redireciona "/" para "/index.html"
app.MapGet("/", context =>
{
    context.Response.Redirect("/index.html");
    return Task.CompletedTask;
});

// Registra as rotas das controllers
app.MapControllers();

app.Run();
