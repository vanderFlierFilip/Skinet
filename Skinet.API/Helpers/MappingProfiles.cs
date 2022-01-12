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
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>()).ReverseMap();

            CreateMap<ProductCreateDto, Product>()
                 .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrandId))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductTypeId))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.PictureFile.FileName)).ReverseMap();


            CreateMap<ProductUpdateDto, Product>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrandId))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductTypeId))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.PictureFile.FileName)).ReverseMap();

            CreateMap<Product, ProductUpdateDto>()
                 .ForMember(d => d.PictureFile, o => o.MapFrom(s => s.PictureUrl));

            CreateMap<Product, ProductCreateDto>()
               .ForMember(d => d.PictureFile, o => o.MapFrom(s => s.PictureUrl)).ReverseMap();

            CreateMap<int, ProductBrand>().ReverseMap();
            CreateMap<int, ProductType>().ReverseMap();

        }
    }
}