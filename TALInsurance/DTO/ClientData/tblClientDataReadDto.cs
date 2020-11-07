using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TALInsurance.DTO.ClientData
{
    public class tblClientDataReadDto
    {
        public int SlNo { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string Occupation { get; set; }
        public double SumInsured { get; set; }
    }
}
