using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TALInsurance.Models
{
    public class tblClientData
    {
        [Key]
        public int SlNo { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string Occupation { get; set; }
        public double SumInsured { get; set; }
    }

    public class tblOccupationMapping
    {
        public string Occupation { get; set; }
        [Key]
        public int Slno { get; set; }        
        public string Rating { get; set; }
    }


    public class tblOccupationRating
    {
        [Key]
        public int Slno { get; set; }
        public string Rating { get; set; }
        public double Factor { get; set; }
    }
}
