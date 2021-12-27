using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Skinet.Model.Models;
using Skinet.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Skinet.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Product, ProductReadDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

            CreateMap<ProductCreateDto, Product>()
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.PictureFile.FileName))
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => new ProductBrand { Name = s.ProductBrand }))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => new ProductType { Name = s.ProductType }));

            CreateMap<Product, ProductCreateDto>()
               .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
               .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
               .ForMember(d => d.PictureFile, o => o.MapFrom(s => s.PictureUrl));

            CreateMap<string, ProductType>();
            CreateMap<string, ProductBrand>();



        }

    }
}