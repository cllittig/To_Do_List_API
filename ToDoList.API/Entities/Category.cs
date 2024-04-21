using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace ToDoList.API.Entities
{
    [Table("category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public ICollection<Tasks> CategoryTasks { get; } = new List<Tasks>();
        public int UserId { get; set; }
        public bool IsDeleted { get; set; } = false;
        

        public void MarkIsDeleted()
        {
            IsDeleted = true;
        }
    }
    
}
