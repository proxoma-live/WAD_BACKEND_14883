using System.ComponentModel.DataAnnotations;

namespace WAD_BACKEND_14883.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Gender { get; set; }

        [StringLength(70)]
        public string Bio { get; set; }
    }
}
