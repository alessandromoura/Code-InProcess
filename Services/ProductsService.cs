using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Insights.BigPurpleBank.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Insights.BigPurpleBank.Services
{
    public interface IProductsService
    {
        Task<List<Models.ResponseBankingProduct>> GetProducts();
    }

    public class ProductsService : IProductsService
    {
        private readonly ILogger<ProductsService> _logger;
        private readonly Repositories.IOnPremisesRepository _onPremisesRepository;
        
        public ProductsService(
            IConfiguration configuration,
            Repositories.IOnPremisesRepository onPremisesRepository,
            ILogger<ProductsService> logger)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _onPremisesRepository = onPremisesRepository;
        }
        
        public async Task<List<ResponseBankingProduct>> GetProducts()
        {
            try {
                return await _onPremisesRepository.GetProducts();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(ProductsService));

                throw;
            }
        }
    }
}
