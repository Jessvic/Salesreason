using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace SalesReason.Data
{
    public class SalesReasonRepository
    {
        private readonly string connectionString;

        public SalesReasonRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<SalesReason> GetAllSalesReasons()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SalesReasonID, Name, ReasonType, ModifiedDate FROM SalesReason";
                return connection.Query<SalesReason>(query);
            }
        }

        public SalesReason GetSalesReasonByID(int salesReasonID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SalesReasonID, Name, ReasonType, ModifiedDate FROM SalesReason WHERE SalesReasonID = @SalesReasonID";
                return connection.QueryFirstOrDefault<SalesReason>(query, new { SalesReasonID = salesReasonID });
            }
        }

        public void AddSalesReason(SalesReason salesReason)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO SalesReason (Name, ReasonType, ModifiedDate) VALUES (@Name, @ReasonType, @ModifiedDate)";
                connection.Execute(query, salesReason);
            }
        }

        public void UpdateSalesReason(SalesReason salesReason)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE SalesReason SET Name = @Name, ReasonType = @ReasonType, ModifiedDate = @ModifiedDate WHERE SalesReasonID = @SalesReasonID";
                connection.Execute(query, salesReason);
            }
        }

        public void DeleteSalesReason(int salesReasonID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM SalesReason WHERE SalesReasonID = @SalesReasonID";
                connection.Execute(query, new { SalesReasonID = salesReasonID });
            }
        }
    }
}
