using DATABASE;
using Microsoft.EntityFrameworkCore;
using WebApi.Logic.Repositories;
using WebApi.Models;
using WebApi.Models.User;

namespace WebApi
{
    public class UserRepository :
        IGetRepository<UserGetVM>,
        ICreateRepository<UserCreateVM>,
        IEditRepository<UserEditVM>,
        IDeleteRepository
    {
        private readonly ApplicationContext _db;
        public UserRepository(ApplicationContext context)
        {
            _db = context;
        }
        public List<UserGetVM> GetList()
        {
            var result = new List<UserGetVM>();

            var users = _db.Users
                .Include(u => u.Phone)
                .Include(u => u.City)
                .ToList();

            foreach (var user in users)
            {
                result.Add(new UserGetVM
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Age = Convert.ToString(user.Age),
                    PhoneModel = user.Phone.Model,
                    PhoneNumber = user.Phone.Number,
                    CityId = user.City.Id,
                    CityName = user.City.Name
                });
            }

            return result;
        }
        public UserGetVM GetItem(int Id)
        {
            var result = new UserGetVM();

            var user = _db.Users
                .Where(u => u.Id == Id)
                .Include(u => u.City)
                .FirstOrDefault();

            if (user != null)
            {
                result.Id = user.Id;
                result.Name = user.Name;
                result.Surname = user.Surname;
                result.Age = Convert.ToString(user.Age);
                result.CityId = user.CityId;
                result.CityName = user.City.Name;

                var phone = _db.Phones
                    .Where(p => p.Id == Id)
                    .FirstOrDefault();

                result.PhoneModel = phone.Model;
                result.PhoneNumber = phone.Number;

                phone.User = user;
            }

            return result;
        }

        public void Create(UserCreateVM model)
        {
            var user = new User { Name = model.Name, Surname = model.Surname, Age = Convert.ToInt32(model.Age), CityId = Convert.ToInt32(model.CityId) };

            _db.Users.Add(user);

            var phone = new Phone { Model = model.PhoneModel, Number = model.PhoneNumber };

            phone.User = user;
            _db.Phones.Add(phone);

            _db.SaveChanges();
        }
        public void Delete(int Id)
        {
            var user = _db.Users
                  .Where(user => user.Id == Id)
                  .FirstOrDefault();

            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }
        public void Edit(UserEditVM model)
        {
            var user = _db.Users
                .Where(u => u.Id == model.Id)
                .FirstOrDefault();

            if (user != null)
            {
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Age = Convert.ToInt32(model.Age);
                user.CityId = model.CityId;

                _db.SaveChanges();

                var phone = _db.Phones
                    .Where(p => p.Id == model.Id)
                    .FirstOrDefault();

                phone.Model = model.PhoneModel;
                phone.Number = model.PhoneNumber;

                phone.User = user;

                _db.SaveChanges();
            }
        }  
    }
}
