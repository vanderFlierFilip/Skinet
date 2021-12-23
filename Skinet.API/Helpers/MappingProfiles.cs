using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Skinet.Model.Models;
using Skinet.Core.Entities;

namespace Skinet.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductReadDto>()
                .ForMember(d =>  d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d =>  d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }

    }
}