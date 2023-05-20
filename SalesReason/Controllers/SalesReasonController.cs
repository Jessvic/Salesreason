using Microsoft.AspNetCore.Mvc;
using SalesReason.Services.WebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/salesreason")]
    [ApiController]
    public class SalesReasonController : ControllerBase
    {
        private readonly ISalesReasonService _salesReasonService;

        public SalesReasonController(ISalesReasonService salesReasonService)
        {
            _salesReasonService = salesReasonService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SalesReason>>> GetAllSalesReasons()
        {
            var salesReasons = await _salesReasonService.GetAllSalesReasons();
            return Ok(salesReasons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesReason>> GetSalesReasonById(int id)
        {
            var salesReason = await _salesReasonService.GetSalesReasonById(id);
            if (salesReason == null)
            {
                return NotFound();
            }
            return Ok(salesReason);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSalesReason(SalesReason salesReason)
        {
            await _salesReasonService.CreateSalesReason(salesReason);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalesReason(int id, SalesReason salesReason)
        {
            if (id != salesReason.SalesReasonID)
            {
                return BadRequest();
            }
            await _salesReasonService.UpdateSalesReason(salesReason);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesReason(int id)
        {
            await _salesReasonService.DeleteSalesReason(id);
            return Ok();
        }
    }
}

