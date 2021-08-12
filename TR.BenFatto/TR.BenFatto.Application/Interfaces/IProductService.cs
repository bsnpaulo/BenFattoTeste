using TR.BenFatto.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.BenFatto.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(int id);
        void Add(ProductViewModel model);
        void Update(ProductViewModel model);
        void Remove(int id);
    }
}
