using AutoMapper;
using Skinet.Core.Entities;
using Skinet.Model.Models;

namespace Skinet.API.Helpers
{
    public static class MapperExtensions
    {
        private static readonly IMapper _mapper;
        static MapperExtensions()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfiles());
            });
            _mapper = config.CreateMapper();

        }
        public static Product ToProduct(this ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);

            product.ProductBrand = new ProductBrand
            {
                Name = productCreateDto.ProductBrand
            };
            product.ProductType = new ProductType()
            {
                Name = productCreateDto.ProductType
            };

            return product;
        }
    }
}
