using System.ComponentModel.DataAnnotations;

namespace ADSGuestbook.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date")]
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
