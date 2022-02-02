using DATABASE;

namespace WebApi.Logic
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationContext db = new ApplicationContext();

        private CategoryRepository categoryManager;
        private ProductRepository productManager;
        private UserRepository userManager;
        private OrderRepository orderManager;

        public CategoryRepository Categories
        {
            get
            {
                if (categoryManager == null)
                    categoryManager = new CategoryRepository(db);
                return categoryManager;
            }
        }

        public ProductRepository Products
        {
            get
            {
                if (productManager == null)
                    productManager = new ProductRepository(db);
                return productManager;
            }
        }

        public UserRepository Users
        {
            get
            {
                if (userManager == null)
                    userManager = new UserRepository(db);
                return userManager;
            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (orderManager == null)
                    orderManager = new OrderRepository(db);
                return orderManager;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
