using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Data;
using XYZ.Domain;

namespace XYZ.Services
{
    public interface ITipoHabitacionService
    {
        Task<bool> RegistrarTipoHabitacion(TipoHabitacion model);
        Task<bool> ActualizarTipoHabitacion(TipoHabitacion model);
        TipoHabitacion GetTipoHabitacionById(Guid? id);
        IEnumerable<TipoHabitacion> GetAllTipoHabitacion();
    }
    public class TipoHabitacionService : ITipoHabitacionService
    {
        #region Miembro
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public TipoHabitacionService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Metodos
        public async Task<bool> ActualizarTipoHabitacion(TipoHabitacion model)
        {
            try
            {
                _context.TipoHabitacion.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public IEnumerable<TipoHabitacion> GetAllTipoHabitacion()
        {
            var result = _context.TipoHabitacion.ToList();
            return result;
        }

        public TipoHabitacion GetTipoHabitacionById(Guid? id)
        {
            TipoHabitacion model = null;
            if (id != null)
            {
                var tipoHabitacion = _context.TipoHabitacion.Find(id);
                model = new TipoHabitacion()
                {
                    Id = tipoHabitacion.Id,
                    Nombre = tipoHabitacion.Nombre,
                    Camas = tipoHabitacion.Camas,
                    Capacidad = tipoHabitacion.Capacidad,
                    Banhio = tipoHabitacion.Banhio,
                    Salon = tipoHabitacion.Salon,
                    Terraza = tipoHabitacion.Terraza
                };
            }
            return model;
        }

        public async Task<bool> RegistrarTipoHabitacion(TipoHabitacion model)
        {
            try
            {
                await _context.TipoHabitacion.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        #endregion
    }
}
