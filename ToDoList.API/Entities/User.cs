using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.API.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserSecondName { get; set; }
        public int UserAge { get; set; }
        public string UserEmail {  get; set; }
        public string UserPassword { get; set; }
        public DateTime UserStartDate { get; set; }
        public bool IsDeleted { get; private set; } = false;
        public ICollection<Address> UserAddress { get; } = new List<Address>();
        public ICollection<Tasks> UserTasks { get; } = new List<Tasks>();
        public ICollection<Category> UserCategory { get; } = new List<Category>();
        public ICollection<Tag> UserTags { get; } = new List<Tag>();

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }

        public void Update(string userFirstName, string userSecondName, int userAge, string userEmail)
        {
            UserFirstName = userFirstName;
            UserSecondName = userSecondName;
            UserAge = userAge;
            UserEmail = userEmail;
        }
    }   

    
}
