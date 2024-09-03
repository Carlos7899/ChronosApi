using ChronosApi.Models;
using ChronosApi.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EgressoController : ControllerBase
    {

        private static List<Egresso> egresso = new List<Egresso>()
        {

            new Egresso() { idEgresso = 1, nomeEgresso = "Pedro", email = "ops.gmail", numeroEgresso = "8922", cpfEgresso = "222", tipoPessoaEgresso = TipoPessoaEgresso.fisico}

        };

    

        #region Get 

       
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(egresso);
        }

      
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = egresso.FirstOrDefault(e => e.idEgresso == id);
            if (item == null)
                return NotFound(new { message = "Egresso não encontrado" });

            return Ok(item);
        }

        #endregion

        #region Create 

       
        [HttpPost]
        public IActionResult Create([FromBody] Egresso newEgresso)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            newEgresso.idEgresso = egresso.Count + 1;
            egresso.Add(newEgresso);

            return CreatedAtAction(nameof(GetById), new { id = newEgresso.idEgresso }, newEgresso);
        }

        #endregion

        #region Update 

       
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Egresso updatedEgresso)
        {
            var existingEgresso = egresso.FirstOrDefault(e => e.idEgresso == id);
            if (existingEgresso == null)
                return NotFound(new { message = "Egresso não encontrado" });

            existingEgresso.nomeEgresso = updatedEgresso.nomeEgresso;
            existingEgresso.email = updatedEgresso.email;
            existingEgresso.numeroEgresso = updatedEgresso.numeroEgresso;
            existingEgresso.cpfEgresso = updatedEgresso.cpfEgresso;
            existingEgresso.tipoPessoaEgresso = updatedEgresso.tipoPessoaEgresso;

            return NoContent();
        }

        #endregion

        #region Delete 

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingEgresso = egresso.FirstOrDefault(e => e.idEgresso == id);
            if (existingEgresso == null)
                return NotFound(new { message = "Egresso não encontrado" });

            egresso.Remove(existingEgresso);
            return NoContent();
        }

        #endregion
    }
}