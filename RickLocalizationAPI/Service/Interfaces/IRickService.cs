using Domain.Entities;
using Domain.Filter;
using RickLocalizationAPI.Models;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IRickService : IBaseService<Rick>
    {
        IEnumerable<RickModel> GetRicks(PaginationFilter filter);

        int CountTotal();

        RickModel GetInfo(int id);
    }
}
