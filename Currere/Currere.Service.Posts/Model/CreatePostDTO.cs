using System.ComponentModel.DataAnnotations;

namespace Currere.Service.Posts.Model
{
    public class CreatePostDTO
    {

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string TextContent { get; set; } = string.Empty;
    }
}
