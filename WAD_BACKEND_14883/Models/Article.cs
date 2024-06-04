using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAD_BACKEND_14883.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public int? AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
    }
}
