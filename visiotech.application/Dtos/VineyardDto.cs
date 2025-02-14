using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visiotech.application.Dtos
{
    public class VineyardDto
    {
        public int VineyardID { get; set; }
        public string Name { get; set; }

        public ICollection<ParcelDto> Parcels { get; set; } = new List<ParcelDto>();
    }
}
