using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService service) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Product>>> GetProducts()
    {
        return await service.GetAllProducts();
    }

    [HttpGet("[action]/{id}")]
    public async Task<Response<Product>> GetProduct(int id)
    {
        return await service.GetProductById(id);
    }

    [HttpPost]
    public async Task<Response<bool>> PostProduct(Product product)
    {
        return await service.AddProduct(product);
    }

    [HttpPut("[action]/{id}")]
    public async Task<Response<bool>> PutProduct(int id, Product product)
    {
        return await service.UpdateProduct(id, product);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<Response<bool>> DeleteProduct(int id)
    {
        return await service.DeleteProduct(id);
    }

    [HttpGet("[action]/export")]
    public async Task<Response<bool>> ExportProduct()
    {
        return await service.ExportProduct();
    }
}