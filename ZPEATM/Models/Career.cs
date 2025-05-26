using System.ComponentModel.DataAnnotations;

namespace ZPEATM.Models
{
    public class Career
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Position { get; set; }

        public string ResumePath { get; set; }
    }
}
