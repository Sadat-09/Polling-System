using DAL.EF.TableModels;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static IRepo<Poll, int, bool> PollData()
        {

            return new PollRepo();
        }
        public static IRepo<Option, int, bool> OptionData()
        {

            return new OptionRepo();
        }
        public static IRepo<Vote, int, bool> VoteData()
        {

            return new VoteRepo();
        }
        public static IRepo<User, int, bool> UserData()
        {

            return new UserRepo();
        }
        public static IUserRepo UserRepoData()
        {
            return new UserRepo();
        }
        public static IVoteRepo VoteRepoData()
        {
            return new VoteRepo();
        }

    }
}
