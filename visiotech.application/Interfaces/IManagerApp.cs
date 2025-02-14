using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visiotech.application.Dtos;

namespace visiotech.application.Interfaces
{
    public interface IManagerApp : ICommonApp<ManagerDto>
    {
        Task<Dictionary<String, int>> GetManagerArea();
    }
}
