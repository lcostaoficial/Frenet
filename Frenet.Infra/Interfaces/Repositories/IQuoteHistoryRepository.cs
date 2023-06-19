using Frenet.Domain.Entities;

namespace Frenet.Infra.Interfaces.Repositories
{
    public interface IQuoteHistoryRepository
    {
        int Add(QuoteHistory produto);
        List<QuoteHistory> GetQuoteHistory();
    }
}