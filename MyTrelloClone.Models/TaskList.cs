using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTrelloClone.Models
{
    public class TaskList
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("BoardId")]
        public Board Board { get; set; }
        public int BoardId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
