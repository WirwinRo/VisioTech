using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visiotech.domain.Entities
{
    public class Manager
    {
        public int ManagerID { get; set; }
        public string TaxNumber { get; set; }
        public string Name { get; set; }

        public ICollection<Parcel> Parcels { get; set; } = new List<Parcel>();
    }
}
