using AutoMapper;
using task_manager.Domain.DTOs;

namespace task_manager.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Domain.Entities.Task, CreateTaskDto>().ReverseMap();
        CreateMap<Domain.Entities.Task, UpdateTaskDto>().ReverseMap();
    }
}