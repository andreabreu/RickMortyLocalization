using Domain.Entities;
using Service.Interfaces;

namespace Repository.Repositories
{
    public class DimensionRepository : BaseRepository<Dimension>, IDimensionRepository
    {
        protected readonly MyContext _myContext;

        public DimensionRepository(MyContext myContext) : base(myContext)
        {
            _myContext = myContext;
        }

        public void AddTravel(RickDimension rickDimension)
        {
            _myContext.RickDimension.Add(rickDimension);
            _myContext.SaveChanges();
        }

    }
}
