using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DagitimDetailDto : IDto
    {
        public int DagitimId { get; set; }
        public DateTime ExamDay{ get; set; }        
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public int StdntNo { get; set; }
        public string StdntName { get; set; }
        public int ClassId{ get; set; }
        public string StdntClass { get; set; }
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        public byte Yer { get; set; }
        public string Image { get; set; }
    }
}
