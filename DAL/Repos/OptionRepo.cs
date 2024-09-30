using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos 
{
    internal class OptionRepo : Repo, IRepo<Option, int, bool>
    {
        public bool Create(Option obj)
        {
            db.Options.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<Option> Get()
        {
            return db.Options.ToList();
        }

        public Option Get(int id)
        {
            return db.Options.Find(id);
        }

        public bool Update(Option obj)
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
                db.Options.Remove(exobj);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
