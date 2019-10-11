using eTravel.Models.Putovanje;
using eTravelData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eTravel.Controllers
{
    public class PutovanjeController : Controller
    {
        //Putovanje kontroler
        private IPutovanjeService _service;
        public PutovanjeController(IPutovanjeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {

            var putovanjeModels = _service.GetAll();

            var listingPutovanje = putovanjeModels
                .Select(result => new PutovanjeIndexListingModel
                {
                    Id = result.Id,
                    Naziv = result.Naziv,
                    Destinacija = result.Destinacija,
                    MaxUcesnika = result.MaxUcesnika,
                    DatumPolaska = result.DatumPolaska,
                    DatumPovratka = result.DatumPovratka,
                    DatumBookiranja = result.DatumBookiranja,
                    DjecaBool = result.DjecaBool,
                    Iznos = result.Iznos
                });

            var model = new PutovanjeIndexModel()
            {
                Putovanja = listingPutovanje
            };

            return View(model);
        }


    }
}
