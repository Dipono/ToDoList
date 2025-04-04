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
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _dbContext.Items.ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetFilterAllItems(string status)
        {
            bool completed = status?.Equals("completed", StringComparison.OrdinalIgnoreCase) ?? false;

            // Filter items based on status (true for completed, false for others)
            return await _dbContext.Items
                                   .Where(item => item.Status == completed)
                                   .ToListAsync();
        }


        // update the item
        public async Task<Item> MarkCompleteItem(int itemId)
        {
            var results = await GetTaskByIdAsync(itemId);
            if(results != null)
            {
                results.Status = true;            
                await UpdateItem(results);
            }
            return results;
        }

        public async Task<string> RemoveItem(int itemId)
        {
            string message = "Item not exist";
            var results = await GetTaskByIdAsync(itemId);
            if(results != null) { 
                _dbContext.Items.Remove(results);
                message = "Item removed successfully";
            }
            return message;
        }

        public async Task<Item> UpdateItem(Item item)
        {
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
