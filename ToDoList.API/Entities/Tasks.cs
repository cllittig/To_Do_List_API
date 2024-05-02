using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.API.Entities
{
    [Table("task")]
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskCreationDate { get; set; }
        public DateTime TaskDueDate { get; set; }
        public string TaskPriority { get; set; }
        public string TaskStatus { get; set; }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<TaskTag> TaskTags { get; set; } = new List<TaskTag>();

        public void MarkIsDeleted()
        {
            IsDeleted = true;
        }

        public void Update(string taskTitle,string taskDescription, string taskPriority,string taskStatus)
        {
            TaskTitle = taskTitle;
            TaskDescription = taskDescription;
            TaskPriority = taskPriority;
            TaskStatus = taskStatus;
        }
    }
}
