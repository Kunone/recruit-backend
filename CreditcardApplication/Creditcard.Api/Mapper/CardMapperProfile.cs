using AutoMapper;
using Creditcard.DataContract;

namespace Creditcard.Api.Mapper
{
    public class CardMapperProfile : Profile
    {
        public CardMapperProfile()
        {
            SourceMemberNamingConvention = new ExactMatchNamingConvention();
            DestinationMemberNamingConvention = new ExactMatchNamingConvention();

            CreateMap<CardViewModel, Card>();
            CreateMap<Card, CardViewModel>();
        }
    }
}
