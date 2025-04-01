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

        public async Task<Item> AddItem(ItemDto item)
        {
            var tblItem = new Item
            {
                Description = item.Description,
                Title = item.Title,
                Priority = item.Priority
            };
            await _dbContext.Items.AddAsync(tblItem);
            await _dbContext.SaveChangesAsync();
            return tblItem;
        }

        public IEnumerable<Item> GetAllAllItems()
        {
            throw new NotImplementedException();
        }

        public Item MarkCompleteItem(int itemId, bool mark)
        {
            throw new NotImplementedException();
        }

        public string RemoveItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<Item> UpdateItem(ItemDto item)
        {
            throw new NotImplementedException();
        }
    }
}
