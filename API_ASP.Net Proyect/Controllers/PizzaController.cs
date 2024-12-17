using API_ASP.Net_Proyect.Models;
using API_ASP.Net_Proyect.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_ASP.Net_Proyect.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {
        }

        //Get
        [HttpGet]
        public ActionResult<List<Pizza>>GetAll() =>
            PizzaService.GetAll();


        //Get by ID
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);
            if(pizza != null)
            {
                return pizza;
            }
            return NotFound();
        }

        //Post/Agregar
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id},pizza);
        }

        //Put/ Actualizar
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if(id != pizza.Id)
                return BadRequest();
            var existe = PizzaService.Get(id);

            if(existe == null)
                return NotFound();

            PizzaService.Update(pizza);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if(pizza is null)
            {
                return NotFound();
            }
            PizzaService.Delete(id);

            return NoContent();
        }

    }
}
