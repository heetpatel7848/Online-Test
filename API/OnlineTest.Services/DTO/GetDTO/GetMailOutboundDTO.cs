using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Services.DTO.GetDTO
{
    public class GetMailOutboundDTO
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TestLink")]
        public int TestLinkId { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }
        public TestLink TestLink { get; set; }
    }
}
