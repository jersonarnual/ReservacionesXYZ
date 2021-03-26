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
    public class TemporadaController : Controller
    {

        #region Miembros
        private readonly ITemporadaService _temporadaService;
        #endregion

        #region Constructor
        public TemporadaController(ITemporadaService temporadaService)
        {
            _temporadaService = temporadaService;
        }
        #endregion

        #region Metodos
        public ActionResult Index()
        {
            var temporada = _temporadaService.GetAllTemporada();
            TemporadaViewModel model = new TemporadaViewModel();
            model.ListTemporadas = temporada;
            return View(model);
        }

        public IActionResult RegistrarTemporada() => View();

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> RegistrarTemporada(TemporadaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Temporada temporada = new Temporada()
                {
                    Id = model.Id,
                    FechaInicio = model.FechaInicio,
                    FechaFinal = model.FechaFinal,
                    Tipo = model.Tipo,
                    CreateBy = User.Identity.Name,
                    CreateTime = DateTime.Now
                };
                var resultado = await _temporadaService.RegistrarTemporada(temporada);
                if (resultado)
                    TempData["mensaje"] = $"Se Registro Correctamente la Temporada";
                else
                    TempData["mensaje"] = $"Ocurrio un problema al tratar de Registro la Temporada";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult ActualizarTemporada(Guid Id)
        {
            var temporada = _temporadaService.GetTemporadaById(Id);
            if (temporada == null)
            {
                TempData["mensaje"] = $"No se encuentra registrada el precio de la habitacion";
                return RedirectToAction("Index");
            }
            TemporadaViewModel model = new TemporadaViewModel()
            {
                Id = temporada.Id,
                FechaInicio = temporada.FechaInicio,
                FechaFinal = temporada.FechaFinal,
                Tipo = temporada.Tipo
            };
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ActualizarTemporada(TemporadaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Temporada temporada = new Temporada()
                {
                    Id = model.Id,
                    FechaInicio = model.FechaInicio,
                    FechaFinal = model.FechaFinal,
                    Tipo = model.Tipo,
                    UpdateBy = User.Identity.Name,
                    UpdateTime = DateTime.Now
                };
                var resultado = await _temporadaService.ActualizarTemporada(temporada);
                if (resultado)
                    TempData["mensaje"] = $"Se Actualizo Correctamente la Temporada";
                else
                    TempData["mensaje"] = $"Ocurrio un problema al tratar de actualizar la Temporada";
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion
    }
}
