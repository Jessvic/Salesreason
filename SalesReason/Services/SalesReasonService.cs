using SalesReason.Data;
using System.Collections.Generic;


namespace SalesReason.Services
{
    public class SalesReasonService
    {
        private readonly SalesReasonRepository salesReasonRepository;

        public SalesReasonService(SalesReasonRepository salesReasonRepository)
        {
            this.salesReasonRepository = salesReasonRepository;
        }

        public IEnumerable<SalesReason> GetAllSalesReasons()
        {
            return salesReasonRepository.GetAllSalesReasons();
        }

        public SalesReason GetSalesReasonByID(int salesReasonID)
        {
            return salesReasonRepository.GetSalesReasonByID(salesReasonID);
        }

        public void AddSalesReason(SalesReason salesReason)
        {
            salesReasonRepository.AddSalesReason(salesReason);
        }

        public void UpdateSalesReason(SalesReason salesReason)
        {
            salesReasonRepository.UpdateSalesReason(salesReason);
        }

        public void DeleteSalesReason(int salesReasonID)
        {
            salesReasonRepository.DeleteSalesReason(salesReasonID);
        }
    }
}
