using Microsoft.EntityFrameworkCore;

namespace Inventarios.Api.Datos;

public class ContextoInventarios : DbContext
{
    public ContextoInventarios(DbContextOptions<ContextoInventarios> opciones)
        : base(opciones)
    {
    }
}
