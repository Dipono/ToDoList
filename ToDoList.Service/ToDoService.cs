using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model;
using ToDoList.Model.DTOs;

namespace ToDoList.Service
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoListContext _dbContext;

        public ToDoService(ToDoListContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add Task Item
        public async Task<Item> AddItem(ItemDto item)
        {
            var tblItem = new Item
            {
                Description = item.Description,
                Title = item.Title,
                Priority = item.Priority,
                DueDate = item.DueDate
            };
            await _dbContext.Items.AddAsync(tblItem);
            await _dbContext.SaveChangesAsync();
            return tblItem;
        }

        // Get all Items
        public async Task<IEnumerable<Item>> GetAllAllItems()
        {
            return await _dbContext.Items.ToListAsync();
        }

        // update the item
        public async Task<Item> MarkCompleteItem(int itemId)
        {
            var results = await GetTaskByIdAsync(itemId);

            results.Status = true;
            var resultsDto = new ItemDto
            {
                DueDate = (DateTime)results.DueDate,
                Description = results.Description,
                Title = results.Title,
                Priority = results.Priority,
                Status = results.Status
            };
            return await UpdateItem(resultsDto);
        }

        public async Task<string> RemoveItem(int itemId)
        {
            string message = "";
            var results = await GetTaskByIdAsync(itemId);
            _dbContext.Items.Remove(results);
            return message;
        }

        public async Task<Item> UpdateItem(ItemDto itemDto)
        {
            var item = new Item
            {
                Description = itemDto.Description,
                Title = itemDto.Title,
                Priority = itemDto.Priority,
                DueDate = itemDto.DueDate,
            };
            _dbContext.Items.Update(item);
             await _dbContext.SaveChangesAsync();
            return item;
        }

        // get Item by id
        private async Task<Item> GetTaskByIdAsync(int id)
        {
            return await _dbContext.Items.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
