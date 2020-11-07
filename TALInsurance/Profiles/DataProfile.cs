using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TALInsurance.DTO.ClientData;
using TALInsurance.DTO.OccupationMapping;
using TALInsurance.DTO.OccupationRating;
using TALInsurance.Models;

namespace TALInsurance.Profiles
{
    public class ClientDataProfile : Profile
    {
        public ClientDataProfile()
        {
            CreateMap<tblClientData, tblClientDataReadDto>();
            CreateMap<tblClientDataCreateDto, tblClientData>();
            CreateMap<tblClientDataUpdateDto, tblClientData>();
        }
        
    }

    public class OccupationMappingProfile : Profile
    {
        public OccupationMappingProfile()
        {
            CreateMap<tblOccupationMapping, tblOccupationMappingReadDto>();
            CreateMap<tblOccupationMappingCreateDto, tblOccupationMapping>();
            CreateMap<tblOccupationMappingUpdateDto, tblOccupationMapping>();
        }
    }

    public class OccupationRatingProfile : Profile
    {
        public OccupationRatingProfile()

        {
            CreateMap<tblOccupationRating, tblOccupationRatingReadDto>();
            CreateMap<tblOccupationRatingCreateDto, tblOccupationRating>();
            CreateMap<tblOccupationRatingUpdateDto, tblOccupationRating>();
        }
    }
}
