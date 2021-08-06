using Acquisti.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acquisti.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdiniController : ControllerBase
    {
        private IAcquistiBL businessLayer;

        public OrdiniController(IAcquistiBL businessLayer)
        {
            this.businessLayer = businessLayer;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = this.businessLayer.FetchOrdini();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Loan ID.");

            var loan = this.businessLayer.FetchOrdineById(id);

            if (loan == null)
                return NotFound($"Loan with ID = {id} is missing.");

            return Ok(loan);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Loan ID.");

            var result = this.businessLayer.DeleteOrdineById(id);

            if (!result)
                return StatusCode(500, "Cannot complete the operation.");

            return Ok();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Ordine newOrdine)
        {
            if (newOrdine == null)
                return BadRequest("Invalid data.");

            if (!this.businessLayer.CreateOrdine(newOrdine))
                return BadRequest("Cannot complete the operation.");

            return CreatedAtAction(nameof(GetById), new { id = newOrdine.ID }, newOrdine);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ordine editedOrdine)
        {
            if (editedOrdine == null)
                return BadRequest("Invalid data.");

            if (id != editedOrdine.ID)
                return BadRequest("Loan IDs don't match.");

            if (!this.businessLayer.EditOrdine(editedOrdine))
                return BadRequest("Operation cannot be completed.");

            return Ok();
        }
    }
}
