using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClaseContexto : DbContext
    {
        public ClaseContexto(DbContextOptions<ClaseContexto> options) : base(options)
        {
        }
        public DbSet<RolesModelo> Roles { get; set; }
        public DbSet<UsuarioModelo> Usuarios { get; set; }
        public DbSet<AdministradorModelo> Administrador { get; set; }
        public DbSet<EspecialidadModelo> Especialidad { get; set; }
        public DbSet<DoctorModelo> Doctor { get; set; }
        public DbSet<HorarioModelo> Horario { get; set; }
        public DbSet<CitaModelo> Citas { get; set; }


    }
}
