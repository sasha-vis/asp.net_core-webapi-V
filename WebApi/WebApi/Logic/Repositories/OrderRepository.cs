using DATABASE;
using Microsoft.EntityFrameworkCore;
using WebApi.Logic.Repositories;
using WebApi.Models;

namespace WebApi
{
    public class OrderRepository :
        IGetRepository<OrderGetVM>,
        ICreateRepository<OrderCreateVM>,
        IEditRepository<OrderEditVM>,
        IDeleteRepository
    {
        private readonly ApplicationContext _db;
        public OrderRepository(ApplicationContext context)
        {
            _db = context;
        }
        public List<OrderGetVM> GetList()
        {
            var result = new List<OrderGetVM>();

            var orders = _db.Orders
                .Include(o => o.User)
                .Include(o => o.ProductsOrders)
                    .ThenInclude(po => po.Product)
                    .ToList();

            foreach (var order in orders)
            {
                result.Add(new OrderGetVM
                {
                    Id = order.Id,
                    UserId = order.User.Id,
                    UserName = order.User.Name,
                    UserSurname = order.User.Surname,
                    ProductsId = order.ProductsOrders.Select(x => x.ProductId).ToList(),
                    TotalPrice = order.ProductsOrders.Select(x => x.Product).Sum(x => x.Price),
                    Date = order.Date
                });
            }

            return result;
        }
        public OrderGetVM GetItem(int Id)
        {
            var result = new OrderGetVM();

            var order = _db.Orders
                .Where(o => o.Id == Id)
                .Include(o => o.User)
                .Include(o => o.ProductsOrders)
                    .ThenInclude(po => po.Product)
                    .FirstOrDefault();

            if (order != null)
            {
                result.Id = order.Id;
                result.UserId = order.UserId;
                result.UserName = order.User.Name;
                result.UserSurname = order.User.Surname;
                result.ProductsId = order.ProductsOrders.Select(x => x.ProductId).ToList();
                result.TotalPrice = order.ProductsOrders.Select(x => x.Product).Sum(x => x.Price);
                result.Date = order.Date;
            }

            return result;
        }
        public void Create(OrderCreateVM model)
        {
            var order = new Order { Date = $"{DateTime.Now.ToString("g")}", UserId = model.UserId };

            _db.Orders.Add(order);
            _db.SaveChanges();

            var orderId = order.Id;

            var products = model.ProductsId.ToList();

            foreach (int product in products)
            {
                _db.ProductsOrders.Add(new ProductsOrder { OrderId = orderId, ProductId = product });
                _db.SaveChanges();
            }
        }
        public void Delete(int Id)
        {
            ProductsOrder productsOrder = _db.ProductsOrders
                  .Where(productsOrder => productsOrder.OrderId == Id)
                  .FirstOrDefault();

            if (productsOrder != null) {
                _db.ProductsOrders.Remove(productsOrder);
            }

            var order = _db.Orders
                  .Where(order => order.Id == Id)
                  .FirstOrDefault();

            if (order != null)
            {
                _db.Orders.Remove(order);

                _db.SaveChanges();
            }
        }
        public void Edit(OrderEditVM model)
        {
            var order = _db.Orders
                .Where(o => o.Id == model.Id)
                .FirstOrDefault();

            if (order != null)
            {
                order.Date = DateTime.Now.ToString("g");
                order.UserId = model.UserId;
                var orderId = order.Id;

                _db.SaveChanges();

                var productsOrders = _db.ProductsOrders.Where(po => po.OrderId == orderId);

                foreach (ProductsOrder product in productsOrders)
                {
                    _db.ProductsOrders.Remove(product);
                }

                var products = model.ProductsId.ToList();

                foreach (int product in products)
                {
                    _db.ProductsOrders.Add(new ProductsOrder { OrderId = orderId, ProductId = product });
                    _db.SaveChanges();
                }
            }
        }
    }
}