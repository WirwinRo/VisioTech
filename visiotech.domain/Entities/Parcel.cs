using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visiotech.domain.Entities
{
    public class Parcel
    {
        public int ParcelID { get; set; }
        public string Name { get; set; }
        public int VineyardID { get; set; }
        public int ManagerID { get; set; }
        public int GrapeID { get; set; }
        public int Area { get; set; }
        public int Year { get; set; }

        public Manager Manager { get; set; }
        public Vineyard Vineyard { get; set; }
        public Grape Grape { get; set; }

    }
}
