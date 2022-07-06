
using AutoMapper;
using BlazorChat.Api.Domain.Models;
using BlazorChat.Common.Models.Queries;
using BlazorChat.Common.Models.RequestModel;

namespace BlazorChat.Api.Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginUserViewModel, User>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<CreateEntryCommand, Entry>().ReverseMap();
            CreateMap<CreateEntryCommentCommand,EntryComment>().ReverseMap();

        }
    }

}
