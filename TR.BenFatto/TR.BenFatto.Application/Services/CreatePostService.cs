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
using System.IO;

namespace TR.BenFatto.Application.Services
{
    public class CreatePostService : ICreatePostService
    {
        private readonly ICreatePostRepository _repository;
        private readonly IMapper _mapper;

        public CreatePostService(ICreatePostRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool ProcessFile(CreatePost file)
        {
            try
            {
                return _repository.ProcessFile(file.Arquivo);

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}