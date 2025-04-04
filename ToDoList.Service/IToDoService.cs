using ToDoList.Model;
using ToDoList.Model.DTOs;

namespace ToDoList.Service
{
    public interface IToDoService
    {
        Task<Item> AddItem(ItemDto item);
        Task<Item> UpdateItem(Item item);
        Task<string> RemoveItem(int itemId);
        Task<Item> MarkCompleteItem(int itemId);
        Task<IEnumerable<Item>> GetAllItems();
        Task<IEnumerable<Item>> GetFilterAllItems(string status);
    }
}