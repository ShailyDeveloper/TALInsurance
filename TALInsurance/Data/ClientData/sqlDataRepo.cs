using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TALInsurance.Models;

namespace TALInsurance.Data.ClientData
{
    public class sqlDataRepo : IClientData
    {
        private readonly DBInstance _context;

        public sqlDataRepo(DBInstance context)
        {
            _context = context;
        }

        public void CreateClientData(tblClientData tcd)
        {
            if (tcd == null)
            {
                throw new ArgumentNullException(nameof(tcd));
            }
            _context.tblClientData.Add(tcd);
        }

        public void DeleteClientData(tblClientData tcd)
        {
            if (tcd == null)
            {
                throw new ArgumentNullException(nameof(tcd));
            }
            _context.tblClientData.Remove(tcd);
        }

        public IEnumerable<tblClientData> GetClientData()
        {
            return _context.tblClientData.ToList();
        }

        public tblClientData GetClientDatabyID(int ID)
        {
            return _context.tblClientData.FirstOrDefault(p => p.SlNo == ID);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateClientData(tblClientData tcd)
        {
            //Do Nothing
        }
    }
}
