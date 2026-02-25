using Application.DTOs.ProductDTOs;

namespace Application.Interfaces.Services
{
    public interface IProductCustomerService
    {
        IQueryable<ProductDto> GetAvailableProducts();
        IQueryable<ProductDto> SearchProducts(string searchTerm);
        ProductDto GetById(int id);
    }
}
