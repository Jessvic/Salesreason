using Microsoft.EntityFrameworkCore;
using SalesReason.Services.WebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class SalesReasonService : ISalesReasonService
    {
        private readonly ApplicationDbContext _context;

        public SalesReasonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalesReason>> GetAllSalesReasons()
        {
            return await _context.SalesReasons.ToListAsync();
        }

        public async Task<SalesReason> GetSalesReasonById(int id)
        {
            return await _context.SalesReasons.FindAsync(id);
        }

        public async Task CreateSalesReason(SalesReason salesReason)
        {
            _context.SalesReasons.Add(salesReason);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSalesReason(SalesReason salesReason)
        {
            _context.SalesReasons.Update(salesReason);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSalesReason(int id)
        {
            var salesReason = await _context.SalesReasons.FindAsync(id);
            if (salesReason != null)
            {
                _context.SalesReasons.Remove(salesReason);
                await _context.SaveChangesAsync();
            }
        }
    }
}