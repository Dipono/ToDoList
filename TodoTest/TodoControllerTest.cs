using Microsoft.EntityFrameworkCore;
using Moq;
using ToDoList.Model;
using ToDoList.Model.DTOs;
using ToDoList.Service;

namespace TodoTest
{
    public class TodoControllerTest
    {
        private ToDoService _service;
        private ToDoListContext _context;

        public TodoControllerTest()
        {
            var options = new DbContextOptionsBuilder<ToDoListContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ToDoListContext(options);
            _service = new ToDoService(_context);
        }

        [Fact]
        public async Task AddItem_ShouldAddAndReturnItem()
        {
            // Arrange
            var dto = new ItemDto
            {
                Title = "Buy Groceries",
                Description = "Purchase vegetables, fruits, bread, and milk from the local grocery store.",
                Priority = "High",
                DueDate = DateTime.Now.AddDays(1)
            };

            // Act
            var result = await _service.AddItem(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Buy Groceries", result.Title);
            Assert.Single(_context.Items);
        }

        [Fact]
        public async Task GetAllAllItems_ShouldReturnAllItems()
        {
            // Arrange
            await _context.Items.AddAsync(new Item { Title = "Buy Household Cleaning Supplie", Description = "Purchase cleaning supplies—detergents, sponges, etc.", Priority = "Low", DueDate = DateTime.Now.AddDays(5) });
            await _context.Items.AddAsync(new Item { Title = "Get Dog Food", Description = "Pick up a bag of dog food from the pet store", Priority = "Medium", DueDate = DateTime.Now.AddDays(2) });
            await _context.SaveChangesAsync();

            // Act
            var results = await _service.GetAllItems();

            // Assert
            Assert.Equal(2, results.Count());
        }

        [Fact]
        public async Task MarkCompleteItem_ShouldSetStatusToTrue()
        {
            // Arrange
            var item = new Item { 
                Title = "Pick Up Medicine", 
                Description = "Pick up prescribed medicines from the pharmacy.",
                DueDate = DateTime.Now.AddDays(1),
                Priority = "High",
                Status = false 
            };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.MarkCompleteItem(item.Id);

            // Assert
            Assert.True(result.Status);
        }

        [Fact]
        public async Task RemoveItem_ShouldDeleteItem()
        {
            // Arrange
            var item = new Item { 
                Title = "Buy Birthday Gift for Jane" ,
                Description = "Buy a gift for Jane's birthday—look for a book or a gift card.",
                DueDate = DateTime.Now.AddDays(1),
                Priority = "High",
                Status = false
            };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            Console.Write(item);
            // Act
            var msg = await _service.RemoveItem(item.Id);
            var found = await _context.Items.FindAsync(item.Id);

            // Assert
            Assert.Equal("Item removed successfully", msg);
            
        }

        [Fact]
        public async Task RemoveItem_NotExistItem()
        {
            // Arrange
            var itemId = 5555;
            // Act
            var msg = await _service.RemoveItem(itemId);
            var found = await _context.Items.FindAsync(itemId);

            // Assert
            Assert.Equal("Item not exist", msg);

        }

        [Fact]
        public async Task UpdateItem_ShouldUpdateExistingItem()
        {
            // Arrange
            var item = new Item { Title = "Old Title" };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            item.Title = "Updated Title";

            // Act
            var updated = await _service.UpdateItem(item);

            // Assert
            Assert.Equal("Updated Title", updated.Title);
        }


    }
}