namespace AuthorAPI.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string NameEn { get; set; } = string.Empty;
        public string NameTa { get; set; } = string.Empty;
        public string Role { get; set; } = "Writer";
        public string? BioEn { get; set; }
        public string? BioTa { get; set; }
        public string? PhotoUrl { get; set; }
        public string? SocialLink { get; set; }
        public bool IsActive { get; set; } = true;
    }
}