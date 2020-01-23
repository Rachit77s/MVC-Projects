using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Dec_2019.DTOS;
using Vidly_Dec_2019.Models;

namespace Vidly_Dec_2019.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDto>();
            });

            IMapper mapper = config.CreateMapper();
           // var source = new Source();
            //var dest = mapper.Map<Customer, CustomerDto>(source);
        }
    }
}