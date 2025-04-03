using ToDoList.Model;
using ToDoList.Model.DTOs;

namespace ToDoList.Service
{
    public interface IToDoService
    {
        Task<Item> AddItem(ItemDto item);
        Task<Item> UpdateItem(ItemDto item);
        Task<string> RemoveItem(int itemId);
        Task<Item> MarkCompleteItem(int itemId);
        Task<IEnumerable<Item>> GetAllAllItems();

    }
}