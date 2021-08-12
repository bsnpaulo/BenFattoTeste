using AutoMapper;
using TR.BenFatto.Application.Interfaces;
using TR.BenFatto.Application.ViewModels;
using TR.BenFatto.Domain.Entities;
using TR.BenFatto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.BenFatto.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<List<ProductViewModel>>(products);
        }
        
        public async Task<ProductViewModel> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            return _mapper.Map<ProductViewModel>(product);
        }
        
        public void Add(ProductViewModel model)
        {
            var mapProduct = _mapper.Map<Product>(model);
            _productRepository.Add(mapProduct);
        }

        public void Update(ProductViewModel model)
        {
            var mapProduct = _mapper.Map<Product>(model);
            _productRepository.Update(mapProduct);
        }

        public void Remove(int id)
        {
            var product = _productRepository.GetById(id).Result;
            _productRepository.Remove(product);
        }
    }
}