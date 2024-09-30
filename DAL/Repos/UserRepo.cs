using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo:Repo,IUserRepo
    {
        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var exobj = Get(obj.Id);
            if (exobj != null)
            {
                db.Entry(exobj).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj != null)
            {
                db.Users.Remove(exobj);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public User GetByUsernameAndPassword(string UserName, string password)
        {
            return db.Users.FirstOrDefault(u => u.UserName == UserName && u.Password == password);
        }
    }
}
