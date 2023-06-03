using MagnesiaPcShop.DataTransferObjects.Requests.Product;
using MagnesiaPcShop.DataTransferObjects.Responses.Product;
using MagnesiaPcShop.Infrastructure.Repositories;
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

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
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
            throw new NotImplementedException();
        }

        public Task<ProductDisplayResponse> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDisplayResponse> GetProductList()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDisplayResponse>> GetProductListAsync()
        {
            throw new NotImplementedException();
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
