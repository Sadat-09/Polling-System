using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class VoteRepo:Repo,IVoteRepo
    {
        public bool Create(Vote obj)
        {
            db.Votes.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<Vote> Get()
        {
            return db.Votes.ToList();
        }

        public Vote Get(int id)
        {
            return db.Votes.Find(id);
        }
        public List<Vote> GetByPollId(int pollId)
        {
            return db.Votes.Where(v => v.PollId == pollId).ToList();
        }

        public bool Update(Vote obj)
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
                db.Votes.Remove(exobj);
                return db.SaveChanges() > 0;
            }
            return false;
        }

    }
}
