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
            var results = await _toDoService.GetAllItems();

            return Ok(results);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasksByFiltering([FromQuery] string status)
        {
            var response = new ResponseWrapper();
            if (status?.ToLower() != "completed" && status?.ToLower() != "pending")
            {
                response.Message = "Status should only be 'completed' or 'pending'";
            }
            else
            {
                var results = await _toDoService.GetFilterAllItems(status);
                response.Message = "Information list";
                response.Success = true;
                response.Results = results; 
            }
            
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> MarkasCompleted(int id)
        {
            var response = new ResponseWrapper();
            response.Message = "Unable to update item";
            var results = await _toDoService.MarkCompleteItem(id);
            if (results != null)
            {
                response.Success = true;
                response.Message = "Item marked completed";
                response.Results = results;
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Item item)
        {
            var response = new ResponseWrapper();
            response.Message = "Unable to update item";
            if(id != item.Id) {
                response.Message = "Item not exist";                              
            }
            else
            {
                var results = await _toDoService.UpdateItem(item);
                if (results != null)
                {
                    response.Success = true;
                    response.Message = "Item updated";
                    response.Results = results;
                }
            }
            
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task <string> RemoveItem(int id)
        {
            string message = await _toDoService.RemoveItem(id);
            return message;
        }
    }
}
