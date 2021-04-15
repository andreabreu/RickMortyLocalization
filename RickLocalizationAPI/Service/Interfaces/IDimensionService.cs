using Domain.Entities;
using Domain.Models;

namespace Service.Interfaces
{
    public interface IDimensionService : IBaseService<Dimension>
    {
        void AddTravel(RickDimensionInputModel rickDimension);
    }
}
