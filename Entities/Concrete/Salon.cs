using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Salon : IEntity
    {
        public byte Id { get; set; }        
        public string Name { get; set; }                
        public byte Capacities { get; set; }
        public byte Grup { get; set; }
        public byte SiraDurumu { get; set; }
        


    }
}
