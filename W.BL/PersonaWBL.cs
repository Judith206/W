using System;
using W.EN;
using W.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W.BL
{
    public class PersonaWBL
    {
        private readonly PersonaWDAL _PersonaWDAL;

        public PersonaWBL(PersonaWDAL personaWDAL)
        {
            _PersonaWDAL = personaWDAL;
        }
        public async Task<int> CrearAsync(PersonaW pPersonaW)
        {
            return await _PersonaWDAL.CrearAsync(pPersonaW);
        }
        public async Task<int> ModificarAsync(PersonaW pPersonaW)
        {
            return await _PersonaWDAL.ModificarAsync(pPersonaW);
        }
        public async Task<int> EliminarAsync(PersonaW pPersonaW)
        {
            return await _PersonaWDAL.EliminarAsync(pPersonaW);
        }

        public async Task<PersonaW> ObtenerPorIdAsync(PersonaW pPersonaW)
        {
            return await _PersonaWDAL.ObtenerPorIdAsync(pPersonaW);
        }

        public async Task<List<PersonaW>> ObtenerTodosAsync()
        {
            return await _PersonaWDAL.ObtenerTodosAsync();
        }
        public Task AgregarTodosAsync(List<PersonaW> pPersonaW)
        {
            return _PersonaWDAL.AgregarTodosAsync(pPersonaW);
        }
        //aqui 
        public async Task<List<PersonaW>> BuscarPorNombreApellidoAsync(string nombre, string apellido)
        {
            return await _PersonaWDAL.BuscarPorNombreApellidoAsync(nombre, apellido);
        }
    }
}
