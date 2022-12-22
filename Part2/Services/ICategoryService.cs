using ProductsWebApplication.Dtos;
using ProductsWebApplication.Entities;

namespace ProductsWebApplication.Services;


public interface ICategoryService
{
    
    CategoryDto GetOne(int id);
    CategoryDto Save(CategoryDto categoryDto);
    IEnumerable<CategoryDto> FindAll();
    CategoryDto FindByName(String name);
    void Update(CategoryDto categoryDto);
    void Delete(int id);
    IEnumerable<Product> FindCategoriesByCategory(string name);
}