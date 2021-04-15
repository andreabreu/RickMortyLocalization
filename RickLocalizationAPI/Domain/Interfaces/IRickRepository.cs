using Domain.Entities;
using Domain.Filter;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IRickRepository : IBaseRepository<Rick>
    {
        IEnumerable<Rick> GetRicks(PaginationFilter filter);

        int CountTotal();

        Rick GetInfo(int id);
    }
}
