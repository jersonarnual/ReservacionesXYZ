using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Data;
using XYZ.Domain;
using XYZ.Models;
using XYZ.Services;

namespace XYZ.Controllers
{
    public class HabitacionController : Controller
    {

        #region Miembros
        private readonly IHabitacionService _habitacionService;
        private readonly ITipoHabitacionService _tipoHabitacionService;
        private readonly IHotelService _hotelService;
        #endregion

        #region Contructor
        public HabitacionController(IHabitacionService habitacionService,
                                    ITipoHabitacionService tipoHabitacionService,
                                    IHotelService hotelService)
        {
            _habitacionService = habitacionService;
            _tipoHabitacionService = tipoHabitacionService;
            _hotelService = hotelService;
        }
        #endregion

        #region Metodos
        public IActionResult Index()
        {
            HabitacionViewModel model = new HabitacionViewModel();
            var listHabitaciones = _habitacionService.GetAllHabitacion();
            foreach (var item in listHabitaciones)
            {
                var hotel = _hotelService.GetHotelById(item?.HotelId);
                var tipoHabitacion = _tipoHabitacionService.GetTipoHabitacionById(item?.TipoHabitacionId);
                item.Hotel = hotel;
                item.TipoHabitacion = tipoHabitacion;
            }
            model.ListHabitaciones = listHabitaciones;
            return View(model);
        }

        public IActionResult RegistrarHabitacion()
        {
            HabitacionViewModel model = new HabitacionViewModel();
            var listTipoHabitacion = _tipoHabitacionService.GetAllTipoHabitacion();
            var listHoteles = _hotelService.GetAllHotel();
            model.ListaTipoHabitacion = new SelectList(listTipoHabitacion, "Id", "Descripcion");
            model.ListaHoteles = new SelectList(listHoteles, "Id", "Nombre");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarHabitacion(HabitacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Habitacion habitacion = new Habitacion()
                {
                    Nombre = model.Nombre,
                    TipoHabitacionId = model.TipoHabitacionId,
                    HotelId = model.HotelId,
                    CreateTime = DateTime.Now,
                    CreateBy = User.Identity.Name

                };
                var resultado = await _habitacionService.RegistrarHabitacion(habitacion);
                if (resultado)
                    TempData["mensaje"] = $"Se Registro Correctamente la habitacion";
                else
                    TempData["mensaje"] = $"Ocurrio un problema al tratar de registrar la habitacion";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult ActualizarHabitacion(int id)
        {
            var habitacion = _habitacionService.GetHabitacionById(id);
            if (habitacion == null)
            {
                TempData["mensaje"] = $"No se encuentra registrada la habitacion con numeron {id}";
                return RedirectToAction("Index");
            }
            var listTipoHabitacion = _tipoHabitacionService.GetAllTipoHabitacion();
            var listHoteles = _hotelService.GetAllHotel();
            HabitacionViewModel model = new HabitacionViewModel()
            {
                Id = habitacion.Id,
                Nombre = habitacion.Nombre,
                TipoHabitacionId = habitacion.TipoHabitacionId,
                HotelId = habitacion.HotelId,
                ListaTipoHabitacion = new SelectList(listTipoHabitacion, "Id", "Descripcion"),
                ListaHoteles = new SelectList(listHoteles, "Id", "Nombre")
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarHabitacion(HabitacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Habitacion habitacion = new Habitacion()
                {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    TipoHabitacionId = model.TipoHabitacionId,
                    HotelId = model.HotelId,
                    UpdateTime = DateTime.Now,
                    UpdateBy = User.Identity.Name
                };
                var resultado = await _habitacionService.ActualizarHabitacion(habitacion);
                if (resultado)
                    TempData["mensaje"] = $"Se Actualizo Correctamente la habitacion";
                else
                    TempData["mensaje"] = $"Ocurrio un problema al tratar de actualizar la habitacion";
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion
    }
}
