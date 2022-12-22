using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductsWebApplication.Dtos;
using ProductsWebApplication.Entities;
using ProductsWebApplication.Helpers;
using ProductsWebApplication.Mappers;

namespace ProductsWebApplication.Services;

public class ProductServiceImpl : IProductService
{
    private DataContext _context;
    private ProductsMapper _mapper;

    public ProductServiceImpl(DataContext context, ProductsMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<ProductDto> FindAll()
    {
        return _context.Products.Include(x => x.Category).Select(x => _mapper.ProductToProductDto(x)).ToList();
    }

    public ProductDto GetOne(int id)
    {
        return GetProduct(id);
    }

    public ProductDto Save(ProductDto product)
    {
        if (_context.Products.AsNoTracking().Any(x => x.Designation == product.Designation))
            throw new Exception("Product with the designation '" + product.Designation + "' already exists");
        Product newProduct = _mapper.ProductDtoToProduct(product);
        
        if (_context.Categories.AsNoTracking().Any(x => x.Name == newProduct.Category.Name))
            _context.Entry(newProduct.Category).State = EntityState.Modified;

        EntityEntry<Product> saved = _context.Products.Add(newProduct);
        _context.SaveChanges();
        return _mapper.ProductToProductDto(saved.Entity);
    }


    public IEnumerable<ProductDto> FindByDesignation(string designation)
    {
        return _context.Products.Include(x => x.Category).AsNoTracking().Where(x => x.Designation.Contains(designation))
            .Select(x => _mapper.ProductToProductDto(x)).ToList();
    }

    public void Update(ProductDto element)
    {
        var product = GetProduct(element.ProductId);
        if (product == null)
            throw new Exception("Product not found");
        if (_context.Products.AsNoTracking().Any(x => x.Designation == element.Designation && x.ProductId != element.ProductId))
            throw new Exception("Product with the designation '" + element.Designation + "' already exists");
        product.Designation = element.Designation;
        product.Price = element.Price;
        product.CategoryName = element.CategoryName;
        _context.Products.Update(_mapper.ProductDtoToProduct(product));
        _context.SaveChanges();
    }


    public void Delete(int id)
    {
        var element = GetProduct(id);
        _context.Products.Remove(_mapper.ProductDtoToProduct(element));
        _context.SaveChanges();
    }


    private ProductDto GetProduct(int id)
    {
        var element = _context.Products.Include(x => x.Category).Where(x => x.ProductId == id).FirstOrDefault();
        if (element == null) throw new KeyNotFoundException("Product not found");
        return _mapper.ProductToProductDto(element);
    }
}