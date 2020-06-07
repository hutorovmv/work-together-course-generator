namespace CourseGenerator.BLL.DTO.Security
{
    public class HeadingManagerDTO
    {
        public string UserId { get; set; }
        public int HeadingId { get; set; }
        public bool IsOwner { get; set; }
    }
}
