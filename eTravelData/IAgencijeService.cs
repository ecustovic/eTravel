﻿using eTravelData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eTravelData
{
    public interface IAgencijeService
    {
        IEnumerable<Agencije> GetAll();
        Agencije GetById(int id);
        string GetPutovanje(int id);
    }
}
