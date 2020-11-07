using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TALInsurance.Data;
using TALInsurance.DTO.OccupationRating;
using TALInsurance.Models;

namespace TALInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationRatingController : ControllerBase
    {
        private readonly IOccupationRating _repo;
        private readonly IMapper _mapper;

        public OccupationRatingController(IOccupationRating repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        // Get api/controller
        [HttpGet]
        public ActionResult<IEnumerable<tblOccupationRatingReadDto>> GetOCRating()
        {
            var Items = _repo.GetRatingData();
            return Ok(_mapper.Map<IEnumerable<tblOccupationRatingReadDto>>(Items));
        }

        // Get api/controller/{id}
        [HttpGet("{ID}", Name = "GetOCRatingByID")]
        public ActionResult<IEnumerable<tblOccupationRatingReadDto>> GetOCRatingByID(int ID)
        {
            var OCRatingByID = _repo.GetRatingDatabyID(ID);
            if (OCRatingByID != null)
            {
                return Ok(_mapper.Map<tblOccupationRatingReadDto>(OCRatingByID));
            }
            return NotFound();
        }

        //POST api/controller
        [HttpPost]
        public ActionResult<tblOccupationRatingReadDto> CreateOCRating(tblOccupationRatingCreateDto OCRatingDto)
        {
            var OCRatingInfo = _mapper.Map<tblOccupationRating>(OCRatingDto);
            _repo.CreateRatingData(OCRatingInfo);
            _repo.SaveChanges();
            return NoContent();

        }

        //PUT api/controller/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateOCRating(int ID, tblOccupationRatingUpdateDto OCRatingDto)
        {
            var OCRatingInfo = _repo.GetRatingDatabyID(ID);
            if (OCRatingInfo == null)
            {
                return NotFound();
            }

            _mapper.Map(OCRatingDto, OCRatingInfo);

            _repo.UpdateRatingData(OCRatingInfo);

            _repo.SaveChanges();

            return NoContent();
        }

        //DELETE api/controller/{id}
        [HttpDelete("{ID}")]
        public ActionResult DeleteOCRating(int ID)
        {
            var OCRatingDeleteInfo = _repo.GetRatingDatabyID(ID);
            if (OCRatingDeleteInfo == null)
            {
                return NotFound();
            }

            _repo.DeleteRatingData(OCRatingDeleteInfo);
            _repo.SaveChanges();

            return NoContent();

        }
    }
}