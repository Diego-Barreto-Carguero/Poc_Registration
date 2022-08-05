using AutoMapper;
using Carguero.Registration.Poc.Domain.Entities.Partners;
using Carguero.Registration.Poc.Domain.Models.Partners;

namespace Carguero.Registration.Poc.Domain.Utils.Profiles.Partners
{
    internal class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverResponse>();
            CreateMap<DriverRequest, Driver>();
        }
    }
}
