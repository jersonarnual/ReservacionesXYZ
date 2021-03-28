using Microsoft.AspNetCore.Http;
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
    public class TipoHabitacionController : Controller
    {
        #region Miembro
        private readonly ITipoHabitacionService _tipoHabitacionService;
        #endregion

        #region Constructor
        public TipoHabitacionController(ITipoHabitacionService tipoHabitacionService)
        {
            _tipoHabitacionService = tipoHabitacionService;
        }
        #endregion

        #region Metodos
        public ActionResult Index()
        {
            TipoHabitacionViewModel model = new TipoHabitacionViewModel();
            var listaTipoHabitaciones = _tipoHabitacionService.GetAllTipoHabitacion();
            model.ListTipoHabitaciones = listaTipoHabitaciones;
            return View(model);
        }
        public IActionResult RegistrarTipoHabitacion()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarTipoHabitacion(TipoHabitacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                TipoHabitacion tipoHabitacion = new TipoHabitacion()
                {
                    Id = Guid.NewGuid(),
                    Nombre = model.Nombre,
                    Descripcion=model.Descripcion,
                    Camas = model.Camas,
                    Capacidad = model.Capacidad,
                    Banhio = model.Banhio,
                    Salon = model.Salon,
                    Terraza = model.Terraza,
                    CreateTime = DateTime.Now,
                    CreateBy = User.Identity.Name
                };
                var resultado = await _tipoHabitacionService.RegistrarTipoHabitacion(tipoHabitacion);
                if (resultado)
                    TempData["mensaje"] = $"Se Registro Correctamente el tipo de habitacion";
                else
                    TempData["mensaje"] = $"Ocurrio un problema al tratar de registrar el tipo de habitacion";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult ActualizarTipoHabitacion(Guid Id)
        {
            var tipoCapacitacion = _tipoHabitacionService.GetTipoHabitacionById(Id);
            if (tipoCapacitacion == null)
            {
                TempData["mensaje"] = $"No se encuentra registrada el tipo de habitacion";
                return RedirectToAction("Index");
            }
            TipoHabitacionViewModel model = new TipoHabitacionViewModel()
            {
                Id = tipoCapacitacion.Id,
                Nombre = tipoCapacitacion.Nombre,
                Descripcion= tipoCapacitacion.Descripcion,
                Camas = tipoCapacitacion.Camas,
                Capacidad = tipoCapacitacion.Capacidad,
                Banhio = tipoCapacitacion.Banhio,
                Salon = tipoCapacitacion.Salon,
                Terraza = tipoCapacitacion.Terraza
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarTipoHabitacion(TipoHabitacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                TipoHabitacion tipoHabitacion = new TipoHabitacion()
                {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    Descripcion =model.Descripcion,
                    Camas = model.Camas,
                    Capacidad = model.Capacidad,
                    Banhio = model.Banhio,
                    Salon = model.Salon,
                    Terraza = model.Terraza,
                    UpdateBy = User.Identity.Name,
                    UpdateTime = DateTime.Now
                };
                var resultado = await _tipoHabitacionService.ActualizarTipoHabitacion(tipoHabitacion);
                if (resultado)
                    TempData["mensaje"] = $"Se Actualizo Correctamente el tipo de habitacion";
                else
                    TempData["mensaje"] = $"Ocurrio un problema al tratar de actualizar el tipo de habitacion";
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion
    }
}
