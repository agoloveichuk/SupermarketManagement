using CoreBusiness;
using UseCases.DaraStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;
        public  CategoryInMemoryRepository()
        {
            // Add some default categories 
            categories = new List<Category>()
            {
                new Category{CategoryId = 1, Name = "Beverage", Description = "Beverage"},
                new Category{CategoryId = 2, Name = "Bakery", Description = "Bakery"},
                new Category{CategoryId = 3, Name = "Meat", Description = "Meat"},
            };
        }

        public void Add(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (categories != null && categories.Count > 0)
            {
                var maxId = categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;
            }
            else
            {
                category.CategoryId = 1;    
            }

            categories.Add(category);
        }

        public void Update(Category category)
        {
            var categoryToUpdate = GetById(category.CategoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return categories;
        }

        public Category GetById(int categoryId)
        {
            return categories?.FirstOrDefault(x => x.CategoryId == categoryId);
        }

        public void Delete(int categoryId)
        {
            categories?.Remove(GetById(categoryId));
        }
    }
}