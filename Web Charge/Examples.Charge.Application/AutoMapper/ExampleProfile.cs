using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.ViewModels;

namespace Examples.Charge.Application.AutoMapper
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<Example, ExampleDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            #region ViewModelToDomain
            CreateMap<PersonPhoneViewModel, PersonPhone>();
            #endregion

            #region DomainToViewModel
            CreateMap<PersonPhone, PersonPhoneViewModel>();
            #endregion
        }
    }
}
