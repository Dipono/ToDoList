using ToDoList.Model;
using ToDoList.Model.DTOs;

namespace ToDoList.Service
{
    public interface IToDoService
    {
        Task<Item> AddItem(ItemDto item);
        Task<Item> UpdateItem(ItemDto item);
        string RemoveItem(int itemId);
        Item MarkCompleteItem(int itemId, bool mark);
        IEnumerable<Item> GetAllAllItems();

    }
}