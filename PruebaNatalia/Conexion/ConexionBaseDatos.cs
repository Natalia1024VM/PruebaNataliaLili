using Microsoft.EntityFrameworkCore;

namespace PruebaNatalia.Conexion
{
    public class ConexionBaseDatos : DbContext
    {

        public ConexionBaseDatos(DbContextOptions<ConexionBaseDatos> options) : base(options)
        {


        }
    }
}
