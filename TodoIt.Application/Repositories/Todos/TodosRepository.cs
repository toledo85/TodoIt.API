using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoIt.Application.Dtos;
using TodoIt.Application.Dtos.Todos;
using Todoit.Application.Interfaces;
using TodoIt.Domain;
using TodoIt.Persistence;

namespace TodoIt.Application.Repositories.Todos;

public class TodosRepository : ITodosRepository {
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IUserAccessor _userAccessor;

    public TodosRepository(DataContext context, IMapper mapper, IUserAccessor userAccessor) {
        _context = context;
        _mapper = mapper;
        _userAccessor = userAccessor;
    }

    public async Task<ServiceResponse<List<GetTodoDto>>> GetAll() {
        ServiceResponse<List<GetTodoDto>> response = new() {
            Data = await _context.Todos
                .Where(t => !t.IsDeleted)
                .Include(t => t.User)
            .Where(t => t.User != null && t.User.Id == _userAccessor.GetUserName())
                .Select(t => _mapper.Map<GetTodoDto>(t))
                .ToListAsync()
        };

        return response;
    }

    public async Task<ServiceResponse<GetTodoDto>> Get(int id) {
        ServiceResponse<GetTodoDto> response = new();
            
        var todo = await _context.Todos
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Id == id && t.User != null && t.User.Id == _userAccessor.GetUserName());

        response.Data = _mapper.Map<GetTodoDto>(todo);
            
        return response;
    }

    public async Task<ServiceResponse<GetTodoDto>> Create(CreateTodoDto todo) {
        var newTodo = _mapper.Map<Todo>(todo);
        newTodo.User = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == _userAccessor.GetUserName());

        _context.Todos.Add(newTodo);
        await _context.SaveChangesAsync();

        ServiceResponse<GetTodoDto> response = new();
        response.Data = _mapper.Map<GetTodoDto>(newTodo);
        
        return response;
    }

    public async Task<ServiceResponse<GetTodoDto>> Update(UpdateTodoDto updatedUpdateTodo) {
        ServiceResponse<GetTodoDto> response = new();
        
        var todo = await _context.Todos
            .Include(t => t.User)
            .FirstOrDefaultAsync(t =>
                t.Id == updatedUpdateTodo.Id &&
                t.User != null &&
                t.User.Id == _userAccessor.GetUserName());

        if (todo is null) {
            response.Success = false;
            response.Message = $"Todo with Id '{updatedUpdateTodo.Id}' not found.";
            return response;
        }

        todo.Title = updatedUpdateTodo.Title;
        todo.Content = updatedUpdateTodo.Content;
        todo.IsDone = updatedUpdateTodo.IsDone;
        await _context.SaveChangesAsync();

        response.Data = _mapper.Map<GetTodoDto>(todo);
        
        return response;
    }

    public async Task<ServiceResponse<GetTodoDto>> Delete(int id) {
        ServiceResponse<GetTodoDto> response = new();
        
        var todo = await _context.Todos
            .Include(t => t.User)
            .FirstOrDefaultAsync(t =>
                t.Id == id &&
                t.User != null &&
                t.User.Id == _userAccessor.GetUserName());

        if (todo is null) {
            response.Success = false;
            response.Message = $"Todo with Id '{id}' not found.";
            return response;
        }

        todo.IsDeleted = true;
        await _context.SaveChangesAsync();

        response.Data = _mapper.Map<GetTodoDto>(todo);
        
        return response;
    }
}