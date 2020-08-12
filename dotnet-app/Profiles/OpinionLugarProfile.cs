using AutoMapper;
using Tenanpp.Models;
using Tenanpp.DAL.Models;
public class OpinionLugarProfile : Profile
{
	public OpinionLugarProfile()
	{
		CreateMap<OpinionLugar, OpinionLugarPost>();
        CreateMap<OpinionLugarPost, OpinionLugar>();
	}
}