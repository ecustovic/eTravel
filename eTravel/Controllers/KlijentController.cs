using eTravel.Models.Klijent;
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
    public class KlijentController : Controller
    {
        private IKlijentService _service;
        public KlijentController(IKlijentService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {

            //var klijentModels = _service.GetAll();

            //var listingKlijents = klijentModels
            //    .Select(result => new KlijentIndexListingModel
            //    {
            //        Id = result.Id,
            //        Ime = result.Ime,
            //        Prezime = result.Prezime,
            //        Telefon = result.Telefon,
            //        PostanskiBroj = result.PostanskiBroj,
            //        Grad = result.Grad,
            //        SlikaUrl = result.SlikaUrl,
            //        Iznos = _service.GetUplata(result.Id),
            //        Destinacija = _service.GetDestinacija(result.Id)
            //    });

            //var model = new KlijentIndexModel()
            //{
            //    Klijents = listingKlijents
            //};

            //return View(model);
            return View();
        }

        public IActionResult UcitajPodatke()
        {
            var klijenti = UcitajPodatkeIzCSV();
            Regex RgxPostanskiBroj = new Regex(@"^\d+$");

            var model = new KlijentUcitajModel()
            {
                Klijents = klijenti.Select( x=> new KlijentUcitajListingModel
                {
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    PostanskiBroj = x.PostanskiBroj,
                    Grad = x.Grad,
                    Telefon = x.Telefon,
                    ImaGresku = RgxPostanskiBroj.IsMatch(x.PostanskiBroj) == false
                }).ToList()
            };

            return View(model);
        }

        public IActionResult SpremiPodatke()
        {
            var model = new Models.Klijent.KlijentSpremiModel();

            var klijenti = UcitajPodatkeIzCSV();
            model.UkupniBrojKlijenata = klijenti.Count;

            foreach (var klijent in klijenti)
            {
                bool uspjeh = true;

                try
                {
                    _service.Add(klijent);
                }
                catch (SqlException ex)
                {
                    uspjeh = false;
                    model.ErrorList.Add(ex.Message);
                }

                if (uspjeh)
                    model.UspjesnoDodanihKlijenata++;

            }

            return View(model);
        }

        private static List<Klijent> UcitajPodatkeIzCSV()
        {
            List<Klijent> klijenti = new List<Klijent>();

            string folderPath = ConfigurationManager.AppSettings["PathToUserData"];
            if (folderPath == null)
                throw new Exception("The required configuration key is missing. ");

            string csvPath = folderPath + "/podaci.csv";

            var result = string.Empty;
            string worksheetsName = "data";

            bool firstRowIsHeader = false;
            var format = new ExcelTextFormat();
            format.Delimiter = ';';
            format.TextQualifier = '"';

            using (FileStream stm = new
                FileStream(csvPath, FileMode.Open,
                FileAccess.Read, FileShare.None))
            {
                using (var reader = new StreamReader(stm))
                using (ExcelPackage package = new ExcelPackage())
                {
                    result = reader.ReadToEnd();
                    ExcelWorksheet worksheet =
                    package.Workbook.Worksheets.Add(worksheetsName);
                    worksheet.Cells["A1"].LoadFromText(result, format, OfficeOpenXml.Table.TableStyles.Medium27, firstRowIsHeader);

                    var start = worksheet.Dimension.Start;
                    var end = worksheet.Dimension.End;
                    for (int row = start.Row; row <= end.Row; row++)
                    {
                        Klijent klijent = new Klijent
                        {
                            Ime = worksheet.Cells[row, 1].Text,
                            Prezime = worksheet.Cells[row, 2].Text,
                            PostanskiBroj = worksheet.Cells[row, 3].Text,
                            Grad = worksheet.Cells[row, 4].Text,
                            Telefon = worksheet.Cells[row, 5].Text,
                        };

                        klijenti.Add(klijent);

                    }

                }
            }

            return klijenti;
        }
    }
}
