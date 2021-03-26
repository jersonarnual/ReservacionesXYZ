using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Domain;
using XYZ.Models;
using XYZ.Services;

namespace XYZ.Controllers
{
    public class HotelController : Controller
    {
        #region Miembros
        private readonly IHotelService _hotelService;

        #endregion

        #region Constructor
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        #endregion

        #region Metodos

        public ActionResult Index()
        {
            HotelViewModel model = new HotelViewModel();
            IEnumerable<Hotel> listHoteles = _hotelService.GetAllHotel();
            if (listHoteles != null || listHoteles.Any())
                model.listHotelViewModels = listHoteles;
            return View(model);
        }

        public ActionResult RegistrarHotel() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegistrarHotel(HotelViewModel model)
        {
            if (ModelState.IsValid)
            {
                Hotel hotel = new Hotel()
                {
                    Id = Guid.NewGuid(),
                    Nombre = model.Nombre,
                    Calificacion = model.Calificacion
                };

                var resultado = await _hotelService.RegistrarHotel(hotel);
                if (resultado)
                    TempData["mensaje"] = $"Se Registro Correctamente el hotel {model.Nombre}";
                else
                    TempData["mensaje"] = $"Ocurrio un problema al tratar de registrar el hotel {model.Nombre}";
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult ActualizarHotel(Guid? id)
        {
            if (id == null)
            {
                TempData["mensaje"] = $"No se envia identificador";
                return RedirectToAction("Index");
            }
            Hotel hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                TempData["mensaje"] = $"El hotel no se encuentra registrado";
                return RedirectToAction("Index");
            }
            HotelViewModel model = new HotelViewModel()
            {
                Id = hotel.Id,
                Nombre = hotel.Nombre,
                Calificacion = hotel.Calificacion
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActualizarHotel(HotelViewModel model)
        {
            Hotel hotel = new Hotel()
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Calificacion = model.Calificacion
            };
            var resultado = await _hotelService.ActualizarHotel(hotel);
            if (resultado)
                TempData["mensaje"] = $"Se Actualiza correctamente el hotel {model.Nombre}";
            else
                TempData["mensaje"] = $"Ocurrio un problema al tratar de registrar el hotel {model.Nombre}";
            return RedirectToAction("Index");
        }

        #endregion

    }
}
