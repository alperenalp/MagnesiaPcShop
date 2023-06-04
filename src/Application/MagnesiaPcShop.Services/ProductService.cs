using AutoMapper;
using MagnesiaPcShop.DataTransferObjects.Requests.Product;
using MagnesiaPcShop.DataTransferObjects.Responses.Product;
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
            throw new NotImplementedException();
        }

        public Task CreateProductAsync(CreateNewProductRequest request)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
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

        public IEnumerable<ProductDisplayResponse> GetProductListByCategory(int id)
        {
            var products = _repository.GetProductListByCategory(id);
            var response = products.ConvertToDto<IEnumerable<ProductDisplayResponse>>(_mapper);
            return response;
        }

        public async Task<IEnumerable<ProductDisplayResponse>> GetProductListByCategoryAsync(int id)
        {
            var products = await _repository.GetProductListByCategoryAsync(id);
            var response = products.ConvertToDto<IEnumerable<ProductDisplayResponse>>(_mapper);
            return response;
        }

        public void UpdateProduct(UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }


    }
}
