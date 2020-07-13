using AutoMapper;
using Tenanpp.Models;
using Tenanpp.DAL.Models;
public class OpinionInmobiliariaProfile : Profile
{
	public OpinionInmobiliariaProfile()
	{
		CreateMap<OpinionInmobiliariaPost, OpinionInmobiliaria>();
	}
}