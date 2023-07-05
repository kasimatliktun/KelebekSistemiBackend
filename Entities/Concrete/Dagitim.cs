using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Dagitim : IEntity
    {
        public int Id { get; set; }
        public int ExamId { get; set; }        
        public string? Name { get; set; }
        public int StdntId { get; set; }
        public byte SalonId { get; set; }
        public byte Yer { get; set; }        
        public string? Declaration { get; set; }


    }
}
