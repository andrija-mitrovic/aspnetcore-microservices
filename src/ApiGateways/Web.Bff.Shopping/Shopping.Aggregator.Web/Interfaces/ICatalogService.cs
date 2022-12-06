using Shopping.Aggregator.Web.DTOs;

namespace Shopping.Aggregator.Web.Interfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogDto>> GetCatalog();
        Task<IEnumerable<CatalogDto>> GetCatalogByCategory(string category);
        Task<CatalogDto> GetCatalog(string id);
    }
}
