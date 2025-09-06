using AuthTask1.Dto;
using AuthTask1.Models;
using AutoMapper;


namespace CRUD_Operations.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<RegisterModel, User>();
        }
    }
}
