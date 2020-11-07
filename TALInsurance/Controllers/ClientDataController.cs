using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TALInsurance.Data;
using TALInsurance.DTO.ClientData;
using TALInsurance.Models;

namespace TALInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientDataController : ControllerBase
    {

        private readonly IClientData _repo;
        private readonly IMapper _mapper;

        public ClientDataController(IClientData repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // Get api/controller
        [HttpGet]
        public ActionResult<IEnumerable<tblClientDataReadDto>> GetClientData()
        {
            var Items = _repo.GetClientData();
            return Ok(_mapper.Map<IEnumerable<tblClientDataReadDto>>(Items));
        }

        // Get api/controller/{id}
        [HttpGet("{ID}", Name = "GetDataByID")]
        public ActionResult<IQueryable<tblClientDataReadDto>> GetDataByID(int ID)
        {
            var clientdatabyID = _repo.GetClientDatabyID(ID);
            if (clientdatabyID != null)
            {
                return Ok(_mapper.Map<tblClientDataReadDto>(clientdatabyID));
            }
            return NotFound();
        }

        //POST api/controller
        [HttpPost]
        public ActionResult<tblClientDataReadDto> CreateClientData(tblClientDataCreateDto ClientCreateDto)
        {
            var clientInfo = _mapper.Map<tblClientData>(ClientCreateDto);
            _repo.CreateClientData(clientInfo);
            _repo.SaveChanges();
            return NoContent();

        }

        //PUT api/controller/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateClientData(int ID, tblClientDataUpdateDto Clientupdatedto)
        {
            var ClientUpdateInfo = _repo.GetClientDatabyID(ID);
            if (ClientUpdateInfo == null)
            {
                return NotFound();
            }

            _mapper.Map(Clientupdatedto,ClientUpdateInfo);

            _repo.UpdateClientData(ClientUpdateInfo);

            _repo.SaveChanges();

            return NoContent();
        }

        //DELETE api/controller/{id}
        [HttpDelete("{ID}")]
        public ActionResult DeleteClientData(int ID)
        {
            var ClientDeleteInfo = _repo.GetClientDatabyID(ID);
            if (ClientDeleteInfo == null)
            {
                return NotFound();
            }

            _repo.DeleteClientData(ClientDeleteInfo);
            _repo.SaveChanges();

            return NoContent();

        }
    }

}
