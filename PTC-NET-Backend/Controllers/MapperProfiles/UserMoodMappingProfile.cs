using AutoMapper;
using PTC_NET_Backend.Models;
using PTC_NET_Backend.Models.DTO;

namespace PTC_NET_Backend.Controllers.Mappers;

public class UserMoodMapping : Profile
{
    internal UserMoodMapping()
    {
        CreateMap<UserMoodDto, UserMood>();
        CreateMap<UserMood, UserMoodDto>();
    }
}