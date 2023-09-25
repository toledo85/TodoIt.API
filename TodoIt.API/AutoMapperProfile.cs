using AutoMapper;
using TodoIt.Application.Dtos.Todos;
using TodoIt.Domain;

namespace TodoIt.API;

public class AutoMapperProfile: Profile {
    public AutoMapperProfile() {
        CreateMap<Todo, GetTodoDto>();
        CreateMap<CreateTodoDto, Todo>();
        CreateMap<UpdateTodoDto, Todo>();
    }
}