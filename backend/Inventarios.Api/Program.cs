using Inventarios.Api.Datos;
using Microsoft.EntityFrameworkCore;

var constructor = WebApplication.CreateBuilder(args);

// Registrar los servicios de la API.

constructor.Services.AddControllers();
constructor.Services.AddDbContext<ContextoInventarios>(opciones =>
    opciones.UseSqlServer(constructor.Configuration.GetConnectionString("Inventarios")));
// Generar la documentación de los endpoints con OpenAPI.
constructor.Services.AddOpenApi();

var aplicacion = constructor.Build();

// Configurar el procesamiento de las solicitudes HTTP.
if (aplicacion.Environment.IsDevelopment())
{
    aplicacion.MapOpenApi();
}

aplicacion.UseHttpsRedirection();

aplicacion.UseAuthorization();

aplicacion.MapControllers();

aplicacion.Run();
