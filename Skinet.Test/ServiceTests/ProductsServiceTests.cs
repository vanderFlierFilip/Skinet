using AutoMapper;
using Moq;
using Skinet.API.Helpers;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Infrastructure.Data;
using Skinet.Model.Models;
using Skinet.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Skinet.Test.ServiceTests
{
    public class ProductsServiceTests
    {
        private readonly Mock<IGenericRepository<Product>> _productsRepoMock = new Mock<IGenericRepository<Product>>();
        private readonly Mock<IGenericRepository<ProductType>> _productTypesRepoMock = new Mock<IGenericRepository<ProductType>>();
        private readonly Mock<IGenericRepository<ProductBrand>> _productBrandsRepoMock = new Mock<IGenericRepository<ProductBrand>>();
        private readonly Mock<IFileManager> _fileManager = new Mock<IFileManager>();


        private readonly ProductService _sut;

        private readonly IMapper _mapper;
        public ProductsServiceTests()
        {
            if (_mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfiles());
                });
                _mapper = config.CreateMapper();
            }
            _sut = new ProductService(_productsRepoMock.Object, 
                                      _productBrandsRepoMock.Object, 
                                      _productTypesRepoMock.Object,
                                      _mapper,
                                      _fileManager.Object);
        }
        [Fact]
        public async Task GetProduct_ShouldReturnASingleProductById()
        {
            // Arrange
            var productType = new ProductType()
            {
                Id = 1,
                Name = "Tatarska chizma",
            };
            var productBrand = new ProductBrand()
            {
                Id = 1,
                Name = "BVLGARI"
            };

            var productId = 1;
           
            var product = new Product()
            {
                Id = productId,
                Name = "Snowboard Boots",
                Description = "Snowboarding boots that keep you cold in winter",
                Price = 19.99m,
                PictureUrl = "https://localhost:5001/images/products/image1.png",
                ProductType = productType,
                ProductTypeId = productType.Id,
                ProductBrand = productBrand,
                ProductBrandId = productBrand.Id
            };

            var productReadDto = new ProductReadDto()
            {
                Id = productId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,    
                ProductBrand = productBrand.Name,
                ProductType = productType.Name,

            };

            _productsRepoMock.Setup(p => p.GetByIdAsync(productId)).ReturnsAsync(product);

            // Act
            var productDto = await _sut.GetProduct(productId);

            // Assert
            Assert.Equal(productId, productReadDto.Id);
            Assert.Equal(product.Name, productReadDto.Name);
            Assert.Equal(product.Description, productReadDto.Description);
            Assert.Equal(product.Price, productReadDto.Price);
            Assert.Equal(product.ProductBrand.Name, productReadDto.ProductBrand);
            Assert.Equal(product.ProductType.Name, productReadDto.ProductType);


        }

        [Fact]
        public async Task GetProductWithSpecification_ShouldReturnProductWithProductTypeAndProductBrand()
        {
            // Arrange
            var productType = new ProductType()
            {
                Id = 1,
                Name = "Tatarska chizma",
            };
            var productBrand = new ProductBrand()
            {
                Id = 1,
                Name = "BVLGARI"
            };

            var productId = 1;

            var product = new Product()
            {
                Id = productId,
                Name = "Snowboard Boots",
                Description = "Snowboarding boots that keep you cold in winter",
                Price = 19.99m,
                PictureUrl = "https://localhost:5001/images/products/image1.png",
                ProductType = productType,
                ProductTypeId = productType.Id,
                ProductBrand = productBrand,
                ProductBrandId = productBrand.Id
            };

            var productReadDto = new ProductReadDto()
            {
                Id = productId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductBrand = productBrand.Name,
                ProductType = productType.Name,

            };

            _productsRepoMock.Setup(p => p.GetByIdAsync(productId)).ReturnsAsync(product);

            // Act
            var productDto = await _sut.GetProduct(productId);

            // Assert
            Assert.Equal(productId, productReadDto.Id);
        }
    }
}
