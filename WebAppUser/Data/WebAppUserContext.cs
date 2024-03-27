using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppUser.Models;

namespace WebAppUser.Data
{
    public class WebAppUserContext : DbContext
    {
        public WebAppUserContext (DbContextOptions<WebAppUserContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppUser.Models.UsuarioModel> UsuarioModel { get; set; } = default!;

        public DbSet<WebAppUser.Models.CarrosModel>? CarrosModel { get; set; }
    }
}
