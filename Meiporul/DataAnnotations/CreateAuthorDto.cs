using System.ComponentModel.DataAnnotations;

namespace AuthorAPI.Models
{
    public class CreateAuthorDto
    {
        [Required(ErrorMessage = "English Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string NameEn { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tamil Name is required")]
        public string NameTa { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "Writer";

        public string? BioEn { get; set; }
        public string? BioTa { get; set; }

        [Url(ErrorMessage = "Invalid Photo URL format")]
        public string? PhotoUrl { get; set; }
    }
}