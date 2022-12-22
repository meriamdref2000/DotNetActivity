using ProductsWebApplication.Dtos;

namespace ProductsWebApplication.Services;
public interface IProductService
{
    
    ProductDto GetOne(int id);
    ProductDto Save(ProductDto product);
    IEnumerable<ProductDto> FindAll();
    IEnumerable<ProductDto> FindByDesignation(String designation);
    void Update(ProductDto product);
    void Delete(int id);
}