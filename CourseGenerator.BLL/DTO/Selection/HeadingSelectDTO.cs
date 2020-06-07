using CourseGenerator.BLL.Interfaces.Other;

namespace CourseGenerator.BLL.DTO.Selection
{
    public class HeadingSelectDTO : ILocal
    {
        public int HeadingId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LangCode { get; set; }
    }
}
