
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface ISalesReasonService
    {
        Task<List<SalesReason>> GetAllSalesReasons();
        Task<SalesReason> GetSalesReasonById(int id);
        Task CreateSalesReason(SalesReason salesReason);
        Task UpdateSalesReason(SalesReason salesReason);
        Task DeleteSalesReason(int id);
    }

}

