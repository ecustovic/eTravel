using eTravelData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eTravelData
{
    public interface IPutovanjeService
    {
        IEnumerable<Putovanje> GetAll();
        Putovanje GetById(int id);
    }
}
