using Frenet.Application.Models.Entities;

namespace Frenet.Application.Repositories.Interfaces
{
    public interface IQuoteHistoryRepository
    {
        Task AddQuoteHistory(QuoteHistory quoteHistory);
        Task<List<QuoteHistory>> GetLast10QuoteHistories(string sellerCEP);
    }
}