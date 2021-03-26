using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Data;
using XYZ.Domain;

namespace XYZ.Services
{
    public interface IPrecioHabitacionService
    {
        Task<bool> RegistrarPrecioHabitacion(PrecioHabitacion model);
        Task<bool> ActualizarPrecioHabitacion(PrecioHabitacion model);
        PrecioHabitacion GetPrecioHabitacionById(Guid? id);
        IEnumerable<PrecioHabitacion> GetAllPrecioHabitacion();
    }
    public class PrecioHabitacionService : IPrecioHabitacionService
    {
        #region Miembro
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public PrecioHabitacionService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Metodos
        public async Task<bool> ActualizarPrecioHabitacion(PrecioHabitacion model)
        {
            try
            {
                _context.PrecioHabitacion.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public IEnumerable<PrecioHabitacion> GetAllPrecioHabitacion()
        {
            return _context.PrecioHabitacion.ToList();
        }

        public PrecioHabitacion GetPrecioHabitacionById(Guid? id)
        {
            PrecioHabitacion model = null;
            if (id != null)
            {
                var precioHabitacion = _context.PrecioHabitacion.Find(id);
                model = new PrecioHabitacion()
                {
                    Id = precioHabitacion.Id,
                    Precio = precioHabitacion.Precio,
                    TemporadaId = precioHabitacion.TemporadaId,
                    TipoHabitacionId = precioHabitacion.TipoHabitacionId
                };
            }
            return model;
        }

        public async Task<bool> RegistrarPrecioHabitacion(PrecioHabitacion model)
        {
            try
            {
                await _context.PrecioHabitacion.AddAsync(model);
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
