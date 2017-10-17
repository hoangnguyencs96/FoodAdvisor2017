using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class GirlfriendDao
    {
        OnlineShopDbContext db = null;
        public GirlfriendDao()
        {
            db = new OnlineShopDbContext();
        }

        public IQueryable<Girlfriend> Girlfriends
        {
            get { return db.Girlfriends; }
        }

        public bool Insert(Girlfriend entity)
        {
            Girlfriend db_entry = db.Girlfriends.Find(entity.ID);

            if (db_entry == null)
            {
                return false;
            }

            db.Girlfriends.Add(entity);
            db.SaveChanges();

            return true;
        }

        public bool Update(Girlfriend entity)
        {
            Girlfriend db_entry = db.Girlfriends.Find(entity.ID);

            if (db_entry == null)
            {
                return false;
            }

            db_entry.Description = entity.Description;
            db_entry.Image = entity.Image;
            db_entry.Name = entity.Name;
            db_entry.MoreImages = entity.MoreImages;
            db.SaveChanges();
            return true;
        }

        public bool Delete(Girlfriend entity)
        {
            Girlfriend db_entry = db.Girlfriends.Find(entity.ID);
            if (db_entry == null)
            {
                return false;
            }

            db.Girlfriends.Remove(db_entry);
            db.SaveChanges();

            return true;
        }
    }
}
