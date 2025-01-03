using Domain;
using Infrastructure.ApiResponse.cs;

namespace Infrastructure.Service.ProductService;

public interface IProductService
{
    public Task<Response<bool>> AddProduct(Product product);
    public Task<Response<bool>> ExportProduct();
    public Task<Response<bool>> ImportProduct();
    public Task<Response<bool>> UpdateFromFile();
    public Task<Response<bool>> Analize();
    public Task<Response<Product>> GetProductById(int Id);
    public Task<Response<bool>> DeleteProduct(int Id);
    public Task<Response<bool>> UpdateProduct(int Id, Product product);
    public Task<Response<List<Product>>> GetAllProducts();  
}
