using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Model
{
    public class Item
    {
        public Item()
        {
            Title = string.Empty;
            Description = string.Empty;
            DateAndTime = DateTime.Now;
            Priority = string.Empty;
            Status = false;
        }
        [Key]
        public int Id { get;set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Priority { get; set; }
        public bool Status { get; set; }
    }
}