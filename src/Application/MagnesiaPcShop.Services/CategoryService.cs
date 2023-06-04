using AutoMapper;
using MagnesiaPcShop.DataTransferObjects.Responses.Category;
using MagnesiaPcShop.Infrastructure.Repositories;
using MagnesiaPcShop.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDisplayResponse> GetCategoryList()
        {
            var categories = _categoryRepository.GetAll();
            var response = categories.ConvertToDto<IEnumerable<CategoryDisplayResponse>>(_mapper);
            return response;
        }

        public async Task<IEnumerable<CategoryDisplayResponse>> GetCategoryListAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var response = categories.ConvertToDto<IEnumerable<CategoryDisplayResponse>>(_mapper);
            return response;
        }
    }
}
