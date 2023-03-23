using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddQuestionDTO
    {
        [Required(ErrorMessage = "Index name is required")]
        public string QuestionName { get; set; }
        [Required(ErrorMessage = "Question is required")]
        public string Que { get; set; }
        [Required(ErrorMessage = "Question type is required")]
        public int Type { get; set; }
        [Required(ErrorMessage = "Weightage is required")]
        public int Weightage { get; set; }
        [Required(ErrorMessage = "Order is required")]
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public int TestId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}