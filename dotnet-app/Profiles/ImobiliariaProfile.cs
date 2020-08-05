using AutoMapper;
using Tenanpp.Models;
using Tenanpp.DAL.Models;
public class ImobiliariaProfile : Profile
{
	public ImobiliariaProfile()
	{
		CreateMap<Inmobiliaria, InmobiliariaSearch>();
	}
}