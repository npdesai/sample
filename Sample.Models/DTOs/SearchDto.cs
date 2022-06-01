using Sample.Models.Enums;

namespace Sample.Models.DTOs
{
    public class SearchDto
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SortField { get; set; }
        public SortOrder? SortOrder { get; set; }
    }
}
