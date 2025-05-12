using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Filters;
using WebAPIDemo.Filters.ActionFilters;
using WebAPIDemo.Filters.ExceptionFilters;
using WebAPIDemo.Models;
using WebAPIDemo.Models.Repositories;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {

   


        [HttpGet]
        //[Route("/shirts")]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetShirts());
        }
        [HttpGet("{id}")]
        //[Route("/shirts/{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_HandleUpdateExceptionFilter]
        public IActionResult GetShirtById(int id)
        {
            //if (id <= 0)
            //    return BadRequest();

            //var shirt= ShirtRepository.GetShirtById(id);
            //if (shirt == null)
            //{
            //    return NotFound();
            //}
            return Ok(ShirtRepository.GetShirtById(id));
        }
        [HttpPost]
        //[Route("/shirts")]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);


            ShirtRepository.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById), new {id=shirt.ShirtId},shirt);
        }

        [HttpPut("{id}")]
        //[Route("/shirts/{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionFilter]
        public IActionResult UpdateShirt(int id,Shirt shirt)
        {
          

            
                ShirtRepository.UpdateShirt(shirt);
           
           
             
           
          

            return NoContent();
        }
        [HttpDelete("{id}")]
        //[Route("/shirts/{id}")]
        [Shirt_ValidateShirtIdFilter]

        public IActionResult DeleteShirt(int id)
        {
            var shirt=ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);
            return Ok(shirt);
        }
    }
}
