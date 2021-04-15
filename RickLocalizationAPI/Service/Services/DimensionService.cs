using AutoMapper;
using Domain.Entities;
using Service.Interfaces;
using Domain.Models;

namespace Service.Services
{
    public class DimensionService : BaseService<Dimension>, IDimensionService
    {
        private readonly IDimensionRepository _dimensionRepository;
        private readonly IRickRepository _rickRepository;
        private readonly IMapper _mapper;

        public DimensionService(IDimensionRepository dimensionRepository, IRickRepository rickRepository, IMapper mapper) : base(dimensionRepository, mapper)
        {
            _dimensionRepository = dimensionRepository;
            _rickRepository = rickRepository;
            _mapper = mapper;
        }

        public void AddTravel(RickDimensionInputModel rickDimensionDto)
        {
            var rick = _rickRepository.Select(rickDimensionDto.RickId);
            var dimension = _dimensionRepository.Select(rickDimensionDto.DimensionId);

            var rickDimension = new RickDimension()
            {
                RickId = rick.Id,
                Rick = rick,
                DimensionId = dimension.Id,
                Dimension = dimension
            };

            _dimensionRepository.AddTravel(rickDimension);
        }
    }
}
