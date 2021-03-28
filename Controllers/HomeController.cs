using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using XYZ.Models;
using XYZ.Services;

namespace XYZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelService _hotelService;
        private readonly IHomeService _homeService;
        public HomeController(ILogger<HomeController> logger,
                              IHotelService hotelService,
                              IHomeService homeService)
        {
            _logger = logger;
            _hotelService = hotelService;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return LocalRedirect("/Identity/Account/Login");
            var listHoteles = _hotelService.GetAllHotel();
            HomeViewModel model = new HomeViewModel();
            model.ListHoteles = listHoteles;
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(HomeViewModel model)
        {
            return RedirectToAction("HomeHabitacion", new { idHotel = model.HotelId });
        }

        public IActionResult HomeHabitacion(Guid idHotel)
        {
            if (!User.Identity.IsAuthenticated)
                return LocalRedirect("/Identity/Account/Login");
            if (idHotel == Guid.Empty)
                return RedirectToAction("Index");
            HomeViewModel model = new HomeViewModel();
            model.HotelId = idHotel;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HomeHabitacion(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.FechaSalida < model.FechaEntrega)
                {
                    TempData["mensaje"] = "la fecha de salida no puede ser menor a la fecha de entrega";
                    return View();
                }
                string fechaEntrega = model.FechaEntrega.ToString();
                string fechaSalida = model.FechaSalida.ToString();
                var habitaciones = await _homeService.GetSpHabitacionRangoFechas(fechaEntrega, fechaSalida, model.HotelId, model.CantidadPersona);
                if (habitaciones.Count <= 0)
                {
                    TempData["mensaje"] = "No se encuentra habitaciones disponibles con los parametros solicitados";
                    return View();
                }
                model = new HomeViewModel();
                model.ListHabitacionDisponibles = habitaciones;
            }
            return View(model);
        }

        public IActionResult TarifaCancelar()
        {
            if (!User.Identity.IsAuthenticated)
                return LocalRedirect("/Identity/Account/Login");
            return View();
        }
        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
