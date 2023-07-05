using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Exam : IEntity
    {
        public int Id { get; set; }        
        public string? Name { get; set; }        
        public string Day{ get; set; }
        public byte? DersSaati { get; set; }
        public DateTime Dates { get; set; }
        
        public string? Declaration { get; set; }


    }
}
