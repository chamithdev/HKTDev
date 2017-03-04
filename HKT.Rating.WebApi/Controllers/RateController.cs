using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HKT.Data;
using HKT.Rating.Entity;
using HKT.Rating.Data;
using HKT.Common;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HKT.Rating.WebApi.Controllers
{


    [Route("api/rate")]
    public class RateController : Controller
    {

        readonly IRepository<RatingCategory, RateContext>  _catRepository;
        readonly IRepository<Entity.Rating, RateContext> _ratreRepository;
        readonly IUnitOfWork<RateContext> _unitOfWork;

        

        public RateController(IRepository<RatingCategory, RateContext> _catRepository, IRepository<Entity.Rating, RateContext> ratreRepository, IUnitOfWork<RateContext> unitOfWork)
        {
            this._catRepository = _catRepository;
            this._ratreRepository = ratreRepository;
            this._unitOfWork = unitOfWork;
        }

        public IActionResult CreateRate([FromBody] Entity.Rating rate)
        {

            
            try
            {
                _ratreRepository.Add(rate);
                _unitOfWork.SaveChanges();
                var result = new RatingResult<Entity.Rating>
                {
                    IsSuccess = true,
                    Message = "Successfuly rated."
                };
                
                return Ok(result);
            }
            catch(Exception ex)
            {
                // log
                var result = new RatingResult<Entity.Rating>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

                return StatusCode(500, result);

            }

            
        }


        //// GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{

        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


    }
}
