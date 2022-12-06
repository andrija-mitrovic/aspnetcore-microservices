using Shopping.Aggregator.Web.DTOs;
using Shopping.Aggregator.Web.Extensions;
using Shopping.Aggregator.Web.Interfaces;
using Shopping.Aggregator.Web.Models;

namespace Shopping.Aggregator.Web.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<CatalogDto>> GetCatalog()
        {
            var response = await _httpClient.GetAsync(ApiSettings.Catalog.BasePath);

            return await response.ReadContentAs<IEnumerable<CatalogDto>>();
        }

        public async Task<CatalogDto> GetCatalog(string id)
        {
            var response = await _httpClient.GetAsync($"{ApiSettings.Catalog.BasePath}/{id}");

            return await response.ReadContentAs<CatalogDto>();
        }

        public async Task<IEnumerable<CatalogDto>> GetCatalogByCategory(string category)
        {
            var response = await _httpClient.GetAsync($"{ApiSettings.Catalog.BasePath}/GetProductByCategory/{category}");

            return await response.ReadContentAs<IEnumerable<CatalogDto>>();
        }
    }
}
