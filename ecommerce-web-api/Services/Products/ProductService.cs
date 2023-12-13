using ecommerce_web_api.Database;
using ecommerce_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_web_api.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _databaseContext;
        public ProductService(DatabaseContext context)
        { 
            _databaseContext = context;
        }
        public Product AddProduct(Product product, int catId)
        {
            Category category = _databaseContext.Categories.FirstOrDefault(cat => cat.CategoryId == catId);
            product.Category = category;
            _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            Product delProduct=GetProductById(id);
            _databaseContext.Remove(delProduct);
            _databaseContext.SaveChanges();
        }

        public List<Product> GetProductByCatId(int catId)
        {
            return _databaseContext.Products.Where(x => x.Category.CategoryId== catId).Include(x => x.Category).ToList();

        }

        public Product GetProductById(int id)
        {
            return _databaseContext.Products.Where(x=>x.ProductId==id).Include(x=>x.Category).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return  _databaseContext.Products.Include(p => p.Category).ToList();
        }

        public Product UpdateProduct(int id, Product product)
        {
            Product upproduct = GetProductById(id);
            upproduct.ProductTitle = product.ProductTitle;
            upproduct.ProductPrice = product.ProductPrice;
            upproduct.ProductImage = product.ProductImage;
            upproduct.ProductDescription = product.ProductDescription;
            _databaseContext.SaveChanges();
            return upproduct;
        }
    }
}
