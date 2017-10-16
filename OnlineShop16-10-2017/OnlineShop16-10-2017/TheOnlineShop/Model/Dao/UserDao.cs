using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public User GetByID(string UserName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == UserName);
        }

        public bool Login(string Username, string Password)
        {
            var result = db.Users.Count(x => x.UserName == Username && x.Password == Password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
