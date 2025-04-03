using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Model;
using ToDoList.Model.DTOs;
using ToDoList.Service;

namespace To_Do_List_Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("CorsPolicy")]
    public class ToDoLisController : Controller
    {
        private readonly IToDoService _toDoService;
        public ToDoLisController(IToDoService toDoService) {
            this._toDoService = toDoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemDto item)
        {
            var response = new ResponseWrapper();
           var results = await _toDoService.AddItem(item);
            if(results != null)
            {
                response = new ResponseWrapper
                {
                    Message = "Successfully added new item",
                    Results = results,
                    Success = true
                };
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var results = await _toDoService.GetAllAllItems();

            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> MarkasCompleted(int id)
        {
            var response = new ResponseWrapper();
            await _toDoService.MarkCompleteItem(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] ItemDto item)
        {
            await _toDoService.UpdateItem(item);
            return NoContent();
        }
    }
}
