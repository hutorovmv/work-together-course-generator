namespace CourseGenerator.Api.Models.Security
{
    public class HeadingManagerModel
    {
        public string UserId { get; set; }
        public int HeadingId { get; set; }
        public bool IsOwner { get; set; }
    }
}
