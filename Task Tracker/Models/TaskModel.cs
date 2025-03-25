using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Tracker.Models
{
    [Table("Task")]
    public class TaskModel
    {
        [Column("Task_ID")]
        public int Id { get; set; }
        [Column("Title")]
        public string Title { get; set; }
        [Column("IsCompleted")]
        public bool IsCompleted { get; set; }
    }
}
