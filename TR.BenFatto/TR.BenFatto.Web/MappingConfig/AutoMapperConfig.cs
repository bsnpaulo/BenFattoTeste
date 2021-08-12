using TR.BenFatto.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TR.BenFatto.Web.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException();

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile),
                typeof(ViewModelToDomainMappingProfile));
        }
    }
}
