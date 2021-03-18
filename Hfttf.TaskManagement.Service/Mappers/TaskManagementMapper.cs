using AutoMapper;
using Hfttf.TaskManagement.Service.Services.Addresses.Mappers;
using System;

namespace Hfttf.TaskManagement.Service.Mappers
{
    public class TaskManagementMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(configuration =>
            {
                // This line ensures that internal properties are also mapped over.
                configuration.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                configuration.AddProfile<AddressProfile>();

            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
