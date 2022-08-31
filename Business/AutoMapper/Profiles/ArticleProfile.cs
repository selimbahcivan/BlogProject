using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace Business.AutoMapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            // ArticleAddDto içerisinde CreateDate memberı olmasa bile Article'a maplerken buradaki metodu kullanarak ekleyecek.
            CreateMap<ArticleAddDto, Article>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ArticleUpdateDto, Article>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}