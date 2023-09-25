using TodoIt.Application.Dtos;
using TodoIt.Application.Dtos.Todos;

namespace TodoIt.Application.Repositories.Todos;

public interface ITodosRepository {
    Task<ServiceResponse<List<GetTodoDto>>> GetAll();
    Task<ServiceResponse<GetTodoDto>> Get(int id);
    Task<ServiceResponse<GetTodoDto>> Create(CreateTodoDto todo);
    Task<ServiceResponse<GetTodoDto>> Update(UpdateTodoDto updatedUpdateTodo);
    Task<ServiceResponse<GetTodoDto>> Delete(int id);
}