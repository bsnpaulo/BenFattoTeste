using AutoMapper;
using TR.BenFatto.Application.Interfaces;
using TR.BenFatto.Application.ViewModels;
using TR.BenFatto.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TR.BenFatto.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            var categoryList = await _repository.GetAll();
            return _mapper.Map<List<CategoryViewModel>>(categoryList);
        }
    }
}