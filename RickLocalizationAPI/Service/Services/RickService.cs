using AutoMapper;
using Domain.Entities;
using Domain.Filter;
using Service.Interfaces;
using RickLocalizationAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class RickService : BaseService<Rick>, IRickService
    {
        private readonly IRickRepository _rickRepository;
        private readonly IMapper _mapper;

        public RickService(IRickRepository rickRepository, IMapper mapper) : base(rickRepository, mapper)
        {
            _rickRepository = rickRepository;
            _mapper = mapper;
        }

        public IEnumerable<RickModel> GetRicks(PaginationFilter filter)
        {
            var ricks = _rickRepository.GetRicks(filter);

            var ricksModel = ricks
                .Select(s => _mapper.Map<RickModel>(s));

            return ricksModel;
        }

        public int CountTotal()
        {
            return _rickRepository.CountTotal(); ;
        }

        public RickModel GetInfo(int id)
        {
            Rick rick = _rickRepository.GetInfo(id);

            var rickModel = _mapper.Map<RickModel>(rick);

            return rickModel;
        }
    }
}
