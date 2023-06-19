using Frenet.Application.Models.Entities;

namespace Frenet.Tests.Entities
{
    public class QuoteHistoryTest
    {
        [Fact]
        public void GerarDataDeCriacao_SetsCreationDateToCurrentDateTime()
        {
            // Arrange
            var quoteHistory = new QuoteHistory();

            // Act
            quoteHistory.GerarDataDeCriacao();

            // Assert
            Assert.Equal(DateTime.Now, quoteHistory.CreationDate, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void InserirSellerCEP_SetsSellerCEP()
        {
            // Arrange
            var quoteHistory = new QuoteHistory();
            var sellerCep = "12345678";

            // Act
            quoteHistory.InserirSellerCEP(sellerCep);

            // Assert
            Assert.Equal(sellerCep, quoteHistory.SellerCEP);
        }
    }
}