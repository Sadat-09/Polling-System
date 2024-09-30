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
    public class OptionService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Option, OptionDTO>();
                cfg.CreateMap<OptionDTO, Option>();
            });
            return new Mapper(config);
        }

        public static bool Create(OptionDTO obj)
        {
            var data = GetMapper().Map<Option>(obj);
            return DataAccess.OptionData().Create(data);
        }

        public static List<OptionDTO> GetAll()
        {
            var data = DataAccess.OptionData().Get();
            return GetMapper().Map<List<OptionDTO>>(data);
        }

        public static OptionDTO GetById(int id)
        {
            var data = DataAccess.OptionData().Get(id);
            return GetMapper().Map<OptionDTO>(data);
        }

        public static bool Update(OptionDTO obj)
        {
            var data = GetMapper().Map<Option>(obj);
            return DataAccess.OptionData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccess.OptionData().Delete(id);
        }
    }
}
