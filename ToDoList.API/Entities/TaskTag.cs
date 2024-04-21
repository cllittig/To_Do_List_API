using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.API.Entities
{
    [Table("task_tag")]
    public class TaskTag
    {
        
        public int TaskId { get; set; }
        public int TagId { get; set; }

        public Tasks Task { get; set; } = null!;
        public Tag Tag { get; set; } = null!;
    }
}