using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TALInsurance.Data;

namespace TALInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationFactorController : ControllerBase
    {
        private readonly IOccupationMapping _repo1;
        private readonly IOccupationRating _repo2;

        public OccupationFactorController(IOccupationMapping repo1 , IOccupationRating repo2)
        {
            _repo1 = repo1;
            _repo2 = repo2;

        }

        // Get api/controller
        [HttpGet]
        public ActionResult<IEnumerable<Object>> GetClientData()
        {
            var Items = _repo1.GetMappingData();
            var Items2 = _repo2.GetRatingData();
            var result = (from e in Items
                          join d
                          in Items2 on e.Rating  equals d.Rating
                          select new
                          {
                              ID = e.Slno,
                              Occupation = e.Occupation,
                              Factor = d.Factor
                          }).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
    }
}