using AutoMapper;
using CreditcardApi.Helps;
using CreditcardApi.DataContract;

namespace CreditcardApi.Mapper
{
    public class CardMapperProfile : Profile
    {
        public CardMapperProfile()
        {
            SourceMemberNamingConvention = new ExactMatchNamingConvention();
            DestinationMemberNamingConvention = new ExactMatchNamingConvention();

            CreateMap<CardViewModel, Card>()
                .ForMember(card => card.CVC, opt => opt.ConvertUsing<DateEncryptoFormatter, string>())
                .ForMember(card => card.CardNumber, opt => opt.ConvertUsing<DateEncryptoFormatter, string>());
            CreateMap<Card, CardViewModel>()
                .ForMember(card => card.CVC, opt => opt.ConvertUsing<DateDecrypFormatter, string>())
                .ForMember(card => card.CardNumber, opt => opt.ConvertUsing<DateDecrypFormatter, string>());
        }

        public class DateEncryptoFormatter : IValueConverter<string, string>
        {
            public string Convert(string source, ResolutionContext context)
            {
                return SymetricEncryptionHelper.Encrypt(source);
            }
        }

        public class DateDecrypFormatter : IValueConverter<string, string>
        {
            public string Convert(string source, ResolutionContext context)
            {
                return SymetricEncryptionHelper.Decrypt(source);
            }
        }
    }
}
