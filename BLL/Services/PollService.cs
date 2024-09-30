using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PollService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Poll, PollDTO>().ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options));
                cfg.CreateMap<Poll, PollDTO>();
                cfg.CreateMap<PollDTO, Poll>();
                cfg.CreateMap<Option, OptionDTO>();  
                cfg.CreateMap<OptionDTO, Option>();
            });
            return new Mapper(config);
        }

        public static bool Create(PollDTO obj)
        {
            var data = GetMapper().Map<Poll>(obj);
            return DataAccess.PollData().Create(data);
        }

        public static List<PollDTO> GetAll()
        {
            var data = DataAccess.PollData().Get();
            return GetMapper().Map<List<PollDTO>>(data);
        }

        public static PollDTO GetById(int id)
        {
            var data = DataAccess.PollData().Get(id);
            return GetMapper().Map<PollDTO>(data);
        }

        public static bool Update(PollDTO obj)
        {
            var data = GetMapper().Map<Poll>(obj);
            return DataAccess.PollData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccess.PollData().Delete(id);
        }
    }
}
