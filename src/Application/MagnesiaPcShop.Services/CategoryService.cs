using AutoMapper;
using MagnesiaPcShop.DataTransferObjects.Requests.Category;
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

        public void CreateCategory(CreateNewCategoryRequest request)
        {
            var category = request.ConvertToCategory(_mapper);
            _categoryRepository.Create(category);
        }

        public async Task CreateCategoryAsync(CreateNewCategoryRequest request)
        {
            var category = request.ConvertToCategory(_mapper);
            await _categoryRepository.CreateAsync(category);
        }

        public void DeleteProduct(int id)
        {
            _categoryRepository.Delete(id);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public UpdateCategoryRequest GetCategoryForUpdate(int id)
        {
            var category = _categoryRepository.GetById(id);
            var response = category.ConvertToDto<UpdateCategoryRequest>(_mapper);
            return response;
        }

        public async Task<UpdateCategoryRequest> GetCategoryForUpdateAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            var response = category.ConvertToDto<UpdateCategoryRequest>(_mapper);
            return response;
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

        public bool IsCategoryExists(int id)
        {
            return _categoryRepository.IsExists(id);
        }

        public async Task<bool> IsCategoryExistsAsync(int id)
        {
            return await _categoryRepository.IsExistsAsync(id);
        }

        public void UpdateCategory(UpdateCategoryRequest request)
        {
            var category = request.ConvertToCategory(_mapper);
            _categoryRepository.Update(category);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            var category = request.ConvertToCategory(_mapper);
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
