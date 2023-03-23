using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddTestDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string TestName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public DateTime? ExpireOn { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public int TechnologyId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}