using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TALInsurance.Models;

namespace TALInsurance.Data.OccupationMapping
{
    public class sqlOccupationMappingRepo : IOccupationMapping
    {
        private readonly DBInstance _context;

        public sqlOccupationMappingRepo(DBInstance context)
        {
            _context = context;
        }

        public void CreateMapping(tblOccupationMapping tcd)
        {
            if (tcd == null)
            {
                throw new ArgumentNullException(nameof(tcd));
            }
            _context.tblOccupationMapping.Add(tcd);
        }

        public void DeleteMapping(tblOccupationMapping tcd)
        {
            if (tcd == null)
            {
                throw new ArgumentNullException(nameof(tcd));
            }
            _context.tblOccupationMapping.Remove(tcd);
        }

        public IEnumerable<tblOccupationMapping> GetMappingData()
        {
            return _context.tblOccupationMapping.ToList();
        }

        public tblOccupationMapping GetMappingDatabyID(int ID)
        {
            return _context.tblOccupationMapping.FirstOrDefault(p => p.Slno == ID);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMappingData(tblOccupationMapping tcd)
        {
            //DO Nothing
        }
    }
}
