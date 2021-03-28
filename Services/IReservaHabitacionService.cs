using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Data;
using XYZ.Domain;
using XYZ.Domain.SpModels;

namespace XYZ.Services
{
    public interface IReservaHabitacionService
    {
        Task<bool> RegistrarReservaHabitacion(ReservaHabitacion model);
        Task<bool> ActualizarReservaHabitacion(ReservaHabitacion model);
        ReservaHabitacion GetReservaHabitacionById(Guid? id);
        IEnumerable<ReservaHabitacion> GetAllReservaHabitacion();
    }
    public class ReservaHabitacionService : IReservaHabitacionService
    {
        #region Miembro
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public ReservaHabitacionService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Metodos
        public async Task<bool> ActualizarReservaHabitacion(ReservaHabitacion model)
        {
            try
            {
                _context.ReservaHabitacion.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<ReservaHabitacion> GetAllReservaHabitacion()
        {
            return _context.ReservaHabitacion.ToList();
        }

        public ReservaHabitacion GetReservaHabitacionById(Guid? id)
        {
            ReservaHabitacion model = null;
            if (id != null)
            {
                var reservaHabitacion = _context.ReservaHabitacion.Find(id);
                model = new ReservaHabitacion()
                {
                    Id = reservaHabitacion.Id,
                    FechaEntrega = reservaHabitacion.FechaEntrega,
                    FechaSalida = reservaHabitacion.FechaSalida,
                    Excedente = reservaHabitacion.Excedente,
                    ClientId = reservaHabitacion.ClientId,
                    HabitacionId = reservaHabitacion.HabitacionId
                };
            }
            return model;
        }

        public async Task<bool> RegistrarReservaHabitacion(ReservaHabitacion model)
        {
            try
            {
                await _context.ReservaHabitacion.AddAsync(model);
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
