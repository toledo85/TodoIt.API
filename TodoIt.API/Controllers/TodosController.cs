using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoIt.Application.Dtos.Todos;
using TodoIt.Application.Repositories.Todos;

namespace TodoIt.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase {
    private readonly ITodosRepository _todosRepository;

    public TodosController(ITodosRepository todosRepository) {
        _todosRepository = todosRepository;
    }
    
    [HttpGet] public async Task<IActionResult> Get() {
        var todos = await _todosRepository.GetAll();
        return Ok(todos);
    }
    
    [HttpGet("{id:int}")] public async Task<IActionResult> Get(int id) {
        var todo = await _todosRepository.Get(id);
        return Ok(todo);
    }
    
    [HttpPost] public async Task<IActionResult> Post(CreateTodoDto newTodo) {
        _ = await _todosRepository.Create(newTodo);
        
        return await Get();
    }
    
    [HttpPut] public async Task<IActionResult> Put(UpdateTodoDto updatedUpdateTodo) {
        var todo = await _todosRepository.Update(updatedUpdateTodo);
        
        if (todo is null) {
            return NotFound();
        }
        
        return await Get();
    }
    
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) {
        Console.WriteLine("Hiiiiii thereeeeeeeee");
        
        var todo = await _todosRepository.Delete(id);
        
        if (todo is null) {
            return NotFound();
        }
    
        return await Get();
    }
}