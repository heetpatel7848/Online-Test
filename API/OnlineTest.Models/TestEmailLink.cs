using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineTest.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Model
{
    public class TestEmailLink
    {
        public int Id { get; set; }
        public Guid Token { get; set; }

        [ForeignKey("test_Id")]
        public int TestId { get; set; }

        [ForeignKey("user_Id")]
        public int UserId { get; set; }
        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? AccessOn { get; set; }
        public int AccessCount { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? SubmitedOn { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ExpireOn { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastAccessOn { get; set; }
        #region ForeignKey
        public User user_Id { get; set; }
        public Test test_Id { get; set; }
        #endregion
    }
}