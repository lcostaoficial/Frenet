using Dapper;
using Frenet.Domain.Entities;
using Frenet.Infra.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Frenet.Infra.Repositories
{
    public class QuoteHistoryRepository : IQuoteHistoryRepository
    {
        IConfiguration _configuration;

        public QuoteHistoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("FrenetConnection").Value;
            return connection!;
        }

        public int Add(QuoteHistory produto)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Produtos(Nome, Estoque, Preco) VALUES(@Nome, @Estoque, @Preco); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, produto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public List<QuoteHistory> GetQuoteHistory()
        {
            var connectionString = this.GetConnection();
            List<QuoteHistory> produtos = new List<QuoteHistory>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Produtos";
                    produtos = con.Query<QuoteHistory>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return produtos;
            }
        }

    }
}
