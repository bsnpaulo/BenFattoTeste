using TR.BenFatto.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TR.BenFatto.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAll();
    }
}
