using eTravel.Models.Agencije;
using eTravelData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eTravel.Controllers
{
    //Agencije kontroler
    public class AgencijeController : Controller
    {
        private IAgencijeService _service;
        public AgencijeController(IAgencijeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {

            var agencijeModels = _service.GetAll();

            var listingAgencije = agencijeModels
                .Select(result => new AgencijeIndexListingModel
                {
                    Id = result.Id,
                    Naziv = result.Naziv,
                    Telefon = result.Telefon,
                    Manager = result.Manager,
                    Adresa = result.Adresa,
                    SlikaUrl = result.SlikaUrl,
                    Putovanje = _service.GetPutovanje(result.Id)
                });

            var model = new AgencijeIndexModel()
            {
                Agencije = listingAgencije
            };

            return View(model);
        }

    }
}
