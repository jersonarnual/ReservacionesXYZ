using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Data;
using XYZ.Domain;

namespace XYZ.Services
{
    public interface ITemporadaService
    {
        Task<bool> RegistrarTemporada(Temporada model);
        Task<bool> ActualizarTemporada(Temporada model);
        Temporada GetTemporadaById(Guid? id);
        IEnumerable<Temporada> GetAllTemporada();
    }
    public class TemporadaService : ITemporadaService
    {
        #region Miembro
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public TemporadaService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Metodos
        public async Task<bool> ActualizarTemporada(Temporada model)
        {
            try
            {
                _context.Temporada.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public IEnumerable<Temporada> GetAllTemporada()
        {
            return _context.Temporada.ToList();
        }

        public Temporada GetTemporadaById(Guid? id)
        {
            Temporada model = null;
            if (id != null)
            {
                var Temporada = _context.Temporada.Find(id);
                model = new Temporada()
                {
                    Id = Temporada.Id,
                    FechaFinal = Temporada.FechaFinal,
                    FechaInicio = Temporada.FechaInicio,
                    Tipo = Temporada.Tipo
                };

            }
            return model;
        }

        public async Task<bool> RegistrarTemporada(Temporada model)
        {
            try
            {
                await _context.Temporada.AddAsync(model);
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

