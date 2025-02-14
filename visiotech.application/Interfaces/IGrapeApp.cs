using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visiotech.application.Dtos;

namespace visiotech.application.Interfaces
{
    public interface IGrapeApp : ICommonApp<GrapeDto>
    {
        Task<Dictionary<String, int>> GetGrapeByArea();
    }
}
