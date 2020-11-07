using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TALInsurance.Models;

namespace TALInsurance.Data
{
    public interface IClientData
    {
        bool SaveChanges();
        IEnumerable<tblClientData> GetClientData();
        tblClientData GetClientDatabyID(int ID);
        void CreateClientData(tblClientData tcd);
        void UpdateClientData(tblClientData tcd);
        void DeleteClientData(tblClientData tcd);
    }

    public interface IOccupationMapping
    {
        bool SaveChanges();
        IEnumerable<tblOccupationMapping> GetMappingData();
        tblOccupationMapping GetMappingDatabyID(int ID);
        void CreateMapping(tblOccupationMapping tcd);
        void UpdateMappingData(tblOccupationMapping tcd);
        void DeleteMapping(tblOccupationMapping tcd);
    }

    public interface IOccupationRating
    {
        bool SaveChanges();
        IEnumerable<tblOccupationRating> GetRatingData();
        tblOccupationRating GetRatingDatabyID(int ID);
        void CreateRatingData(tblOccupationRating tcd);
        void UpdateRatingData(tblOccupationRating tcd);
        void DeleteRatingData(tblOccupationRating tcd);
    }
}
