using System.Collections.Generic;
using System.Threading.Tasks;
using Insights.BigPurpleBank.Models;

namespace Insights.BigPurpleBank.Repositories
{
    public interface IOnPremisesRepository
    {
        public Task<List<Models.ResponseBankingProduct>> GetProducts();
    }

    public class OnPremisesRepository : IOnPremisesRepository
    {
        public async Task<List<ResponseBankingProduct>> GetProducts()
        {
            List<Models.ResponseBankingProduct> products = new List<ResponseBankingProduct>();
            products.Add(new ResponseBankingProduct { ProductId = "1", Name = "Product 1", Description = "Description Product 1", Brand = "Brand 1"});
            products.Add(new ResponseBankingProduct { ProductId = "2", Name = "Product 2", Description = "Description Product 2", Brand = "Brand 1"});
            products.Add(new ResponseBankingProduct { ProductId = "3", Name = "Product 3", Description = "Description Product 3", Brand = "Brand 2"});
            products.Add(new ResponseBankingProduct { ProductId = "4", Name = "Product 4", Description = "Description Product 4", Brand = "Brand 2"});
            products.Add(new ResponseBankingProduct { ProductId = "5", Name = "Product 5", Description = "Description Product 5", Brand = "Brand 3"});
            
            return products;
        }
    }
}