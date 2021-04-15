using Domain.Entities;

namespace Service.Interfaces
{
    public interface IDimensionRepository : IBaseRepository<Dimension>
    {
        void AddTravel(RickDimension rickDimension);
    }
}
