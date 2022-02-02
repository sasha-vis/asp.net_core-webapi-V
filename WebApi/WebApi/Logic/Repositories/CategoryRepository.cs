using DATABASE;
using WebApi.Logic.Repositories;
using WebApi.Models;

namespace WebApi
{
    public class CategoryRepository :
        IGetRepository<CategoryGetVM>,
        ICreateRepository<CategoryCreateVM>,
        IEditRepository<CategoryEditVM>,
        IDeleteRepository
    {
        private readonly ApplicationContext _db;
        public CategoryRepository(ApplicationContext context)
        {
           _db = context;
        }
        public List<CategoryGetVM> GetList()
        {
            var result = new List<CategoryGetVM>();

            var categories = _db.Categories.ToList();

            foreach (var category in categories)
            {
                result.Add(new CategoryGetVM
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }

            return result;
        }
        public CategoryGetVM GetItem(int Id)
        {
            var result = new CategoryGetVM();

            var category = _db.Categories
                .Where(c => c.Id == Id)
                .FirstOrDefault();

            if(category != null)
            {
                result.Id = category.Id;
                result.Name = category.Name;
            }

            return result;
        }
        public void Create(CategoryCreateVM model)
        {
            _db.Categories.Add(new Category { Name = model.Name});
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = _db.Categories
                  .Where(category => category.Id == id)
                  .FirstOrDefault();

            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
        }
        public void Edit(CategoryEditVM model)
        {
            var category = _db.Categories
                .Where(c => c.Id == model.Id)
                .FirstOrDefault();

            if (category != null)
            {
                category.Name = model.Name;
                _db.SaveChanges();
            }
        }
    }
}