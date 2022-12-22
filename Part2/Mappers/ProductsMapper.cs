using ProductsWebApplication.Dtos;
using ProductsWebApplication.Entities;
using ProductsWebApplication.Helpers;
using ProductsWebApplication.Services;

namespace ProductsWebApplication.Mappers;

public class ProductsMapper
{
    private ICategoryService _categoryService;
    private CategoriesMapper _mapper;

    public ProductsMapper(ICategoryService categoryService, CategoriesMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }


    public Product ProductDtoToProduct(ProductDto productDto)
    {
        return new Product
        {
            ProductId = productDto.ProductId,
            Designation = productDto.Designation,
            Price = productDto.Price,
            Category = _mapper.CategoryDtoToCategory(_categoryService.FindByName(productDto.CategoryName))
        };
    }

    public ProductDto ProductToProductDto(Product product)
    {
        int ProductId = product.ProductId;
        string Designation = product.Designation;
        double Price = product.Price;
        string CategoryName = "";
        if (product.Category != null)
        {
            CategoryName = product.Category.Name;
        }
        
        return new ProductDto
        {
            ProductId = ProductId,
            Designation = Designation,
            Price = Price,
            CategoryName = CategoryName
        };
    }
}