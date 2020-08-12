using AutoMapper;
using Tenanpp.Models;
using Tenanpp.DAL.Models;
public class LugarProfile : Profile
{
	public LugarProfile()
	{
		CreateMap<LugarPost, Lugar>();
        CreateMap<Lugar, LugarPost>();
	}
}