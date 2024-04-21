using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.API.Entities
{
    [Table("tag")]
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public List<Tasks> Task { get; set; } = new List<Tasks>();
        public List<TaskTag> TaskTag { get; set; } = new List<TaskTag>();

        public void MarkIsDeleted()
        {
            IsDeleted = true;
        }
    }
}
