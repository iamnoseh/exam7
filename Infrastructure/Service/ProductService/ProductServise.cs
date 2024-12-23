namespace Infrastructure;

using System.Collections.Generic;
using System.Threading.Tasks;
using Dappercontext;
using Domain;
using Dapper;

public class ProductService(DapperContext context) : IProductService
{
    public async Task<Response<bool>> AddProduct(Product product)
    {
        string cmd = "INSERT INTO products (name, price, categoryname, description, stockquantity, createddate) VALUES (@Name, @Price, @CategoryName, @Description, @StockQuantity, @CreatedDate)";
        using var _context = context.Connection();
        var effect = await _context.ExecuteAsync(cmd,product);
        return effect == 0
            ? new Response<bool>(System.Net.HttpStatusCode.InternalServerError,"Internal server error")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> ExportProduct()
    {
        string path = "C:\\Users\\NOSEH\\Desktop\\exam\\Infrastructure\\export.txt";
        string cmd = "Select * from products";
        using var _context = context.Connection();
        var products = await _context.QueryAsync<Product>(cmd);
        foreach (var p in products)
        {
            string txt = $"{p.Id},{p.Name},{p.Price},{p.CategoryName},{p.StockQuantity},{p.CreatedDate}";
            
            await File.AppendAllTextAsync(path,txt);
        }
        return new Response<bool>(true);
    }

    public Task<Response<bool>> ImportProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> UpdateFromFile()
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> Analize()
    {
        throw new NotImplementedException();
    }


    public async Task<Response<bool>> DeleteProduct(int productId)
    {
        string cmd = "DELETE FROM products WHERE id = @Id";
        using var _context = context.Connection();
        var effect =await _context.ExecuteAsync(cmd, new { Id = productId });
        return effect == 0
            ? new Response<bool>(System.Net.HttpStatusCode.InternalServerError,"Intenal server error")
            : new Response<bool>(true);
    }

    public async Task<Response<List<Product>>> GetAllProducts()
    {
        string cmd = "select * from products";
        using var _context = context.Connection();
        var products = await _context.QueryAsync<Product>(cmd);
        if(!products.Any())
        {
            return new Response<List<Product>>(System.Net.HttpStatusCode.NotFound, "No products found");
        }
        return new Response<List<Product>>(products.ToList());
    }

    public async Task<Response<Product>> GetProductById(int Id)
    {
        string cmd = "select * from products where id = @Id";
        using var _context = context.Connection();
        var product = await _context.QuerySingleOrDefaultAsync<Product>(cmd, new { Id = Id });
        if(product == null)
        {
            return new Response<Product>(System.Net.HttpStatusCode.NotFound, "Product not found");
        }
        return new Response<Product>(product);
    }

    public async Task<Response<bool>> UpdateProduct(int Id, Product product)
    {
        string cmd = "Update products set name = @Name, price = @Price, categoryname = @CategoryName, description = @Description, stockquantity = @StockQuantity, createddate = @CreatedDate where id = @Id";
        using var _context = context.Connection();
        var effect = await _context.ExecuteAsync(cmd, product);
        return effect == 0
            ? new Response<bool>(System.Net.HttpStatusCode.InternalServerError,"Internal server error")
            : new Response<bool>(true);
    }
}