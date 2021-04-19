using System;
using AutoMapper;
using DBankAPI.Entities;
using DBankAPI.ViewModels;

namespace DBankAPI.DBankApplication.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ContaCorrente, ContaCorrenteViewModel>();
            CreateMap<Lancamento, LancamentoViewModel>();

            CreateMap<ContaCorrenteViewModel,ContaCorrente>();
            CreateMap<LancamentoViewModel, Lancamento>();
        }
    }
}
