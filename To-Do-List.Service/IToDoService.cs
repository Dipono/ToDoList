using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To-Do-List.Data;
using To_Do_List.Data.DTOs;

namespace To_Do_List.Service
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
