using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class StudentDetailDto : IDto
    {
        public int StudentId { get; set; }
        public string StudentName{ get; set; }
        public string ClassroomName{ get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
    }
}
