using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Domain;
using XYZ.Models;
using XYZ.Services;

namespace XYZ.Controllers
{
    public class PrecioHabitacionController : Controller
    {
        #region Miembros
        private readonly IPrecioHabitacionService _precioHabitacionService;
        private readonly ITemporadaService _temporadaService;
        private readonly ITipoHabitacionService _tipoHabitacionService;
        #endregion

        #region Constructor
        public PrecioHabitacionController(IPrecioHabitacionService precioHabitacionService,
                                          ITemporadaService temporadaService,
                                          ITipoHabitacionService tipoHabitacionService)
        {
            _precioHabitacionService = precioHabitacionService;
            _temporadaService = temporadaService;
            _tipoHabitacionService = tipoHabitacionService;
        }
        #endregion

        #region Metodos
        public ActionResult Index()
        {
            var precioHabitaciones = _precioHabitacionService.GetAllPrecioHabitacion();
            foreach (var item in precioHabitaciones) 
            {
                var temporada = _temporadaService.GetTemporadaById(item.TemporadaId);
                var tipoHabitacion = _tipoHabitacionService.GetTipoHabitacionById(item.TipoHabitacionId);
                item.TipoHabitaciones = tipoHabitacion;
                item.Temporada = temporada;
            }
            PrecioHabitacionViewModel model = new PrecioHabitacionViewModel();
            model.ListPrecioHabitaciones = precioHabitaciones;
            return View(model);
        }

        public IActionResult RegistrarPrecioHabitacion()
        {
            var temporadas = _temporadaService.GetAllTemporada();
            var tipoHabitaciones = _tipoHabitacionService.GetAllTipoHabitacion();
            PrecioHabitacionViewModel model = new PrecioHabitacionViewModel();
            model.ListTipoHabitaciones = new SelectList(tipoHabitaciones, "Id", "Nombre");
            model.ListTemporadas = new SelectList(temporadas, "Id", "Tipo");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarPrecioHabitacion(PrecioHabitacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                PrecioHabitacion precioHabitacion = new PrecioHabitacion()
                {
                    Id = Guid.NewGuid(),
                    Precio = model.Precio,
                    TemporadaId = model.TemporadaId,
                    TipoHabitacionId = model.TipoHabitacionId,
                    CreateBy = User.Identity.Name,
                    CreateTime = DateTime.Now
                };
                var resultado = await _precioHabitacionService.RegistrarPrecioHabitacion(precioHabitacion);
                if (resultado)
                    TempData["mensaje"] = $"Se Registro Correctamente el precio de la habitacion";
                else
                    TempData["mensaje"] = $"Ocurrio un problema al tratar de registrar los precios de la habitacion";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult ActualizarPrecioHabitacion(Guid Id)
        {
            var precioHabitacion = _precioHabitacionService.GetPrecioHabitacionById(Id);
            if (precioHabitacion == null)
            {
                TempData["mensaje"] = $"No se encuentra registrada el precio de la habitacion";
                return RedirectToAction("Index");
            }
            var temporadas = _temporadaService.GetAllTemporada();
            var tipoHabitaciones = _tipoHabitacionService.GetAllTipoHabitacion();
            PrecioHabitacionViewModel model = new PrecioHabitacionViewModel()
            {
                Id = precioHabitacion.Id,
                Precio = precioHabitacion.Precio,
                TemporadaId = precioHabitacion.TemporadaId,
                TipoHabitacionId = precioHabitacion.TipoHabitacionId,
                ListTemporadas = new SelectList(temporadas, "Id", "Tipo"),
                ListTipoHabitaciones = new SelectList(tipoHabitaciones, "Id", "Nombre")
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarPrecioHabitacion(PrecioHabitacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                PrecioHabitacion precioHabitacion = new PrecioHabitacion()
                {
                    Id = model.Id,
                    Precio = model.Precio,
                    TemporadaId = model.TemporadaId,
                    TipoHabitacionId = model.TipoHabitacionId,
                    UpdateTime = DateTime.Now,
                    UpdateBy = User.Identity.Name
                };
                var resultado = await _precioHabitacionService.ActualizarPrecioHabitacion(precioHabitacion);
                if (resultado)
                    TempData["mensaje"] = $"Se Actualizo Correctamente el precio de la habitacion";
                else
                    TempData["mensaje"] = $"Ocurrio un problema al tratar de Actualizar el precios de la habitacion";
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion
    }
}
