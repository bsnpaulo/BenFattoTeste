using TR.BenFatto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TR.BenFatto.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
    }
}
