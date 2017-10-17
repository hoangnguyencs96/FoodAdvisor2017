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
        public bool Insert(User entity)
        {
            User db_entry = db.Users.Find(entity.ID);

            if (db_entry == null)
            {
                return false;
            }

            db.Users.Add(entity);
            db.SaveChanges();

            return true;
        }

        public bool ChangePassword(User entity)
        {
            User db_entry = db.Users.Find(entity.ID);

            if (db_entry == null)
            {
                return false;
            }

            db_entry.Password = entity.Password;
            db.SaveChanges();
            return true;
        }

        public bool Delete(User entity)
        {
            User db_entry = db.Users.Find(entity.ID);
            if (db_entry == null)
            {
                return false;
            }

            db.Users.Remove(db_entry);
            db.SaveChanges();

            return true;
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
