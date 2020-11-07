using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TALInsurance.Models;

namespace TALInsurance.Data.OccupationRating
{
    public class sqlOccupationRating : IOccupationRating
    {
        private readonly DBInstance _context;

        public sqlOccupationRating(DBInstance context)
        {
            _context = context;
        }
        public void CreateRatingData(tblOccupationRating tcd)
        {
            if (tcd == null)
            {
                throw new ArgumentNullException(nameof(tcd));
            }
            _context.tblOccupationRating.Add(tcd);
        }

        public void DeleteRatingData(tblOccupationRating tcd)
        {
            if (tcd == null)
            {
                throw new ArgumentNullException(nameof(tcd));
            }
            _context.tblOccupationRating.Remove(tcd);
        }

        public IEnumerable<tblOccupationRating> GetRatingData()
        {
            return _context.tblOccupationRating.ToList();
        }

        public tblOccupationRating GetRatingDatabyID(int ID)
        {
            return _context.tblOccupationRating.FirstOrDefault(p => p.Slno == ID);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRatingData(tblOccupationRating tcd)
        {
            //Do Nothing
        }
    }
}
