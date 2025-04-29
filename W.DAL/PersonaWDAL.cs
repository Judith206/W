using System;
using W.EN;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace W.DAL
{
    public class PersonaWDAL
    {
        readonly PersonaWDBContext _dbContext;
        private int Id;


        public PersonaWDAL(PersonaWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<int> CrearAsync(PersonaW pPersonaW)
        {
            PersonaW personaw = new PersonaW()
            {
                Id = pPersonaW.Id,
                NombreW = pPersonaW.NombreW,
                ApellidoW = pPersonaW.ApellidoW,
                FechaNacimientoW = pPersonaW.FechaNacimientoW,
                SueldoW = pPersonaW.SueldoW,
                EstatusW = pPersonaW.EstatusW,
                ComentarioW = pPersonaW.ComentarioW,
            };
            _dbContext.Add(personaw);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> EliminarAsync(PersonaW pPersonaW)
        {
            var personaw = _dbContext.PersonasW.FirstOrDefault(s => s.Id == pPersonaW.Id);
            if (personaw != null)
            {
                _dbContext.PersonasW.Remove(personaw);
                return await _dbContext.SaveChangesAsync();
            }
            else
                return 0;
        }

        public async Task<int> ModificarAsync(PersonaW pPersonaW)
        {
            var personaw = await _dbContext.PersonasW.FirstOrDefaultAsync(s => s.Id == pPersonaW.Id);
            if (personaw != null && personaw.Id > 0)

            {
                personaw.NombreW = pPersonaW.NombreW;
                personaw.ApellidoW = pPersonaW.ApellidoW;
                personaw.FechaNacimientoW = pPersonaW.FechaNacimientoW;
                personaw.SueldoW = pPersonaW.SueldoW;
                personaw.EstatusW = pPersonaW.EstatusW;
                personaw.ComentarioW = pPersonaW.ComentarioW;

                return await _dbContext.SaveChangesAsync();
            }
            else
                return 0;
        }
        public async Task<PersonaW> ObtenerPorIdAsync(PersonaW pPersonaW)
        {
            var personaw = await _dbContext.PersonasW.FirstOrDefaultAsync(s => s.Id == pPersonaW.Id);
            if (personaw != null && personaw.Id != 0)
            {
                return new PersonaW
                {
                    Id = personaw.Id,
                    NombreW = personaw.NombreW,
                    ApellidoW = personaw.ApellidoW,
                    FechaNacimientoW = personaw.FechaNacimientoW,
                    SueldoW = personaw.SueldoW,
                    EstatusW = personaw.EstatusW,
                    ComentarioW = personaw.ComentarioW
                };
            }
            else
                return new PersonaW();
        }

        public async Task<List<PersonaW>> ObtenerTodosAsync()
        {
            var personasw = await _dbContext.PersonasW.ToListAsync();
            if (personasw != null && personasw.Count > 0)
            {
                var list = new List<PersonaW>();
                personasw.ForEach(s => list.Add(new PersonaW
                {
                    Id = s.Id,
                    NombreW = s.NombreW,
                    ApellidoW = s.ApellidoW,
                    FechaNacimientoW = s.FechaNacimientoW,
                    SueldoW = s.SueldoW,
                    EstatusW = s.EstatusW,
                    ComentarioW = s.ComentarioW
                }));
                return list;
            }
            else
                return new List<PersonaW>();
        }

        public async Task AgregarTodosAsync(List<PersonaW> pPersonaW)
        {
            await _dbContext.PersonasW.AddRangeAsync(pPersonaW);
            await _dbContext.SaveChangesAsync();
        }
        //aqui
        public async Task<List<PersonaW>> BuscarPorNombreApellidoAsync(string nombre, string apellido)
        {
            var query = _dbContext.PersonasW.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(p => p.NombreW.Contains(nombre));

            if (!string.IsNullOrEmpty(apellido))
                query = query.Where(p => p.ApellidoW.Contains(apellido));

            return await query.ToListAsync();
        }
    }
}
