using Frenet.Application.Data.Context;
using Frenet.Application.Models.Entities;
using Frenet.Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Frenet.Application.Repositories
{
    public class QuoteHistoryRepository : IQuoteHistoryRepository
    {
        private readonly MainContext _dbContext;

        public QuoteHistoryRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddQuoteHistory(QuoteHistory quoteHistory)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($@"
            EXEC dbo.InsertQuoteHistory
                {quoteHistory.SellerCEP},
                {quoteHistory.Carrier},
                {quoteHistory.CarrierCode},
                {quoteHistory.DeliveryTime},
                {quoteHistory.ServiceCode},
                {quoteHistory.ServiceDescription},
                {quoteHistory.ShippingPrice},
                {quoteHistory.OriginalDeliveryTime},
                {quoteHistory.OriginalShippingPrice},
                {quoteHistory.CreationDate}
            ");
        }

        public async Task<List<QuoteHistory>> GetLast10QuoteHistories(string sellerCEP)
        {
            return await _dbContext.Quotes.FromSqlInterpolated($@"EXEC dbo.GetLast10QuoteHistories{sellerCEP}").ToListAsync();
        }
    }
}