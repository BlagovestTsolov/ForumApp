using System.ComponentModel.DataAnnotations;
using static ForumApp.DataBase.Data.Constants.Constants;

namespace ForumApp.DataBase.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = string.Empty;
    }
}
