using ProductsWebApplication.Dtos;
using ProductsWebApplication.Entities;

namespace ProductsWebApplication.Mappers;

public class CategoriesMapper
{
   
    public Category CategoryDtoToCategory(CategoryDto categoryDto)
    {
        var category = new Category
        {
            CategoryId = categoryDto.CategoryId,
            Name = categoryDto.Name,
        };

        return category;
    }
    
    public CategoryDto CategoryToCategoryDto(Category category)
    {
        var categoryDto = new CategoryDto
        {
            CategoryId = category.CategoryId,
            Name = category.Name,
        };

        return categoryDto;
    }
    
}