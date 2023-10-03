using cad_cliente.Models;
using Microsoft.EntityFrameworkCore;

namespace cad_cliente.Data
{
    public class AppCont : DbContext
    {
        public AppCont(DbContextOptions<AppCont> options) : base(options)
        {

        }

        public DbSet<Client> Clientes { get; set; }
    }
}
