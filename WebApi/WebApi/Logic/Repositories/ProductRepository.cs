using DATABASE;
using Microsoft.EntityFrameworkCore;
using WebApi.Logic.Repositories;
using WebApi.Models;
using WebApi.Models.Product;

namespace WebApi
{
    public class ProductRepository :
        IGetRepository<ProductGetVM>,
        ICreateRepository<ProductCreateVM>,
        IEditRepository<ProductEditVM>,
        IDeleteRepository
    {
        private readonly ApplicationContext _db;
        public ProductRepository(ApplicationContext context)
        {
            _db = context;
        }
        public List<ProductGetVM> GetList()
        {
            var result = new List<ProductGetVM>();

            var products = _db.Products
                .Include(p => p.Category)
                .ToList();

            foreach (var product in products)
            {
                result.Add(new ProductGetVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = Convert.ToString(product.Price),
                    CategoryId = product.Category.Id,
                    CategoryName = product.Category.Name
                });
            }

            return result;
        }
        public ProductGetVM GetItem(int Id)
        {
            var result = new ProductGetVM();

            var product = _db.Products
                .Where(p => p.Id == Id)
                .Include(p => p.Category)
                .FirstOrDefault();

            if (product != null)
            {
                result.Id = product.Id;
                result.Name = product.Name;
                result.Description = product.Description;
                result.Price = Convert.ToString(product.Price);
                result.CategoryId = product.CategoryId;
                result.CategoryName = product.Category.Name;
            }

            return result;
        }
        public void Create(ProductCreateVM model)
        {
            _db.Products.Add(new Product { Name = model.Name, Description = model.Description, Price = Convert.ToInt32(model.Price), CategoryId = model.CategoryId });
            _db.SaveChanges();
        }
        public void Delete(int Id)
        {
            var product = _db.Products
                   .Where(product => product.Id == Id)
                   .FirstOrDefault();

            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
        }
        public void Edit(ProductEditVM model)
        {
            var product = _db.Products
                .Where(p => p.Id == model.Id)
                .FirstOrDefault();

            if (product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = Convert.ToInt32(model.Price);
                product.CategoryId = model.CategoryId;

                _db.SaveChanges();
            }
        }
    }
}