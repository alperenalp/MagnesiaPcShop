using AutoMapper;
using MagnesiaPcShop.DataTransferObjects.Requests.Product;
using MagnesiaPcShop.DataTransferObjects.Responses.Product;
using MagnesiaPcShop.Entities;
using MagnesiaPcShop.Infrastructure.Repositories;
using MagnesiaPcShop.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreateProduct(CreateNewProductRequest request)
        {
            var product = request.ConvertToProduct(_mapper);
            _repository.CreateAsync(product);
        }

        public async Task CreateProductAsync(CreateNewProductRequest request)
        {
            var product = request.ConvertToProduct(_mapper);
            await _repository.CreateAsync(product);
        }

        public void DeleteProduct(int id)
        {
            _repository.Delete(id);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public ProductDisplayResponse GetProductById(int id)
        {
            var product = _repository.GetById(id);
            var response = product.ConvertToDto<ProductDisplayResponse>(_mapper);
            return response;
        }

        public async Task<ProductDisplayResponse> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            var response = product.ConvertToDto<ProductDisplayResponse>(_mapper);
            return response;
        }

        public UpdateProductRequest GetProductForUpdate(int id)
        {
            var product = _repository.GetById(id);
            var response = product.ConvertToDto<UpdateProductRequest>(_mapper);
            return response;
        }

        public async Task<UpdateProductRequest> GetProductForUpdateAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            var response = product.ConvertToDto<UpdateProductRequest>(_mapper);
            return response;
        }

        public IEnumerable<ProductDisplayResponse> GetProductList()
        {
            var products = _repository.GetAll();
            var response = products.ConvertToDto<IEnumerable<ProductDisplayResponse>>(_mapper);
            return response;
        }

        public async Task<IEnumerable<ProductDisplayResponse>> GetProductListAsync()
        {
            var products = await _repository.GetAllAsync();
            var response = products.ConvertToDto<IEnumerable<ProductDisplayResponse>>(_mapper);
            return response;
        }

        public IEnumerable<ProductDisplayResponse> GetProductListByCategory(int categoryId)
        {
            var products = _repository.GetProductListByCategory(categoryId);
            var response = products.ConvertToDto<IEnumerable<ProductDisplayResponse>>(_mapper);
            return response;
        }

        public async Task<IEnumerable<ProductDisplayResponse>> GetProductListByCategoryAsync(int categoryId)
        {
            var products = await _repository.GetProductListByCategoryAsync(categoryId);
            var response = products.ConvertToDto<IEnumerable<ProductDisplayResponse>>(_mapper);
            return response;
        }

        public IEnumerable<ProductDisplayResponse> GetProductListByName(string productName)
        {
            var products = _repository.GetProductListByName(productName);
            var response = products.ConvertToDto<IEnumerable<ProductDisplayResponse>>(_mapper);
            return response;
        }

        public async Task<IEnumerable<ProductDisplayResponse>> GetProductListByNameAsync(string productName)
        {
            var products = await _repository.GetProductListByNameAsync(productName);
            var response = products.ConvertToDto<IEnumerable<ProductDisplayResponse>>(_mapper);
            return response;
        }

        public bool IsProductExists(int id)
        {
            return _repository.IsExists(id);
        }

        public async Task<bool> IsProductExistsAsync(int id)
        {
            return await _repository.IsExistsAsync(id);
        }

        public void UpdateProduct(UpdateProductRequest request)
        {
            var product = request.ConvertToProduct(_mapper);
            _repository.Update(product);
        }

        public async Task UpdateProductAsync(UpdateProductRequest request)
        {
            var product = request.ConvertToProduct(_mapper);
            await _repository.UpdateAsync(product);
        }


    }
}
