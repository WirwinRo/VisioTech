﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visiotech.domain.Entities;

namespace visiotech.domain.Interfaces
{
    public interface IVineyardRepository : ICommonRepository<Vineyard>
    {
        Task<Dictionary<String, List<string>>> GetVineyardManager();
    }
}
