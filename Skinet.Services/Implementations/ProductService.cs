using AutoMapper;
using Skinet.Model.Models;
using Skinet.Core;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skinet.Infrastructure.Data;

namespace Skinet.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo;
        private readonly IGenericRepository<ProductType> _productTypesRepo;
        private readonly IFileManager _fileManager;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productBrandsRepo,
        IGenericRepository<ProductType> productTypesRepo, IMapper mapper, IFileManager fileManager)
        {
            _productBrandsRepo = productBrandsRepo;
            _productTypesRepo = productTypesRepo;
            _mapper = mapper;
            _productsRepo = productsRepo;
            _fileManager = fileManager;
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await _productsRepo.ListAsync(spec);

            return _mapper.Map<IReadOnlyList<ProductReadDto>>(products);
        }

        public async Task<ProductReadDto> GetProduct(int productId)
        {
            var product = await ApplySpecificationAndGetEntityByIdAsync(productId);

            return _mapper.Map<ProductReadDto>(product);
        }
        public async Task<IEnumerable<ProductBrandDto>> GetProductBrands()
        {
            var productBrands = await _productBrandsRepo.ListAllAsync();

            return _mapper.Map<IEnumerable<ProductBrandDto>>(productBrands);
        }
        public async Task<IEnumerable<ProductTypeDto>> GetProductTypes()
        {
            var productTypes = await _productTypesRepo.ListAllAsync();

            return _mapper.Map<IEnumerable<ProductTypeDto>>(productTypes);

        }
        public async Task<ProductReadDto> CreateProduct(ProductCreateDto model)
        {
            var products = await _productsRepo.ListAllAsync();
            
            bool productAlreadyExists = 
                products.Any(p => p.Name == model.Name);    
            
            if (productAlreadyExists)
            {
                throw new Exception($"Product With Name: {model.Name} Already Exists");
            }

            var entity = _mapper.Map<Product>(model);

            entity.PictureUrl = await UploadImageFromModelAndGetImagePathAsync(model);

            await _productsRepo.CreateAsync(entity);

            var product = await ApplySpecificationAndGetEntityByIdAsync(entity.Id);

            return _mapper.Map<ProductReadDto>(product);

        }

        public async Task<ProductUpdateDto> UpdateProduct(ProductUpdateDto model)
        {
            var entity = await ApplySpecificationAndGetEntityByIdAsync(model.Id);

            var updatedEntity = _mapper.Map(model, entity);

            updatedEntity.PictureUrl = await UploadImageFromModelAndGetImagePathAsync(model);

            await _productsRepo.UpdateAsync(updatedEntity);

            var product = await ApplySpecificationAndGetEntityByIdAsync(model.Id);

            return model;

        }

        public async Task<bool> DeleteAsync(int productId)
        {
            var product = await _productsRepo.GetByIdAsync(productId);

            if (product == null)
                return false;

            _productsRepo.DeleteAsync(productId);

            return true;
        }

        
        private async Task<Product> ApplySpecificationAndGetEntityByIdAsync(int productId)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productId);

            var entity = await _productsRepo.GetEntityWithSpec(spec);

            return entity;
        }

        private async Task<string> UploadImageFromModelAndGetImagePathAsync(ProductCreateDto model)
        {
            var image = model.PictureFile;

            var pictureWithPath = await _fileManager.UploadImageAsync(image);

            return pictureWithPath;
        }
        private async Task<string> UploadImageFromModelAndGetImagePathAsync(ProductUpdateDto model)
        {
            var image = model.PictureFile;

            var pictureWithPath = await _fileManager.UploadImageAsync(image);

            return pictureWithPath;
        }
    }
}
