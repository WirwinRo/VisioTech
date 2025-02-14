using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visiotech.application.Dtos
{
    public class ManagerDto
    {
        public int ManagerID { get; set; }
        public string TaxNumber { get; set; }
        public string Name { get; set; }

        public ICollection<ParcelDto> Parcels { get; set; } = new List<ParcelDto>();
    }
}
