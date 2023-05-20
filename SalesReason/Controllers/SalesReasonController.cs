
using Microsoft.AspNetCore.Mvc;
using SalesReason.Services;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]

namespace SalesReason.Controllers: ControllerBase
{
    public class SalesReasonController
{
    private readonly SalesReasonService salesReasonService;

    public SalesReasonController(SalesReasonService salesReasonService)
    {
        this.salesReasonService = salesReasonService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SalesReason>> GetAllSalesReasons()
    {
        var salesReasons = salesReasonService.GetAllSalesReasons();
        return Ok(salesReasons);
    }

    [HttpGet("{id}")]
    public ActionResult<SalesReason> GetSalesReasonByID(int id)
    {
        var salesReason = salesReasonService.GetSalesReasonByID(id);
        if (salesReason == null)
        {
            return NotFound();
        }
        return Ok(salesReason);
    }

    [HttpPost]
    public ActionResult AddSalesReason(SalesReason salesReason)
    {
        salesReasonService.AddSalesReason(salesReason);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateSalesReason(int id, SalesReason salesReason)
    {
        var existingSalesReason = salesReasonService.GetSalesReasonByID(id);
        if (existingSalesReason == null)
        {
            return NotFound();
        }
        salesReason.SalesReasonID = id;
        salesReasonService.UpdateSalesReason(salesReason);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteSalesReason(int id)
    {
        var existingSalesReason = salesReasonService.GetSalesReasonByID(id);
        if (existingSalesReason == null)
        {
            return NotFound();
        }
        salesReasonService.DeleteSalesReason(id);
        return Ok();
    }
}
}
