using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model.DTOs
{
    public class ItemDto
    {

        public ItemDto()
        {
            Title = string.Empty;
            Description = string.Empty;
            Priority = string.Empty;
        }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
    }
}
