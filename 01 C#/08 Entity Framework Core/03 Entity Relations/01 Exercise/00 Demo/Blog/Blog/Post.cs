using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo
{
    [Table("Posts", Schema = "blg")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PostTitle { get; set; } = null!;

        [Required]
        public string Body { get; set; } = null!;

        public int BlogId { get; set; }

        [ForeignKey(nameof(BlogId))]
        public Blog Blog { get; set; } = null!;

        public List<PostTag> PostsTags { get; set; } = new List<PostTag>();
    }
}
