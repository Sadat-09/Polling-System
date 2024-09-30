using AutoMapper;
using BLL.DTOs;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VoteService
    {

        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vote, VoteDTO>();
                cfg.CreateMap<VoteDTO, Vote>();
            });
            return new Mapper(config);
        }

        public static bool AddVote(VoteDTO obj)
        {
            var poll = PollService.GetById(obj.PollId);

            if (DateTime.Now > poll.EndDateTime)
            {
                throw new Exception("Poll has ended. Voting is no longer allowed.");
            }
            var data = GetMapper().Map<Vote>(obj);
            return DataAccess.VoteData().Create(data);
        }

        public static List<VoteDTO> GetAll()
        {
            var data = DataAccess.VoteData().Get();
            return GetMapper().Map<List<VoteDTO>>(data);
        }

        public static VoteDTO GetById(int id)
        {
            var data = DataAccess.VoteData().Get(id);
            return GetMapper().Map<VoteDTO>(data);
        }

        public static Dictionary<string, int> GetResults(int pollId)
        {
            var votes = DataAccess.VoteRepoData().GetByPollId(pollId);

            var results = votes
                .GroupBy(v => v.OptionId)
                .ToDictionary(g => DataAccess.OptionData().Get(g.Key).OptionText, g => g.Count());

            return results;
        }
    }
}
