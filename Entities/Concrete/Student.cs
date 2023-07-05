using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Student : IEntity
    {      
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string? Image { get; set; }
        
        
        


    }
}
