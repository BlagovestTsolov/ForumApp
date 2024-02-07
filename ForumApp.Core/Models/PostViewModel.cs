using System.ComponentModel.DataAnnotations;
using static ForumApp.DataBase.Data.Constants.Constants;

namespace ForumApp.Core.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, 
            ErrorMessage = "The title should be between {2} and {1} symbols long.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, 
            ErrorMessage = "The Content should be between {2} and {1} symbols long.")]
        public string Content {  get; set; } = null!;
    }
}
