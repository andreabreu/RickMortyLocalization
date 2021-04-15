using Domain.Entities;
using Service.Interfaces;

namespace Repository.Repositories
{
    public class MortyRepository : BaseRepository<Morty>, IMortyRepository
    {
        protected readonly MyContext _myContext;

        public MortyRepository(MyContext myContext) : base(myContext)
        {
            _myContext = myContext;
        }
    }
}
