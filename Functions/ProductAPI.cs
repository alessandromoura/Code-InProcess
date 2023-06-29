using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Insights.BigPurpleBank.Functions
{
    public class ProductAPI
    {
        private readonly Services.IProductsService _productsService;

        public ProductAPI(Services.IProductsService productsService)
        {
            _productsService = productsService ?? throw new ArgumentNullException(nameof(Services.ProductsService));
        }

        [FunctionName(nameof(ProductAPI))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req, ILogger _logger)
        {
            try {
                return new OkObjectResult(await _productsService.GetProducts());
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { status = "Error", message = "Failed to process request" });
            }
        }
    }
}