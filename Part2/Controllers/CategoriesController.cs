using ProductsWebApplication.Dtos;
using ProductsWebApplication.Services;

namespace ProductsWebApplication;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = _categoryService.FindAll();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        // try and if exception caught return 404
        try
        {
            var category = _categoryService.GetOne(id);

            return Ok(category);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("find/{name}")]
    public IActionResult FindByName(string name)
    {
        var category = _categoryService.FindByName(name);
        return Ok(category);
    }

    
    [HttpGet("{name}/products")]
    public IActionResult FindCategoriesByCategory(string name)
    {
        var products = _categoryService.FindCategoriesByCategory(name);
        return Ok(products);
    }
    

    [HttpPost]
    public IActionResult Create(CategoryDto categoryDto)
    {
        _categoryService.Save(categoryDto);
        return Ok(new { message = "Category created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(CategoryDto categoryDto)
    {
        _categoryService.Update(categoryDto);
        return Ok(new { message = "Category updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _categoryService.Delete(id);
        return Ok(new { message = "Category deleted" });
    }
}