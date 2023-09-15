using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Product,UpsertProductDTO>().ReverseMap();

            // TODO for price and quantity set individual conditions
            CreateMap<PatchProductDTO, Product>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));
        }
    }
}