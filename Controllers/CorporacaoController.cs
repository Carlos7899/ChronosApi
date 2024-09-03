using ChronosApi.Models;
using ChronosApi.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ChronosApi.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class CorporacaoController : ControllerBase
        {
            private static List<Corporacao> corporacoes = new List<Corporacao>()
        {
            new Corporacao()
            {
                idCorporacao = 1,
                idCorporacaoEndereco = 1,
                tipoCorporacao = TipoCorporacao.Empresa,
                nomeCorporacao = "Corporação Exemplo",
                emailCorporacao = "contato@exemplo.com",
                numeroCorporacao = "12345678",
                descricaoCorporacao = "Exemplo de corporação",
                cnpjCorporacao = "12.345.678/0001-99"
            }
        };

            #region Get 

         
            [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(corporacoes);
            }

           
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var corporacao = corporacoes.FirstOrDefault(c => c.idCorporacao == id);
                if (corporacao == null)
                    return NotFound(new { message = "Corporação não encontrada" });

                return Ok(corporacao);
            }

            #endregion

            #region Create 

           

            [HttpPost]
            public IActionResult Create([FromBody] Corporacao newCorporacao)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                newCorporacao.idCorporacao = corporacoes.Count + 1;
                corporacoes.Add(newCorporacao);

                return CreatedAtAction(nameof(GetById), new { id = newCorporacao.idCorporacao }, newCorporacao);
            }

            #endregion

            #region Update 

           
            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody] Corporacao updatedCorporacao)
            {
                var existingCorporacao = corporacoes.FirstOrDefault(c => c.idCorporacao == id);
                if (existingCorporacao == null)
                    return NotFound(new { message = "Corporação não encontrada" });

                existingCorporacao.idCorporacaoEndereco = updatedCorporacao.idCorporacaoEndereco;
                existingCorporacao.tipoCorporacao = updatedCorporacao.tipoCorporacao;
                existingCorporacao.nomeCorporacao = updatedCorporacao.nomeCorporacao;
                existingCorporacao.emailCorporacao = updatedCorporacao.emailCorporacao;
                existingCorporacao.numeroCorporacao = updatedCorporacao.numeroCorporacao;
                existingCorporacao.descricaoCorporacao = updatedCorporacao.descricaoCorporacao;
                existingCorporacao.cnpjCorporacao = updatedCorporacao.cnpjCorporacao;

                return NoContent();
            }

            #endregion

            #region Delete 

           
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var existingCorporacao = corporacoes.FirstOrDefault(c => c.idCorporacao == id);
                if (existingCorporacao == null)
                    return NotFound(new { message = "Corporação não encontrada" });

                corporacoes.Remove(existingCorporacao);
                return NoContent();
            }

            #endregion
        }
 }


