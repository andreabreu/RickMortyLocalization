using Domain.Entities;
using Domain.Filter;
using Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class RickRepository : BaseRepository<Rick>, IRickRepository
    {
        protected readonly MyContext _myContext;

        public RickRepository(MyContext myContext) : base(myContext)
        {
            _myContext = myContext;
        }

        public IEnumerable<Rick> GetRicks(PaginationFilter filter)
        {
            var ricks = _myContext.Rick
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
               .Include(i => i.Dimension)
               .Include(i => i.Morty)
               .Include(i => i.RickDimensions);


            return ricks;
        }

        public int CountTotal()
        {
            return _myContext.Rick.Count();
        }

        public Rick GetInfo(int id)
        {
            var rick = _myContext.Rick
                .Include(i => i.Morty)
               .Include(i => i.Dimension)
               .Include(i => i.RickDimensions)
               .FirstOrDefault(x => x.Id == id);

            return rick;

        }
    }
}
