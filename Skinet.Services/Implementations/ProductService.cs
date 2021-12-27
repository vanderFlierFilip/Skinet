﻿using AutoMapper;
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
            var spec = new ProductsWithTypesAndBrandsSpecification(productId);

            var product = await _productsRepo.GetEntityWithSpec(spec);

            return _mapper.Map<ProductReadDto>(product);
        }
        public async Task<IEnumerable<ProductBrand>> GetProductBrands()
        {
            var productBrands = await _productBrandsRepo.ListAllAsync();

            return productBrands;
        }
        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
            var productTypes = await _productTypesRepo.ListAllAsync();

            return productTypes;
        }
        public async Task<ProductCreateDto> CreateProduct(ProductCreateDto product)
        {

            var image = product.PictureFile;
            
            var pictureWithPath = await _fileManager.UploadImageAsync(image);

            var entity = _mapper.Map<Product>(product);
            
            entity.PictureUrl = pictureWithPath;    

            await _productsRepo.CreateAsync(entity);

            return product;

        }
    }
}
