using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repos
{
    internal class PollRepo : Repo, IRepo<Poll, int, bool>
    {
        public bool Create(Poll obj)
        {
            db.Polls.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<Poll> Get()
        {
            return db.Polls.Include(p => p.Options).ToList();
        }

        public Poll Get(int id)
        {
            return db.Polls.Include(p => p.Options).FirstOrDefault(p => p.Id == id);
        }

        public bool Update(Poll obj)
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
                db.Polls.Remove(exobj);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
