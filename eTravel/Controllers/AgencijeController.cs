using eTravel.Models.Agencije;
using eTravelData;
using eTravelData.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace eTravel.Controllers
{
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

        public IActionResult Detail(int id)
        {
            var result = _service.GetById(id);
            var model = new AgencijeDetailModel
            {
                Id = result.Id,
                Naziv = result.Naziv,
                Telefon = result.Telefon,
                Manager = result.Manager,
                Adresa = result.Adresa,
                SlikaUrl = result.SlikaUrl,
                Putovanje = _service.GetPutovanje(result.Id)
            };

            return View(model);
        }





    }
}
