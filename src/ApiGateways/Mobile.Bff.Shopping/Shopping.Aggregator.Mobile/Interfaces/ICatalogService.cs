using Shopping.Aggregator.Mobile.DTOs;

namespace Shopping.Aggregator.Mobile.Interfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogDto>> GetCatalog();
        Task<IEnumerable<CatalogDto>> GetCatalogByCategory(string category);
        Task<CatalogDto> GetCatalog(string id);
    }
}
