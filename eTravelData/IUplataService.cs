using eTravelData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eTravelData
{
    public interface IUplataService
    {
        IEnumerable<Uplata> GetAll();
        Uplata GetById(int id);
        
    }
}
