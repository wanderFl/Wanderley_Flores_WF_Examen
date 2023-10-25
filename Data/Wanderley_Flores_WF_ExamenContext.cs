using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wanderley_Flores_WF_Examen.Models;

namespace Wanderley_Flores_WF_Examen.Data
{
    public class Wanderley_Flores_WF_ExamenContext : DbContext
    {
        public Wanderley_Flores_WF_ExamenContext (DbContextOptions<Wanderley_Flores_WF_ExamenContext> options)
            : base(options)
        {
        }

        public DbSet<Wanderley_Flores_WF_Examen.Models.reserva> reserva { get; set; } = default!;
    }
}
