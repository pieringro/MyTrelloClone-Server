using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTrelloClone.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TaskListId")]
        public TaskList TaskList { get; set; }

        public int TaskListId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
