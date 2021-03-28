using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Data;
using XYZ.Domain;
using XYZ.Models;

namespace XYZ.Services
{
    public interface IHotelService
    {
        Task<bool> RegistrarHotel(Hotel model);
        Task<bool> ActualizarHotel(Hotel model);
        Hotel GetHotelById(Guid? id);
        IEnumerable<Hotel> GetAllHotel();
        IEnumerable<TipoHotel> GetAllTipoHoles();
        IEnumerable<Ciudad> GetAllCiudades();
    }
    public class HotelService : IHotelService
    {
        #region Miembro
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public HotelService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region metodos
        public async Task<bool> ActualizarHotel(Hotel model)
        {
            try
            {
                _context.Hotel.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public IEnumerable<Hotel> GetAllHotel()
        {
            return _context.Hotel.ToList();
        }

        public Hotel GetHotelById(Guid? id)
        {
            Hotel model = null;
            if (id != null)
            {
                var hotel = _context.Hotel.Find(id);
                model = new Hotel()
                {
                    Id = hotel.Id,
                    Nombre = hotel.Nombre,
                    Descripcion = hotel.Descripcion,
                    TipoHotelId = hotel.TipoHotelId
                };
            }
            return model;
        }

        public async Task<bool> RegistrarHotel(Hotel model)
        {
            try
            {
                await _context.Hotel.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public IEnumerable<TipoHotel> GetAllTipoHoles()
        {
            return _context.TipoHotel.ToList();
        }

        public IEnumerable<Ciudad> GetAllCiudades()
        {
            return _context.Ciudad.OrderBy(x => x.Nombre).ToList();
        } 
        #endregion
    }
}
