using eTravel.Models.Uplata;
using eTravelData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eTravel.Controllers
{
    //Uplata kontroler
    public class UplataController : Controller
    {
        private IUplataService _service;
        public UplataController(IUplataService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {

            var uplateModels = _service.GetAll();

            var listingUplate = uplateModels
                .Select(result => new UplataIndexListingModel
                {
                    Id = result.Id,
                    DatumUplate = result.DatumUplate,
                    Iznos = result.Iznos
                });

            var model = new UplataIndexModel()
            {
                Uplate = listingUplate
            };

            return View(model);
        }

    }
}
