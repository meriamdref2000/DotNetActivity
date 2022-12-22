using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductsWebApplication.Dtos;
using ProductsWebApplication.Entities;
using ProductsWebApplication.Helpers;
using ProductsWebApplication.Mappers;

namespace ProductsWebApplication.Services;

public class CategoryServiceImpl : ICategoryService
{
    private DataContext _context;
    private CategoriesMapper _mapper;

    public CategoryServiceImpl(DataContext context, CategoriesMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public CategoryDto GetOne(int id)
    {
        return GetCategory(id);
    }

    public CategoryDto Save(CategoryDto categoryDto)
    {
        if (_context.Categories.AsNoTracking().Any(x => x.Name == categoryDto.Name))
            throw new Exception("Category with the designation '" + categoryDto.Name + "' already exists");
        EntityEntry<Category> saved = _context.Categories.Add(_mapper.CategoryDtoToCategory(categoryDto));
        _context.SaveChanges();
        return _mapper.CategoryToCategoryDto(saved.Entity);
    }

    public IEnumerable<CategoryDto> FindAll()
    {
        IEnumerable<CategoryDto> categories =
            _context.Categories.AsNoTracking().Select(x => _mapper.CategoryToCategoryDto(x)).ToList();
        return categories;
    }

    public CategoryDto FindByName(string name)
    {
        _context.ChangeTracker.Clear();
        Category category = _context.Categories.AsNoTracking().FirstOrDefault(x => x.Name == name);
        if (category == null)
        {
            category = new Category { Name = name };
        }

        CategoryDto categoryDto =
            _mapper.CategoryToCategoryDto(category);
        return categoryDto;
    }

    public void Update(CategoryDto element)
    {
        var category = GetCategory(element.CategoryId);
        if (category == null)
            throw new Exception("Category not found");
        if (_context.Categories.AsNoTracking().Any(x => x.Name == element.Name && x.CategoryId != element.CategoryId))
            throw new Exception("Category with the designation '" + element.Name + "' already exists");
        category.Name = element.Name;
        Category cat = _mapper.CategoryDtoToCategory(category);
        _context.Categories.Update(cat);
        _context.SaveChanges();
    }


    public void Delete(int id)
    {
        var element = GetCategory(id);
        Category category = _mapper.CategoryDtoToCategory(element);
        _context.Entry(category).State = EntityState.Detached;
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }

    public IEnumerable<Product> FindCategoriesByCategory(string categoryName)
    {
        IEnumerable<Product> products = _context.Products.AsNoTracking().Include(x=>x.Category)
            .Where(x => x.Category.Name == categoryName)
            .Select(x => x).ToList();
        return products;
    }


    private CategoryDto GetCategory(int id)
    {
        var element = _context.Categories.AsNoTracking().Where(x => x.CategoryId == id).FirstOrDefault();
        if (element == null) throw new KeyNotFoundException("Category not found");
        return _mapper.CategoryToCategoryDto(element);
    }
}