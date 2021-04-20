using System;
using AutoMapper;
using DBankAPI.Entities;
using DBankAPI.ViewModels;

namespace DBankAPI.DBankApplication.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContaCorrente, ContaCorrenteViewModel>();
            CreateMap<Lancamento, LancamentoViewModel>();

            CreateMap<ContaCorrenteViewModel,ContaCorrente>();
            CreateMap<LancamentoViewModel, Lancamento>();

            CreateMap<Lancamento, ExtratoViewModel>()
                .ForMember(vm => vm.Operacao, map => map.MapFrom(lanc => Enum.GetName(lanc.Operacao)));
        }
    }
}
