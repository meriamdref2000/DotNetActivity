using ProductsWebApplication.Dtos;
using ProductsWebApplication.Services;

namespace ProductsWebApplication;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _productService.FindAll();
        return Ok(products);
    }

    [HttpGet("find/{designation}")]
    public IActionResult FindByDesignation(string designation)
    {
        var products = _productService.FindByDesignation(designation);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _productService.GetOne(id);
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(ProductDto product)
    {
        _productService.Save(product);
        return Ok(new { message = "Product created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(ProductDto product)
    {
        _productService.Update(product);
        return Ok(new { message = "Product updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _productService.Delete(id);
        return Ok(new { message = "Product deleted" });
    }
}