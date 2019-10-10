using eTravelData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eTravelData
{
    public interface IKlijentService
    {
        IEnumerable<Klijent> GetAll();
        Klijent GetById(int id);
        void Add(Klijent newKlijent);
        decimal GetUplata(int id);
        string GetDestinacija(int id);

    }
}
