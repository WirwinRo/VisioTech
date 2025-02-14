using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visiotech.api.Dtos
{
    public class GrapeDto
    {
        public int GrapeID { get; set; }
        public string Name { get; set; }

        public ICollection<ParcelDto> Parcels { get; set; } = new List<ParcelDto>();

    }
}
