using AutoMapper;
using Domain.Entities;
using Service.Interfaces;

namespace Service.Services
{
    public class MortyService : BaseService<Morty>, IMortyService
    {
        public MortyService(IBaseRepository<Morty> baseRepository, IMapper mapper) : base(baseRepository, mapper)
        {

        }
    }
}
