using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visiotech.application.Dtos
{
    public class ParcelDto
    {
        public int ParcelID { get; set; }
        public string Name { get; set; }
        public int VineyardID { get; set; }
        public int ManagerID { get; set; }
        public int GrapeID { get; set; }
        public int Area { get; set; }
        public int Year { get; set; }

        public ManagerDto Manager { get; set; }
        public VineyardDto Vineyard { get; set; }
        public GrapeDto Grape { get; set; }

    }
}
