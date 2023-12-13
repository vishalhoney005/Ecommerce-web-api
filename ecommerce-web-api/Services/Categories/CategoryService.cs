using ecommerce_web_api.Database;
using ecommerce_web_api.Models;

namespace ecommerce_web_api.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly DatabaseContext _dbContext;
        public CategoryService(DatabaseContext context)
        {
            _dbContext = context;
        }
        public Category AddCategory(Category category)
        {
            var data = _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            Category category=_dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            _dbContext.Remove(category);
            _dbContext.SaveChanges() ;
        }

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _dbContext.Categories.FirstOrDefault(x=>x.CategoryId == id);

        }

        public Category UpdateCategory(int id,Category category)
        {
            Category cat = GetCategoryById(id);
            cat.CategoryName = category.CategoryName;
            cat.CategoryImage = category.CategoryImage;
            _dbContext.SaveChanges();
            return cat;
        }
    }
}
