using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TALInsurance.Data;
using TALInsurance.DTO.OccupationMapping;
using TALInsurance.Models;

namespace TALInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationMapController : ControllerBase
    {

        private readonly IOccupationMapping _repo;
        private readonly IMapper _mapper;

        public OccupationMapController(IOccupationMapping repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // Get api/controller
        [HttpGet]
        public ActionResult<IEnumerable<tblOccupationMappingReadDto>> GetOCMapping()
        {
            var Items = _repo.GetMappingData();
            return Ok(_mapper.Map<IEnumerable<tblOccupationMappingReadDto>>(Items));
        }

        // Get api/controller/{id}
        [HttpGet("{ID}", Name = "GetOCMappingByID")]
        public ActionResult<IEnumerable<tblOccupationMappingReadDto>> GetOCMappingByID(int ID)
        {
            var cOCMapByID = _repo.GetMappingDatabyID(ID);
            if (cOCMapByID != null)
            {
                return Ok(_mapper.Map<tblOccupationMappingReadDto>(cOCMapByID));
            }
            return NotFound();
        }

        //POST api/controller
        [HttpPost]
        public ActionResult<tblOccupationMappingReadDto> CreateOCMapping(tblOccupationMappingCreateDto OCMapDto)
        {
            var OCMapInfo = _mapper.Map<tblOccupationMapping>(OCMapDto);
            _repo.CreateMapping(OCMapInfo);
            _repo.SaveChanges();
            return NoContent();

        }

        //PUT api/controller/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateOCMap(int ID, tblOccupationMappingUpdateDto OCMapDto)
        {
            var OCMapInfo = _repo.GetMappingDatabyID(ID);
            if (OCMapInfo == null)
            {
                return NotFound();
            }

            _mapper.Map(OCMapDto, OCMapInfo);

            _repo.UpdateMappingData(OCMapInfo);

            _repo.SaveChanges();

            return NoContent();
        }

        //DELETE api/controller/{id}
        [HttpDelete("{ID}")]
        public ActionResult DeleteClientData(int ID)
        {
            var OCMapDeleteInfo = _repo.GetMappingDatabyID(ID);
            if (OCMapDeleteInfo == null)
            {
                return NotFound();
            }

            _repo.DeleteMapping(OCMapDeleteInfo);
            _repo.SaveChanges();

            return NoContent();

        }
    }
}