using Microsoft.EntityFrameworkCore;
using System;
using W.EN;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W.DAL
{
    public class PersonaWDBContext : DbContext
    {
        public PersonaWDBContext(DbContextOptions<PersonaWDBContext> options) : base(options)
        {

        }

        public DbSet<PersonaW> PersonasW { get; set; }
    }


}
