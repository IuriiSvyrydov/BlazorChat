
using AutoMapper;
using BlazorChat.Api.Domain.Models;
using BlazorChat.Common.Models.Queries;

namespace BlazorChat.Api.Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginUserViewModel, User>().ReverseMap();
        }
    }

}
